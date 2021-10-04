using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerController : MonoBehaviour {

    PlayerMoveController PlMoveC;
    PlayerMouseController PlMouseC;
    PlayerShootController PlShC;

    GameObject gameController;
    HUDController HUDC;

    void Start () {
        PlMoveC = gameObject.GetComponent<PlayerMoveController>();
        PlMouseC = gameObject.GetComponent<PlayerMouseController>();
        PlShC = gameObject.GetComponent<PlayerShootController>();

        gameController = GameObject.Find("GameController");
        HUDC = gameController.GetComponentInChildren<HUDController>();
    }

    void Update()
    {
        GlobalBase.PlayerPosition = transform.position;

        if (!GlobalBase.Pause)
        {
            if (GlobalBase.PlayerSontrollerType == 1)
            {
                PlMouseC.enabled = false;

                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                {
                    PlMoveC.MoveFront();
                }
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {
                    PlMoveC.MoveLeft();
                }
                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    PlMoveC.MoveRight();
                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    PlShC.Shoot();
                }
            }
            else
            {
                PlMouseC.enabled = true;

                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                {
                    PlMoveC.MoveFront();
                }

                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    PlShC.Shoot();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameController.GetComponentInChildren<GameController>().GamePause();
        }
    }
}
