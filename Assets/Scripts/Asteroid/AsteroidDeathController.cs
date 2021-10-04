using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDeathController : MonoBehaviour
{
    GameObject freeAsteroidsPool;
    GameController GameController;

    Vector3 startPosition;
    Vector3 finishPosition;

    void Awake()
    {
        freeAsteroidsPool = GameObject.Find("PoolOfFreeAsteroids");

        GameController = GameObject.Find("GameController").GetComponentInChildren<GameController>();
        startPosition = transform.position;
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            DestroyAstroid();
            GameController.CheckAsteroidsSize(GetComponentInChildren<AsteroidMoveController>().type);
            
        }
        if (coll.gameObject.tag == "Player" || coll.gameObject.tag == "UFO")
        {
            DestroyAstroid();
        }
    }

    void DestroyAstroid()
    {
        GetComponentInChildren<AudioSource>().Play();

        GlobalBase.AsteroidPosition = gameObject.transform.position;
        GlobalBase.AsteroidRotation = gameObject.transform.eulerAngles;
        GlobalBase.AsteroidDirection = GetComponentInChildren<AsteroidMoveController>().directionVector;

        //Move object to pool of asteroids
        gameObject.transform.SetParent(freeAsteroidsPool.transform);
        gameObject.GetComponent<ObjectsMoveController>().enabled = false;
        gameObject.transform.position = freeAsteroidsPool.transform.position;
        //Off objects movement
        gameObject.GetComponentInChildren<AsteroidMoveController>().enabled = false;
        gameObject.GetComponentInChildren<Rigidbody>().isKinematic = true;
    }
}
