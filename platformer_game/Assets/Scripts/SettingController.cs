using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SettingController : MonoBehaviour
{
    [SerializeField]
    public GameObject bgCanvas;

    [SerializeField]
    public TMP_InputField inputField;

    [SerializeField]
    public GameObject settingCanvas;

    private string OldName;
    public void OpenSetting()
    {
        bgCanvas.gameObject.SetActive(false);
        settingCanvas.gameObject.SetActive(true);

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
