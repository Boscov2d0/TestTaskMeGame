using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseController : MonoBehaviour {

    [SerializeField] float speedOfRotation;

    Vector2 currentDirection = new Vector3(0.0f, 1.0f, 0.0f);
    Transform transformObject;

    void Start () {
        transformObject = this.transform;
    }
	
	void Update () {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 objectsPos = transform.position;

        Vector2 direction = mousePos - objectsPos;
        direction.Normalize();

        currentDirection = Vector2.Lerp(currentDirection, direction, Time.deltaTime * speedOfRotation);
        transformObject.up = currentDirection;
    }
}
