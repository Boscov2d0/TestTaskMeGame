using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDeathController : MonoBehaviour {

    [SerializeField] string objectTag;
    GameObject freeBulletsPool;

    Vector3 startPosition;
    float sumX = 0;
    float sumY = 0;

    void Start()
    {
        startPosition = transform.position;

        freeBulletsPool = GameObject.Find("PoolOfFreeBullets");
    }
    void Update()
    {
        CheckPathByX();
        CheckPathByY();

        if (sumX >= (int)(GlobalBase.r.x - GlobalBase.l.x) || sumY >= (int)(GlobalBase.t.y - GlobalBase.b.y))
        {
            DestroyBullet();
        }
    }
    void CheckPathByX()
    {
        if (Mathf.Abs((int)transform.position.x) - Mathf.Abs((int)startPosition.x) == 1 || Mathf.Abs((int)transform.position.x) - Mathf.Abs((int)startPosition.x) == -1)
        {
            ++sumX;
            startPosition.x = (int)transform.position.x;
        }

        if (transform.position.x <= GlobalBase.l.x)
        {
            startPosition.x = (int)GlobalBase.r.x;
        }
        if (transform.position.x >= GlobalBase.r.x)
        {
            startPosition.x = (int)GlobalBase.l.x;
        }
    }
    void CheckPathByY()
    {
        if (Mathf.Abs((int)transform.position.y) - Mathf.Abs((int)startPosition.y) == 1 || Mathf.Abs((int)transform.position.y) - Mathf.Abs((int)startPosition.y) == -1)
        {
            ++sumY;
            startPosition.y = (int)transform.position.y;
        }

        if (transform.position.x <= GlobalBase.b.y)
        {
            startPosition.y = (int)GlobalBase.t.y;
        }
        if (transform.position.x >= GlobalBase.t.y)
        {
            startPosition.y = (int)GlobalBase.b.y;
        }
    }
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == objectTag)
        {
            DestroyBullet();
        }
    }
    void DestroyBullet()
    {
        sumX = 0;
        sumY = 0;
        transform.SetParent(freeBulletsPool.transform);
        transform.position = freeBulletsPool.transform.position;
        transform.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.GetComponent<ObjectsMoveController>().enabled = false;
        gameObject.GetComponentInChildren<BulletDeathController>().enabled = false; //switch pff controller to stop read life path
    }
}
