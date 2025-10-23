Lab 10
=====

> Melanie Galindo Waugh

I used the 2D Shooting game from lab 9 as a base. I added saving and loading using LitJSON. Implemented with ISaveable interface and TransformSaver class to handle the save. EnemySpawner was modified to implement the ISaveable interface. I used the SaveManager class from my Professor and modified it to save the score in a binary file. The game is saved with 'S' and loaded with 'L'. The state is saved in savefile.json and the score is saved in savefile.json.dat.

