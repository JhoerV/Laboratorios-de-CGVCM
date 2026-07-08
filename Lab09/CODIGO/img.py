# ============================================================
# LABORATORIO 09
# Clasificación y Reconocimiento de Objetos con YOLOv8
# ============================================================

# ============================================================
# PARTE 1: INSTALAR LIBRERÍAS
# ============================================================

!pip install -q ultralytics roboflow

# ============================================================
# PARTE 2: IMPORTAR LIBRERÍAS
# ============================================================

from ultralytics import YOLO
from roboflow import Roboflow

import os
import glob

from PIL import Image
import matplotlib.pyplot as plt

# ============================================================
# PARTE 3: DESCARGAR DATASET DESDE ROBOFLOW
# ============================================================


rf = Roboflow(api_key="ommTVP5jrZFIcGCecygM")

project = rf.workspace("Jhoers Workspace").project("Clasificacion_reconocimiento")

dataset = project.version(1).download("yolov8")

# ============================================================
# PARTE 4: VERIFICAR EL DATASET
# ============================================================

print("Ubicación del Dataset:")
print(dataset.location)

print("\nContenido del Dataset:")
print(os.listdir(dataset.location))

# ============================================================
# PARTE 5: CARGAR MODELO PREENTRENADO
# ============================================================

model = YOLO("yolov8n.pt")

# ============================================================
# PARTE 6: ENTRENAMIENTO DEL MODELO
# ============================================================

model.train(

    data=f"{dataset.location}/data.yaml",

    epochs=50,

    imgsz=640,

    batch=16

)

# ============================================================
# PARTE 7: VALIDAR EL MODELO
# ============================================================

metrics = model.val()

print(metrics)

# ============================================================
# PARTE 8: REALIZAR PREDICCIÓN SOBRE UNA IMAGEN
# ============================================================

results = model.predict(

    source="imagen_prueba.jpg",

    conf=0.5,

    save=True

)

# ============================================================
# PARTE 9: REALIZAR PREDICCIÓN SOBRE UNA CARPETA
# ============================================================

results = model.predict(

    source="imagenes/",

    conf=0.5,

    save=True

)

# ============================================================
# PARTE 10: REALIZAR PREDICCIÓN SOBRE UN VIDEO
# ============================================================

results = model.predict(

    source="video.mp4",

    conf=0.5,

    save=True

)

# ============================================================
# PARTE 11: MOSTRAR LOS RESULTADOS
# ============================================================

imagenes = glob.glob("runs/detect/predict/*")

for img in imagenes:

    plt.figure(figsize=(8,8))

    plt.imshow(Image.open(img))

    plt.axis("off")

    plt.show()

# ============================================================
# PARTE 12: CARGAR EL MODELO ENTRENADO
# ============================================================

model = YOLO("runs/detect/train/weights/best.pt")

# ============================================================
# PARTE 13: USAR EL MODELO ENTRENADO
# ============================================================

results = model.predict(

    source="nueva_imagen.jpg",

    conf=0.5,

    save=True

)

# ============================================================
# PARTE 14: MOSTRAR LAS DETECCIONES
# ============================================================

imagenes = glob.glob("runs/detect/predict/*")

for img in imagenes:

    plt.figure(figsize=(10,10))

    plt.imshow(Image.open(img))

    plt.axis("off")

    plt.show()

# ============================================================
# PARTE 15: GUARDAR EL MODELO
# ============================================================

print("El modelo entrenado se encuentra en:")

print("runs/detect/train/weights/best.pt")