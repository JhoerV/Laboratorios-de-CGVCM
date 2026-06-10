import cv2
import numpy as np
from pathlib import Path

# Crea lienzo blanco 
canvas = np.ones((700, 1000, 3), dtype=np.uint8) * 255

# Variables de control
drawing = False
start_point = None
current_shape = "rectangulo"

# Historial para deshacer cambios
history = []

# Colores en formato BGR
color = (0, 0, 255)      # Rojo
thickness = 3

def draw_shape(event, x, y, flags, param):
    global drawing, start_point, canvas, current_shape, history

    # Al presionar el botón izquierdo, inicia el dibujo
    if event == cv2.EVENT_LBUTTONDOWN:
        drawing = True
        start_point = (x, y)

        # Guardar estado anterior para deshacer
        history.append(canvas.copy())

    # Mientras se mueve el mouse con el botón presionado
    elif event == cv2.EVENT_MOUSEMOVE and drawing:
        temp_canvas = canvas.copy()

        if current_shape == "rectangulo":
            cv2.rectangle(temp_canvas, start_point, (x, y), color, thickness)

        elif current_shape == "circulo":
            radius = int(((x - start_point[0]) ** 2 + (y - start_point[1]) ** 2) ** 0.5)
            cv2.circle(temp_canvas, start_point, radius, color, thickness)

        elif current_shape == "linea":
            cv2.line(temp_canvas, start_point, (x, y), color, thickness)

        cv2.imshow("Dibujo interactivo", temp_canvas)
    # Al soltar el botón izquierdo, se confirma el dibujo
    elif event == cv2.EVENT_LBUTTONUP:
        drawing = False

        if current_shape == "rectangulo":
            cv2.rectangle(canvas, start_point, (x, y), color, thickness)

        elif current_shape == "circulo":
            radius = int(((x - start_point[0]) ** 2 + (y - start_point[1]) ** 2) ** 0.5)
            cv2.circle(canvas, start_point, radius, color, thickness)

        elif current_shape == "linea":
            cv2.line(canvas, start_point, (x, y), color, thickness)


# Crea ventana 
cv2.namedWindow("Dibujo interactivo")
cv2.setMouseCallback("Dibujo interactivo", draw_shape)

print("PROGRAMA DE DIBUJO INTERACTIVO")   
print("Controles:")
print("R = Dibujar rectángulo")
print("C = Dibujar círculo")
print("L = Dibujar línea")
print("Z = Deshacer último cambio")
print("S = Guardar dibujo")
print("N = Nuevo lienzo")
print("ESC = Salir")
print("==============================================")

while True:
    # Crea copia para mostrar información en pantalla 
    display_canvas = canvas.copy()

    cv2.putText(
        display_canvas,
        f"Figura actual: {current_shape.upper()}",
        (20, 35),
        cv2.FONT_HERSHEY_SIMPLEX,
        0.8,
        (0, 0, 0),
        2,
        cv2.LINE_AA
    )

    cv2.putText(
        display_canvas,
        "R: rectangulo | C: circulo | L: linea | Z: deshacer | S: guardar | N: nuevo | ESC: salir",
        (20, 670),
        cv2.FONT_HERSHEY_SIMPLEX,
        0.65,
        (0, 0, 0),
        2,
        cv2.LINE_AA
    )

    cv2.imshow("Dibujo interactivo", display_canvas)

    key = cv2.waitKey(1) & 0xFF

    # Salir con ESC
    if key == 27:
        break
    # Seleccionar rectángulo
    elif key == ord("r") or key == ord("R"):
        current_shape = "rectangulo"
        print("Figura seleccionada: rectángulo")
    # Seleccionar círculo
    elif key == ord("c") or key == ord("C"):
        current_shape = "circulo"
        print("Figura seleccionada: círculo")
    # Seleccionar línea
    elif key == ord("l") or key == ord("L"):
        current_shape = "linea"
        print("Figura seleccionada: línea")
    # Deshacer
    elif key == ord("z") or key == ord("Z"):
        if history:
            canvas = history.pop()
            print("Último cambio deshecho")
        else:
            print("No hay cambios para deshacer")
    # Guardar imagen
    elif key == ord("s") or key == ord("S"):
        output_path = Path("dibujo_final.png")
        cv2.imwrite(str(output_path), canvas)
        print("Dibujo guardado como:", output_path)
    # Nuevo lienzo
    elif key == ord("n") or key == ord("N"):
        history.append(canvas.copy())
        canvas = np.ones((700, 1000, 3), dtype=np.uint8) * 255
        print("Nuevo lienzo creado")

cv2.destroyAllWindows()
