# PFE-evitement-obstacle

Ce projet a pour but de développer une solution d'évitement d'obstacle pour la conduite autonome sur une zoé équipéé de caméras, d'un lidar et d'un GPS.

Mon travail se décompose en 2 parties : 

## Object detection 
Cette partie permet en utilisant l'API object detection de tensorflow de détecter les différents objets présents sur les routes comme les voitures,camions,vélos ...

Cette partie object detection ce trouve dans le dossier TensorFlow.

Pour commencer il faut installer l'API pour ce faire le notebook object_detection_pre_train_model présent dans le dossier TensorFlow permet d'installer l'API et les dépendances nécessaires mais également de tester si l'API est bien installée en récupérant un modèle pré-entrainer et en testant ce modèle avec les images présentent dans test_images. 
Si vous souhaitez tester le modèle sur d'autre images il suffit d'ajouter des images dans le dossier TensorFlow/test_images.

Dans le dossier workspace on retrouve tout ce qui est nécessaire pour ré entrainer un modèle. 
Ce dossier comprend des images annotées dans le dossier "images", des images de tests dans "test_images", un fichier contenant les labels utilisés dans "annotations" et le modèle réentrainer dans "exported-models".

Pour ajouter des images, d'autre labels et réentraîner un modèle pré-entraîner vous pouvez suivre ce tutoriel https://tensorflow-object-detection-api-tutorial.readthedocs.io/en/latest/training.html tout y est détaillé. 

Si vous voulez simplement ré entrainer le modèle avec les images présentes et à partir du checkpoint du dossier : 

- Déplacez-vous dans le dossier Tensorflow/workspace/training_demo 
- Lancer python model_main_tf2.py --model_dir=models/my_centernet_resnet50_v1_fpn --pipeline_config_path=models/my_centernet_resnet50_v1_fpn/pipeline.config --checkpoint_dir=models/my_centernet_resnet50_v1_fpn

Il est également possible de repartir de 0 en supprimant le checkpoint et en lançant : 
- python model_main_tf2.py --model_dir=models/my_centernet_resnet50_v1_fpn --pipeline_config_path=models/my_centernet_resnet50_v1_fpn/pipeline.config

Un notebook nommé Object_detection est également présent dans TensorFlow/workspace/training_demo/.
Ce notebook permet de tester le modèle réentrainer contenu dans TensorFlow/workspace/training_demo/exported-models


## Unity

Pour installer unity, télécharger unity hub ici https://unity3d.com/fr/get-unity/download

Suivez les instructions qui vous sont données et installer la version unity de votre choix

Une fois unity hub installer, vous pouvez importer le dossier PFE en cliquant sur la petite fleche à coté de open et en choisissant Add project from disk. Lorsque le projet est importé vous pouvez le lancer et avoir accès aux travaux réaliser.

Le projet PFE dispose de plusieurs scènes stockées dans PFE/Assets, chaque scène dispose d'un environnement composé d'obstacles, de murs et d'une voiture. 

Chaque scène dispose d'un modèle intégré à la voiture.

Pour ouvrir une scène cliquées sur file open scene et choisissez la scène que vous souhaitez. 

Pour montrer que le modèle n'a pas appris sur des obstacles statiques, les obstacles apparaissent aléatoirement dans l'environnement à chaque tentative.

- La scène obstacle_avoidance : dans cette scène la voiture est simplement équipée d'un lidar pour éviter les obstacles qui sont représentés par des cylindres. Le modèle de cette scène se trouve dans PFE/Assets/results/Obstacle_avoidance1/Obstacle_avoidance

- La scène obstacle_avoidance_camera : dans cette scène le lidar à été remplacé par une caméra. Le modèle de cette scène se trouve dans PFE/Assets/results/Obstacle_avoidance_camera/Obstacle_avoidance

- La scène obstacle_avoidance_fusion : dans cette scène la voiture dispose d'une camera et d'un lidar, on fusionne les deux capteurs. Le modèle de cette scène ce trouve dans PFE/Assets/results/Obstacle_avoidance_fusion/Obstacle_avoidance

- La scène test_obstacle_avoidance : Pour se rapprocher un peu plus de la réalité les cylindre ont été remplacés par un arbre et des personnes. La voiture dispose toujours d'une caméra et d'un lidar. Le modèle de cette scène se trouve dans PFE/Assets/results/Obstacle_avoidance_fusion2/Obstacle_avoidance

Pour lancer la simulation sur une scène il suffit juste d'appuyer sur le bouton play en haut de la fenêtre.

Dans le dossier PFE on retrouve également d'autres dossier comme EasyRoads3D,Arcade-FREE-Racing Car, laxer tree pkg, ToonyTinyPeople et ML-agents qui sont les librairies utilisées dans le projet. Il y a aussi Obstacle_avoidance.cs qui est le script utilisé dans la simulation pour faire bouger la voiture et permettre à l'agent d'apprendre.


