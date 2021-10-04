using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject BigAsteroidPref;
    public GameObject MiddleAsteroidPref;
    public GameObject LittleAsteroidPref;

    public GameObject UFOPref;

    [SerializeField] int gamePointsForBigAster;
    [SerializeField] int gamePointsForMidAster;
    [SerializeField] int gamePointsForLitAster;

    [SerializeField] int CountOfAsteroidsForStart;

    [SerializeField] float timerMinForCreateUFO;
    [SerializeField] float timerMaxForCreateUFO;

    [SerializeField] float timerForCreateAsteroids;

    float timerForUFO;

    Camera cam;

    GameObject player;

    GameObject usedAsteroidsPool;

    HUDController HUDC;
    AsteroidCreator AC;
    UFOCreator UFOC;

    void Start()
    {
        HUDC = gameObject.GetComponentInChildren<HUDController>();
        AC = gameObject.GetComponentInChildren<AsteroidCreator>();
        UFOC = gameObject.GetComponentInChildren<UFOCreator>();

        player = GameObject.Find("Player");

        cam = Camera.main;

        usedAsteroidsPool = GameObject.Find("PoolOfUsedAsteroids");

        GlobalBase.t = cam.ScreenToWorldPoint(new Vector3((cam.pixelWidth / 2), cam.pixelHeight + 4, 0));
        GlobalBase.b = cam.ScreenToWorldPoint(new Vector3((cam.pixelWidth / 2), -4, 0));
        GlobalBase.l = cam.ScreenToWorldPoint(new Vector3(-4, (cam.pixelHeight / 2), 0));
        GlobalBase.r = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth + 4, (cam.pixelHeight / 2), 0));

        AC.CreateAsteroids(BigAsteroidPref, CountOfAsteroidsForStart, "BIG");

        timerForUFO = Random.Range(timerMinForCreateUFO, timerMaxForCreateUFO);
    }

    void FixedUpdate()
    {
        if (GlobalBase.HealsPoints == 0)
        {
            GameOver();
        }

        if (usedAsteroidsPool.transform.childCount <= 0)
        {
            timerForCreateAsteroids -= Time.deltaTime;
            if (timerForCreateAsteroids <= 0)
            {
                GlobalBase.AsteroidsCounter++;
                AC.CreateAsteroids(BigAsteroidPref, GlobalBase.AsteroidsCounter, "BIG");
                timerForUFO = Random.Range(timerMinForCreateUFO, timerMaxForCreateUFO);
            }
        }

        if (GlobalBase.UFOIsAlive == false)
        {
            timerForUFO -= Time.deltaTime;
            if (timerForUFO <= 0)
            {
                UFOC.CreateUFO(UFOPref);
                timerForUFO = Random.Range(timerMinForCreateUFO, timerMaxForCreateUFO); ;
                GlobalBase.UFOIsAlive = true;
            }
        }
    }
    
    public void CheckAsteroidsSize(string typeOfAster)
    {
        switch (typeOfAster)
        {
            case "BIG":
                AC.CreateAsteroids(MiddleAsteroidPref, 2, "MID");
                RecalculateGP(gamePointsForBigAster);
                break;
            case "MID":
                AC.CreateAsteroids(LittleAsteroidPref, 2, "LIT");
                RecalculateGP(gamePointsForMidAster);
                break;
            case "LIT":
                RecalculateGP(gamePointsForLitAster);
                break;
        }
    }
    public void RecalculateGP(int GP)
    {
        GlobalBase.GamePoints += GP;
    }
    void GameOver()
    {
        GlobalBase.BestScore = GlobalBase.GamePoints;
        GetComponentInChildren<BestCsoreSaver>().SaveBestScore();
        player.SetActive(false);
        HUDC.GameOverActivate();
        Time.timeScale = 0;
    }
    public void HealthRecalculation()
    {
        --GlobalBase.HealsPoints;
        HUDC.HealthRecalculation();
    }
    public void GamePause()
    {
        if (!GlobalBase.Pause)
        {
            GlobalBase.Pause = true;
            Time.timeScale = 0;
            HUDC.OpenCloseMenu();
        }
        else
        {
            GlobalBase.Pause = false;
            Time.timeScale = 1;
            HUDC.OpenCloseMenu();
        }
    }
}
