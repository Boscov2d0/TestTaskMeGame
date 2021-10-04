using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMoveController : MonoBehaviour
{
    [SerializeField] public string type;

    public Vector3 directionVector;

    [SerializeField] float SpeedMin;
    [SerializeField] float SpeedMax;

    float speed;
    float x;
    float y;
    float z = 0;

    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void AsteroidAwake()
    {
        rb.isKinematic = false;

        //if (type == "BIG")
        //    directionVector = new Vector3(SetX() * SetSpeed(), SetY() * SetSpeed(), z);
        //else
        //    directionVector = GlobalBase.FAsteroidDirection;

        directionVector = new Vector3(SetX() * SetSpeed(), SetY() * SetSpeed(), z);
        rb.AddForce(directionVector);

        gameObject.GetComponent<ObjectsMoveController>().enabled = true;
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
