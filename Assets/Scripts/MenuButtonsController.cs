using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtonsController : MonoBehaviour {

    [SerializeField] GameObject continueGameButton;
    [SerializeField] GameObject switchContolButton;

    bool controlIsKeyboard = true;

    void Update()
    {
        if (!GlobalBase.Pause)
        {
            continueGameButton.GetComponentInChildren<Button>().interactable = false;
        }
        else
        {
            continueGameButton.GetComponentInChildren<Button>().interactable = true;
        }
    }

    public void ContinueGameButton()
    {
        gameObject.GetComponentInChildren<GameController>().GamePause();
    }

    public void NewGameButton()
    {
        SceneManager.LoadScene(1);
        gameObject.GetComponentInChildren<GameController>().GamePause();
        GlobalBase.GamePoints = 0;
    }
    public void StartGameButton()
    {
        SceneManager.LoadScene(1);
    }

    public void SwitchControllerButton()
    {
        if (controlIsKeyboard)
        {
            GlobalBase.PlayerSontrollerType = 1;
            switchContolButton.GetComponentInChildren<Text>().text = "Управление: клавиатура";
            controlIsKeyboard = false;
        }
        else
        {
            GlobalBase.PlayerSontrollerType = 2;
            switchContolButton.GetComponentInChildren<Text>().text = "Управление: клавиатура + мышь";
            controlIsKeyboard = true;
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}
