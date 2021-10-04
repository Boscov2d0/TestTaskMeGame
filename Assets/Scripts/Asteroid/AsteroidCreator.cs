using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCreator : MonoBehaviour {

    GameObject freeAsteroidsPool;
    GameObject usedAsteroidsPool;

    GameObject asteroid;

    Vector3 directionVector;

    float positionX;
    float positionY;

    [SerializeField] float SpeedMin;
    [SerializeField] float SpeedMax;

    float speed;
    float x;
    float y;
    float z = 0;

    void Awake () {
        freeAsteroidsPool = GameObject.Find("PoolOfFreeAsteroids");
        usedAsteroidsPool = GameObject.Find("PoolOfUsedAsteroids");
    }

    public void CreateAsteroids(GameObject asteroidPref, int counter, string _type)
    {
        for (int i = 0; i < counter; i++)
        {
            foreach (var obj in freeAsteroidsPool.GetComponentsInChildren<Transform>())
            {
                if (obj.name == asteroidPref.name + "(Clone)")
                {
                    asteroid = obj.gameObject;
                    break;
                }
            }

            if (asteroid == null)
            {
                asteroid = Instantiate(asteroidPref);
            }

            switch (_type)
            {
                case "BIG":
                    positionX = Random.Range(Random.Range(GlobalBase.l.x, -3), Random.Range(3, GlobalBase.r.x));
                    positionY = Random.Range(Random.Range(GlobalBase.b.y, -3), Random.Range(3, GlobalBase.t.y));
                    asteroid.transform.position = new Vector3(positionX, positionY, 0);
                    break;
                default:
                    asteroid.transform.position = GlobalBase.AsteroidPosition;
                    asteroid.transform.eulerAngles = GlobalBase.AsteroidRotation;
                    break;
            }

            asteroid.transform.SetParent(usedAsteroidsPool.transform);
            asteroid.GetComponentInChildren<AsteroidMoveController>().enabled = true;
            asteroid.GetComponentInChildren<AsteroidMoveController>().AsteroidAwake();

            //if (i == 0)
            //    asteroid.transform.eulerAngles -= new Vector3(0, 0, 45);
            //else
            //    asteroid.transform.eulerAngles += new Vector3(0, 0, 45);

            //Debug.Log(i + " " + GlobalBase.AsteroidRotation + "   " + asteroid.transform.eulerAngles);

            asteroid = null;
        }
    }

    float SetX()
    {
        return x = Random.Range(-1f, 1f);
    }
    float SetY()
    {
        return y = Random.Range(-1f, 1f);
    }
    float SetSpeed()
    {
        return speed = Random.Range(SpeedMin, SpeedMax);
    }
}
