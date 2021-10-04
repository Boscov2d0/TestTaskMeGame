using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalBase {

    public static int PlayerSontrollerType = 1; //1 for keyboad, 2 for keyboard and mouse

    public static bool Pause;
    public static bool UFOIsAlive = false;

    public static int BestScore = 0;
    public static int GamePoints = 0;
    public static int HealsPoints = 3;

    public static int CountOfAsteroids = 2;
    public static int AsteroidsCounter = 2;

    public static Vector3 t = new Vector3();
    public static Vector3 b = new Vector3();
    public static Vector3 l = new Vector3();
    public static Vector3 r = new Vector3();

    public static Vector3 AsteroidPosition = new Vector3();
    public static Vector3 AsteroidRotation = new Vector3();
    public static Vector3 AsteroidDirection = new Vector3();

    public static Vector3 PlayerPosition = new Vector3();
}
