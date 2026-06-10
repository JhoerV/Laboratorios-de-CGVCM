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

# Extraer canales específicos

red_channel = arr1[:, :, 0]    # Canal rojo de la primera imagen
green_channel = arr2[:, :, 1]  # Canal verde de la segunda imagen
blue_channel = arr3[:, :, 2]   # Canal azul de la tercera imagen

# Combinar canales

combined_array = np.stack((red_channel, green_channel, blue_channel), axis=2)

# Convertir a imagen y guardar

combined_img = Image.fromarray(combined_array.astype(np.uint8))
output_path = Path("redimensionadas_lab08/imagen_combinada_rgb.png")
combined_img.save(output_path)

# Resultado

plt.figure(figsize=(10, 6))
plt.imshow(combined_img)
plt.axis("off")
plt.show()

print(f"Imagen guardada en: {output_path}")