using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsMoveController : MonoBehaviour {

    Vector3 objectPosition = new Vector3();

	void Update () {
        objectPosition = gameObject.transform.position;

        if (objectPosition.x > GlobalBase.r.x)
        {
            gameObject.transform.position = new Vector3(GlobalBase.l.x, objectPosition.y, 0);
        }
        if (objectPosition.x < GlobalBase.l.x)
        {
            gameObject.transform.position = new Vector3(GlobalBase.r.x - 0.3f, objectPosition.y, 0);
        }
        if (objectPosition.y >= GlobalBase.t.y)
        {
            gameObject.transform.position = new Vector3(objectPosition.x, GlobalBase.b.y, 0);
        }
        if (objectPosition.y <= GlobalBase.b.y)
        {
            gameObject.transform.position = new Vector3(objectPosition.x, GlobalBase.t.y, 0);
        }
    }
}
