from pathlib import Path
import cv2
import matplotlib.pyplot as plt

# Ruta de la imagen de ciudad
img_path = Path("ciudad.jpg")

# Cargar imagen en escala de grises

img_gray = cv2.imread(str(img_path), cv2.IMREAD_GRAYSCALE)

if img_gray is None:
    print("Error: no se pudo cargar la imagen.")
    exit()

# Aplicar umbral binario

umbral = 127
valor_maximo = 255

_, img_threshold = cv2.threshold(
    img_gray,
    umbral,
    valor_maximo,
    cv2.THRESH_BINARY
)

# Guardar imagen umbralizada

output_path = Path("parte6_ciudad_umbral_binario.png")
cv2.imwrite(str(output_path), img_threshold)

# Resultado

fig, axes = plt.subplots(1, 2, figsize=(14, 5))

axes[0].imshow(img_gray, cmap="gray")
axes[0].set_title("Ciudad en escala de grises")
axes[0].axis("off")

axes[1].imshow(img_threshold, cmap="gray")
axes[1].set_title(f"Umbral binario - valor {umbral}")
axes[1].axis("off")

plt.tight_layout()
plt.show()

print("Imagen umbralizada guardada en:", output_path)