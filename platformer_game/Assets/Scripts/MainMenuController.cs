using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    public GameObject bgCanvas;

    [SerializeField]
    public TMP_InputField inputField;

    [SerializeField]
    public GameObject settingCanvas;

    [SerializeField]
    public GameObject topListCanvas;

    private string OldName;



    public void OpenSetting()
    {
        if (GameController.instanse.isHaveSaving())
        {
            inputField.text = GameController.instanse.playerName;
            OldName = inputField.text;
        }
        bgCanvas.gameObject.SetActive(false);
        settingCanvas.gameObject.SetActive(true);

    }

    public void OpenTopList()
    {
        bgCanvas.gameObject.SetActive(false);
        topListCanvas.gameObject.SetActive(true);

    }

    public void CloseTopList()
    {

        bgCanvas.gameObject.SetActive(true);
        topListCanvas.gameObject.SetActive(false);

    }
    public void LoadLevelPicker()
    {
        if (GameController.instanse.lastPlayerLevel != 0)
        {
            SceneManager.LoadScene(GameController.instanse.lastPlayerLevel + 1);
        }
        else
        {
            SceneManager.LoadScene(1);

        }
    }

    public void GameQuit()
    {
        print("Quit");
        GameController.instanse.SaveGame();
        Application.Quit();
    }
    public void CloseSettings()
    {
        bgCanvas.gameObject.SetActive(true);
        settingCanvas.gameObject.SetActive(false);

    }
    public void ChangeName()
    {

        if (!string.IsNullOrEmpty(GameController.instanse.playerName)
        && !GameController.instanse.playerName.Equals(OldName))
        {
            inputField.text = GameController.instanse.playerName;
        }
        else
        {

            if (inputField.text != "")
            {
                GameController.instanse.ChangePlayerName(inputField.text);
                OldName = inputField.text;
                print("Name " + GameController.instanse.playerName);

            }
            else
            {
                print("Error please enter name ");

            }
        }
    }
}
