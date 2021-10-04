using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFODeathController : MonoBehaviour {

    GameObject freeUFOPool;

    GameController GameController;

    void Awake ()
    {
        freeUFOPool = GameObject.Find("PoolOfFreeUFO");

        GameController = GameObject.Find("GameController").GetComponentInChildren<GameController>();
    }
	
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            DestroyUFO();
            GameController.RecalculateGP(250);
        }
        if (coll.gameObject.tag == "Player" || coll.gameObject.tag == "Enemy")
        {
            DestroyUFO();
        }
    }
    void DestroyUFO()
    {
        GetComponentInChildren<AudioSource>().Play();

        GlobalBase.UFOIsAlive = false;

        //Move object to pool of asteroids
        gameObject.transform.SetParent(freeUFOPool.transform);
        gameObject.GetComponent<ObjectsMoveController>().enabled = false;
        gameObject.transform.position = freeUFOPool.transform.position;
        //Off objects movement
        //gameObject.GetComponentInChildren<AsteroidMoveController>().enabled = false;
        gameObject.GetComponentInChildren<Rigidbody>().isKinematic = true;
    }
}
