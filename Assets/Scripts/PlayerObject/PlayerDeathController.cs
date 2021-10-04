using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathController : MonoBehaviour {

    GameObject gameController;

    void Start () {
        gameController = GameObject.Find("GameController");
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "UFO")
        {
            GetComponentInChildren<AudioSource>().Play();

            Restart();
        }
    }

    void Restart()
    {
        GetComponentInChildren<AudioSource>().Play();

        gameController.GetComponentInChildren<GameController>().HealthRecalculation();

        transform.Find("Body").gameObject.SetActive(false);

        GetComponent<SphereCollider>().enabled = false;

        GetComponent<Rigidbody>().isKinematic = true;

        transform.position = new Vector3(0,0,0);
        transform.rotation = Quaternion.identity;

        GetComponentInChildren<PlayerDeathAnim>().enabled = true;

        GetComponent<Rigidbody>().isKinematic = false;
    }

    public void SwithOnColl()
    {
        GetComponent<SphereCollider>().enabled = true;

        //GetComponent<Rigidbody>().isKinematic = false; //swith on if dont need movement while restart
    }
}
