using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOCreator : MonoBehaviour {

    GameObject freeUFOPool;
    GameObject usedUFOPool;

    GameObject UFO;

    float speed;
    float x = 0;
    float y;
    float z = 0;

    float positionX;
    float positionY;

    float direction;

    int n;

    void Start () {
        freeUFOPool = GameObject.Find("PoolOfFreeUFO");
        usedUFOPool = GameObject.Find("PoolOfUsedUFO");


    }

    // Update is called once per frame
    void Update () {
		
	}

    public void CreateUFO(GameObject UFOPref)
    {
        speed = (GlobalBase.r.x + GlobalBase.r.x) / 10;

        foreach (var obj in freeUFOPool.GetComponentsInChildren<Transform>())
        {
            if (obj.name == UFOPref.name + "(Clone)")
            {
                UFO = obj.gameObject;
                break;
            }
        }

        if (UFO == null)
        {
            UFO = Instantiate(UFOPref);
        }

        n = Random.Range(0, 2);
        positionY = Random.Range(Random.Range(GlobalBase.l.x, -3), Random.Range(3, GlobalBase.r.x));

        if (n == 0)
        {
            positionX = GlobalBase.b.y + 1f;
            direction = 1;
        }
        else
        {
            positionX = GlobalBase.t.y - 1f;
            direction = -1;
        }

        UFO.transform.SetParent(usedUFOPool.transform);
        UFO.transform.position = new Vector3(positionX, positionY, 0);
        UFO.GetComponentInChildren<Rigidbody>().isKinematic = false;
        UFO.GetComponentInChildren<Rigidbody>().velocity = new Vector3(direction * speed, 0, 0);
        UFO.GetComponent<ObjectsMoveController>().enabled = true;
        UFO = null;
    }

    float SetY()
    {
        return y = Random.Range(-1f, 1f);
    }
}
