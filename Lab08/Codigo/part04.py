import cv2
import numpy as np
from pathlib import Path

img_path = Path("redimensionadas_lab08/wallpaper_redimensionada.png")

# Cargar imagen con OpenCV 
img = cv2.imread(str(img_path))

if img is None:
    print("Error: no se pudo cargar la imagen.")
    print("Verifica que la ruta sea correcta:", img_path)
    exit()

# Variables para controlar la visibilidad de los canales
show_b = True
show_g = True
show_r = True

print("Controles:")
print("R = activar/desactivar canal rojo")
print("G = activar/desactivar canal verde")
print("B = activar/desactivar canal azul")
print("ESC = salir")

while True:
    # Crea una copia de la imagen original 
    modified = img.copy()

    # Separa canales BGR 
    b, g, r = cv2.split(modified)

    # Oculta canales según la tecla presionada 
    if not show_b:
        b[:] = 0

    if not show_g:
        g[:] = 0

    if not show_r:
        r[:] = 0

    # Combina nuevamente los canales 
    merged = cv2.merge([b, g, r])

    estado = f"R:{'ON' if show_r else 'OFF'}  G:{'ON' if show_g else 'OFF'}  B:{'ON' if show_b else 'OFF'}"

    cv2.putText(
        merged,
        estado,
        (30, 50),
        cv2.FONT_HERSHEY_SIMPLEX,
        1,
        (255, 255, 255),
        2,
        cv2.LINE_AA
    )

    cv2.putText(
        merged,
        "Presiona R, G, B para alternar canales | ESC para salir",
        (30, 90),
        cv2.FONT_HERSHEY_SIMPLEX,
        0.8,
        (255, 255, 255),
        2,
        cv2.LINE_AA
    )

    # Muestra la imagen
    cv2.imshow("Visualizador interactivo de canales RGB", merged)

    # Capturar tecla
    key = cv2.waitKey(1) & 0xFF

    # ESC para salir
    if key == 27:
        break

    elif key == ord("r") or key == ord("R"):
        show_r = not show_r
        print("Canal rojo:", "Activado" if show_r else "Desactivado")
 
    elif key == ord("g") or key == ord("G"):
        show_g = not show_g
        print("Canal verde:", "Activado" if show_g else "Desactivado")

    elif key == ord("b") or key == ord("B"):
        show_b = not show_b
        print("Canal azul:", "Activado" if show_b else "Desactivado")

cv2.destroyAllWindows()
