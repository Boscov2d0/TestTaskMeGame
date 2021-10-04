using UnityEngine;

public class PlayerDeathAnim : MonoBehaviour {

    float timer;
    int count;

    Transform body;

	void Start () {
        body = transform.Find("Body");
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 1)
        {
            body.gameObject.SetActive(true);
        }
        if (timer >= 2)
        {
            body.gameObject.SetActive(false);
            count++;
            timer = 0;
        }

        if (count == 3)
        {
            body.gameObject.SetActive(true);
            GetComponentInChildren<PlayerDeathController>().SwithOnColl();
            count = 0;
            GetComponentInChildren<PlayerDeathAnim>().enabled = false;
        }
    }
}
