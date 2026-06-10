from pathlib import Path
import numpy as np
from PIL import Image
import matplotlib.pyplot as plt

img_path = Path("redimensionadas_lab08/imagen_combinada_rgb.png")

# Cargar imagen combinada

img = Image.open(img_path).convert("RGB")

# Convertir la imagen a arreglo NumPy

img_array = np.array(img)

# Crear imagen negativa

negative_array = 255 - img_array
negative_img = Image.fromarray(negative_array.astype(np.uint8))

negative_path = Path("redimensionadas_lab08/imagen_negativa.png")
negative_img.save(negative_path)

# Convertir a escala de grises

grayscale_img = img.convert("L")

grayscale_path = Path("redimensionadas_lab08/imagen_gris.png")
grayscale_img.save(grayscale_path)

# Resultados

fig, axes = plt.subplots(1, 3, figsize=(16, 5))

axes[0].imshow(img)
axes[0].set_title("Imagen combinada")
axes[0].axis("off")

axes[1].imshow(negative_img)
axes[1].set_title("Negativo de la imagen combinada")
axes[1].axis("off")

axes[2].imshow(grayscale_img, cmap="gray")
axes[2].set_title("Imagen en escala de grises")
axes[2].axis("off")

plt.tight_layout()
plt.show()

print("Imagen negativa guardada en:", negative_path)
print("Imagen en escala de grises guardada en:", grayscale_path)