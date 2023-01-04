using UnityEngine;
using TMPro;
using UnityEngine.UI;//used for Image

public class LetterButton : MonoBehaviour
{
    public string myLetter;
    [SerializeField]
    Button buttonGameObject;
    [SerializeField]
    TextMeshProUGUI myGUI;
    Color textColorEnabled = Color.white;
    Color textColorDisabled = Color.gray;

    public void Initialize(string getLetter)
    {
        myLetter = getLetter;
        myGUI.text = myLetter;
        myGUI.color = textColorEnabled;
    }

    public void ButtonSetState(bool state) //true: enable, false: disable
    {
        myGUI.color = state ? textColorEnabled : textColorDisabled;
        buttonGameObject.interactable = state;
    }

    //referenced in Unity editor
    void ClickHappens()
    {
        Debug.Log("Click happens: " + myLetter);
        GameManager.instance.currentGame.GuessLetter(myLetter.ToLower());
        ButtonSetState(false);
    }

    void RestartHappens()
    {
        GameManager.instance.RestartHangman();
    }

}