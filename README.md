# PFE-evitement-obstacle

Ce projet a pour but de développer une solution d'évitement d'obstacle pour la conduite autonome sur une zoé équipé de caméras et d'un lidar.

Mon travail ce décompose en 2 partie : 

## Object detection 
Dans le dossier TensorFlow on retourve le travail effectué pour l'implémentation et l'entrainement d'un model pré-entrainer. 

Un notebook avec le code pour utiliser le model pré entrainer est présent dans TenserFlow/models/research/object_detection/object_dectertion.ipynb
La dernière partie du notebook fonctionne seulement si vous disposez d'une webcam.

Dans le dossier workspace on retrouve tout ce qui est nécessaire pour ré entrainer un model. 
Ce dossier comprend des images annotées dans le dossier "images", des images de test dans "test_images", un fichier contenant les labels utilisés dans "annotations", le model pré entrainer dans "pre-trained-models" et le model ré entrainer dans "exported-models".

Pour ajouter des images, d'autre labels ou utiliser d'autre model pré entrainer vous pouvez aller voir https://tensorflow-object-detection-api-tutorial.readthedocs.io/en/latest/training.html tout y est détailler 

Si vous voulez simplement ré entrainer le model avec les images présentes et à partir du checkpoint du dossier : 

- Déplacer vosu dans le dossier Tensorflow/workspace/training_demo 
- Lancer python model_main_tf2.py --model_dir=models/my_centernet_resnet50_v1_fpn --pipeline_config_path=models/my_centernet_resnet50_v1_fpn/pipeline.config --checkpoint_dir=models/my_centernet_resnet50_v1_fpn

Il est également possible de repartir de 0 en supprimant le checkpoint et en lancant : 
- python model_main_tf2.py --model_dir=models/my_centernet_resnet50_v1_fpn --pipeline_config_path=models/my_centernet_resnet50_v1_fpn/pipeline.config

## Unity

Pour installer unity, télécharger unity hub ici https://unity3d.com/fr/get-unity/download

Suivez les instruction qui vous son donner et installer la version unity de votre choix

Une fois unity hub installer, vous pouvez importe le projet PFE en cliquant sur la petite fleche à coté de open et en choissisant Add project from disk. Lorsque le projet est importer vous pouvez le lancer et avoir accès aux travaux réaliser.

Le projet PFE dispose de plusieurs scene, chaque scene dispose d'un environnement composé d'obstacles, de murs et d'une voiture. Chaque scène dispose d'un modèle intégré à la voiture.

Pour ouvrir une scène cliquer sur file open scene et choissisez la scene que vous souhaitez. 

Pour montrer que le modèle n'a pas appris sur des obstacle statiques, les obstacles apparaissent aléatoirement dans l'environnement à chaque tentative.

- La scene obstacle_avoidance : dans cette scene la voiture est simplement équipé d'un lidar pour éviter les obstacles qui sont représenter par des cylindres

- La scene obstacle_avoidance_camera : dans cette scène le lidar à été remplacer par une caméra

- La scene obstacle_avoidance_fusion : dans cette scène la voiture dispose d'une camere et d'un lidar, on fusionne les deux capteurs

- La scene test_obstacle_avoidance : Pour ce rapporcher un peu plus de la réalité les cylindre ont été remplacer par un arbres et des personnes. La voiture dispose toujours d'une caméra et d'un lidar.

Pour lancer la simulation sur une scène il suffit juste d'appuyer sur le bouton play en haut de la fenêtre.


