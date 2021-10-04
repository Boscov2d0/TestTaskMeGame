using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootController : MonoBehaviour {


    [SerializeField] float timeToReloat;
    [SerializeField] int shootCount;
    int countOfShoot;

    bool canShoot;

    BulletCreateController BCC;

    void Start()
    {
        canShoot = true;
        countOfShoot = shootCount;

        BCC = gameObject.GetComponentInChildren<BulletCreateController>();
    }

    public void Shoot()
    {
        if (canShoot)
        {
            canShoot = false;
            NextShoot();
            BCC.CreateBullet(gameObject.tag);
        }
    }
    void NextShoot()
    {
        if (canShoot)
        {
            countOfShoot = shootCount;
            return;
        }
        else
        {
            StartCoroutine(CoroutineShoot());
        }
    }

    IEnumerator CoroutineShoot()
    {
        yield return new WaitForSeconds(0.3f);

        if (countOfShoot > 0)
        {
            countOfShoot--;
            BCC.CreateBullet(gameObject.tag);
            NextShoot();
        }
        else
        {
            yield return new WaitForSeconds(timeToReloat);
            canShoot = true;
            NextShoot();
            yield break;
        }
    }
}
