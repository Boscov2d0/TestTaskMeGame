using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOShootController : MonoBehaviour {

    float timer;

    BulletCreateController BCC;

    void Start () {
        BCC = gameObject.GetComponentInChildren<BulletCreateController>();

        timer = Random.Range(2, 5);
    }
	

	void Update () {
        
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Shoot();
            timer = Random.Range(2, 5);
        }

	}
    void Shoot()
    {
        BCC.CreateBullet(gameObject.tag);
    }
}
