from pathlib import Path
import numpy as np
from PIL import Image
import matplotlib.pyplot as plt

# Rutas de las imágenes redimensionadas

img1_path = Path("redimensionadas_lab08/ciudad_redimensionada.png")
img2_path = Path("redimensionadas_lab08/KNY_redimensionada.png")
img3_path = Path("redimensionadas_lab08/wallpaper_redimensionada.png")

# Cargar imágenes y asegurar formato RGB

img1 = Image.open(img1_path).convert("RGB")
img2 = Image.open(img2_path).convert("RGB")
img3 = Image.open(img3_path).convert("RGB")

# Convertir a arreglos NumPy

arr1 = np.array(img1)
arr2 = np.array(img2)
arr3 = np.array(img3)
# Crear imágenes con un solo canal visible 

# Solo canal rojo de la primera imagen
only_red = np.zeros_like(arr1)
only_red[:, :, 0] = arr1[:, :, 0]

# Solo canal verde de la segunda imagen
only_green = np.zeros_like(arr2)
only_green[:, :, 1] = arr2[:, :, 1]

# Solo canal azul de la tercera imagen
only_blue = np.zeros_like(arr3)
only_blue[:, :, 2] = arr3[:, :, 2]

# Convertir arreglos a imágenes

img_red = Image.fromarray(only_red.astype(np.uint8))
img_green = Image.fromarray(only_green.astype(np.uint8))
img_blue = Image.fromarray(only_blue.astype(np.uint8))

# Guardar imágenes por canal

carpeta_salida = Path("redimensionadas_lab08")
carpeta_salida.mkdir(exist_ok=True)

img_red.save(carpeta_salida / "ciudad_solo_rojo.png")
img_green.save(carpeta_salida / "KNY_solo_verde.png")
img_blue.save(carpeta_salida / "wallpaper_solo_azul.png")

# Mostrar imágenes por separado

fig, ejes = plt.subplots(1, 3, figsize=(15, 5))

ejes[0].imshow(img_red)
ejes[0].set_title("Ciudad - Solo canal rojo")
ejes[0].axis("off")

ejes[1].imshow(img_green)
ejes[1].set_title("KNY - Solo canal verde")
ejes[1].axis("off")

ejes[2].imshow(img_blue)
ejes[2].set_title("Wallpaper - Solo canal azul")
ejes[2].axis("off")

plt.tight_layout()
plt.show()
