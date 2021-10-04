using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCreateController : MonoBehaviour {

    [SerializeField] float speed;
    public GameObject BulletPrefab;

    [SerializeField] GameObject shootPoint;

    GameObject bullet;
    GameObject freeBulletsPool;
    GameObject usedBulletsPool;

    Rigidbody rb;
        
    void Start () {
        freeBulletsPool = GameObject.Find("PoolOfFreeBullets");
        usedBulletsPool = GameObject.Find("PoolOfUsedBullets");
    }

    public void CreateBullet(string type)
    {
        if (freeBulletsPool.transform.childCount <= 0)
        {
            bullet = Instantiate(BulletPrefab);
        }
        else
        {
            foreach (var obj in freeBulletsPool.GetComponentsInChildren<Transform>())
            {
                if (type == "Player")
                {
                    if (obj.name == "AllyBulletPref(Clone)")
                    {
                        bullet = obj.gameObject;
                        break;
                    }
                }
                else
                {
                    if (obj.name == "EnemyBulletPref(Clone)")
                    {
                        bullet = obj.gameObject;
                        break;
                    }
                }
            }
            if (bullet == null)
            {
                bullet = Instantiate(BulletPrefab);
            }
        }

        bullet.GetComponentInChildren<BulletDeathController>().enabled = true; //выключали контроллер, чтобы он перестал просчитывать жизненный путь
        bullet.GetComponent<ObjectsMoveController>().enabled = true;
        bullet.transform.position = shootPoint.transform.position;
        bullet.transform.SetParent(usedBulletsPool.transform);
        rb = bullet.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        if (gameObject.tag == "Player")
        {
            rb.velocity = transform.up * speed;
        }
        else
        {
            if (GlobalBase.PlayerPosition.y - transform.position.y > 0)
            {
                rb.velocity = new Vector3(Random.Range(-1, 2), 1, 0) * speed;
            }
            else
            {
                rb.velocity = new Vector3(Random.Range(-1, 2), -1, 0) * speed;
            }
        }

        bullet.GetComponentInChildren<AudioSource>().Play();

        bullet = null;
    }
}
