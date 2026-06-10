from pathlib import Path
from PIL import Image
import matplotlib.pyplot as plt

rutas = [
    Path("D:\Unity\Lab07\Codigo\ciudad.jpg"),
    Path("D:\Unity\Lab07\Codigo\KNY.webp")
    Path("D:\Unity\Lab07\Codigo\wallpaper.jpg"),
]

nombres = ["ciudad", "KNY", "wallpaper"]

# Abrir imágenes y convertir a RGB  

imagenes = []

for ruta in rutas:
    imagen = Image.open(ruta).convert("RGB")
    imagenes.append(imagen)

# Obtener el tamaño más grande 

anchos = [img.width for img in imagenes]
altos = [img.height for img in imagenes]

ancho_maximo = max(anchos)
alto_maximo = max(altos)

tamano_objetivo = (ancho_maximo, alto_maximo)

print("Tamaño objetivo:", tamano_objetivo)

# Redimensionar imágenes

imagenes_redimensionadas = []

for img in imagenes:
    img_redimensionada = img.resize(
        tamano_objetivo,
        Image.Resampling.LANCZOS
    )
    imagenes_redimensionadas.append(img_redimensionada)

# Guardar imágenes redimensionadas

carpeta_salida = Path("imagenes_redimensionadas")
carpeta_salida.mkdir(exist_ok=True)

for nombre, img in zip(nombres, imagenes_redimensionadas):
    ruta_salida = carpeta_salida / f"{nombre.lower()}_redimensionada.png"
    img.save(ruta_salida)

# Resultados

fig, ejes = plt.subplots(1, 3, figsize=(15, 5))

for eje, img, nombre in zip(ejes, imagenes_redimensionadas, nombres):
    eje.imshow(img)
    eje.set_title(nombre)
    eje.axis("off")

plt.tight_layout()
plt.show()
