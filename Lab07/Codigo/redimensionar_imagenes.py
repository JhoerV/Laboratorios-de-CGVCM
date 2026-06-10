from pathlib import Path
from PIL import Image
import matplotlib.pyplot as plt

# ==============================
# 1. Rutas de las imágenes
# ==============================

rutas = [
    Path("D:/Unity/Lab07/Codigo/ciudad.jpg"),
    Path("D:/Unity/Lab07/Codigo/wallpaper.jpg"),
    Path("D:/Unity/Lab07/Codigo/KNY.webp")
]

nombres = ["Digimon", "Pokémon", "Miles"]

# ==============================
# 2. Abrir imágenes y convertir a RGB
# ==============================

imagenes = []

for ruta in rutas:
    imagen = Image.open(ruta).convert("RGB")
    imagenes.append(imagen)

# ==============================
# 3. Obtener el tamaño más grande
# ==============================

ancho_maximo = max(img.width for img in imagenes)
alto_maximo = max(img.height for img in imagenes)

tamano_objetivo = (ancho_maximo, alto_maximo)

print("Tamaño objetivo:", tamano_objetivo)

# ==============================
# 4. Redimensionar las imágenes
# ==============================

imagenes_redimensionadas = []

for img in imagenes:
    img_redimensionada = img.resize(
        tamano_objetivo,
        Image.Resampling.LANCZOS
    )
    imagenes_redimensionadas.append(img_redimensionada)

# ==============================
# 5. Guardar imágenes redimensionadas
# ==============================

carpeta_salida = Path("redimensionadas")
carpeta_salida.mkdir(exist_ok=True)

for nombre, img in zip(nombres, imagenes_redimensionadas):
    ruta_salida = carpeta_salida / f"{nombre.lower()}_redimensionada.png"
    img.save(ruta_salida)

print("Imágenes guardadas en la carpeta 'redimensionadas'.")

# ==============================
# 6. Mostrar resultados
# ==============================

fig, ejes = plt.subplots(1, 3, figsize=(15, 5))

for eje, img, nombre in zip(ejes, imagenes_redimensionadas, nombres):
    eje.imshow(img)
    eje.set_title(nombre)
    eje.axis("off")

plt.tight_layout()
plt.show()
