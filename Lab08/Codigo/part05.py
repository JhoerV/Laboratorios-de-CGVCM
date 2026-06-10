from pathlib import Path
import cv2
import matplotlib.pyplot as plt

img_path = Path("elon.webp")

# Cargar imagen con OpenCV
img = cv2.imread(str(img_path))

if img is None:
    print("Error: no se pudo cargar la imagen.")
    exit()

# Coordenadas ajustadas para encerrar el rostro
centro_circulo = (410, 185)   # (x, y)
radio = 125
# OpenCV usa formato BGR 
color_circulo = (0, 255, 0)   # Verde
grosor = 4

# Dibuja el círculo sobre el rostro
cv2.circle(img, centro_circulo, radio, color_circulo, grosor)

texto = "Persona"
posicion_texto = (centro_circulo[0] - 80, centro_circulo[1] + radio + 45)

fuente = cv2.FONT_HERSHEY_SIMPLEX
escala = 1.2
color_texto = (0, 255, 0)
grosor_texto = 3

cv2.putText(
    img,
    texto,
    posicion_texto,
    fuente,
    escala,
    color_texto,
    grosor_texto,
    cv2.LINE_AA
)

# Guardar la imagen 

output_path = Path("parte5_imagen_circulo_texto.png")
cv2.imwrite(str(output_path), img)

# Mostrar imagen con Matplotlib 

# Convertir de BGR a RGB para mostrar correctamente
img_rgb = cv2.cvtColor(img, cv2.COLOR_BGR2RGB)

plt.figure(figsize=(10, 6))
plt.imshow(img_rgb)
plt.axis("off")
plt.title("Imagen con círculo y texto")
plt.show()

print("Imagen guardada en:", output_path)