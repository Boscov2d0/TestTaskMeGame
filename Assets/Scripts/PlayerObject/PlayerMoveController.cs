using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour {

    [SerializeField] float ZAngle;
    [SerializeField] float speed;
    [SerializeField] float maxSpeed;

    Rigidbody rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {

    }
    public void MoveLeft()
    {
        transform.Rotate(0, 0, ZAngle);
    }
    public void MoveRight()
    {
        transform.Rotate(0, 0, -ZAngle);
    }
    public void MoveFront()
    {
        //if (rb.velocity.x <= maxSpeed && rb.velocity.y <= maxSpeed)
        // rb.AddForce(transform.up * speed, ForceMode.Impulse);
        rb.velocity = transform.up * speed;
    }
}
