using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour {

    public GameObject[] HealthIcon;

    GameObject gamePoint;
    GameObject bestScore;

    GameObject menuPanel;
    GameObject gameOverPanel;

    void Start () {
        gamePoint = GameObject.Find("PointsText");
        bestScore = GameObject.Find("BestScore");

        menuPanel = GameObject.Find("MainMenuPanel");
        gameOverPanel = GameObject.Find("GameOverPanel");

        menuPanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }
	
	void Update () {
        gamePoint.GetComponentInChildren<Text>().text = GlobalBase.GamePoints.ToString();
        bestScore.GetComponentInChildren<Text>().text = GlobalBase.BestScore.ToString();
    }

    public void HealthRecalculation()
    {
        HealthIcon[GlobalBase.HealsPoints].SetActive(false);
    }

    public void GameOverActivate()
    {
        gameOverPanel.SetActive(true);
    }

    public void OpenCloseMenu()
    {
        if (GlobalBase.Pause)
        {
            menuPanel.SetActive(true);
        }
        else
        {
            menuPanel.SetActive(false);
        }
    }
}
