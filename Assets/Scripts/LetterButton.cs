using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;//used for Image
using Unity.VisualScripting;

public class LetterButton : MonoBehaviour
{
    public string myLetter;
    [SerializeField]
    Button homeButton;
    [SerializeField]
    TextMeshProUGUI myGUI;

    public void Initialize(string getLetter)
    {
        myLetter = getLetter;
        myGUI.text = myLetter;
        myGUI.color = Color.white;
    }

    void ClickHappens()
    {
        GameManager.instance.currentGame.GuessLetter(myLetter);
        homeButton.interactable = false;
    }

    void RestartHappens()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}


/*
 *  TextMeshProUGUI myGUI = this.GetComponentInChildren<TextMeshProUGUI>();
        //char sendThis = char.Parse(myGUI.text);
        string sendThis = myGUI.text.ToLower();
        //HangmanLogic logic = GetComponent<HangmanLogic>();
        //logic.Invoke("GuessedLetter", sendThis);
        //Debug.Log("click happens");
        logic = GameObject.Find("HangmanLogic");
        //Oops, apparently SendMessage is void and can't get the bool returned by the function
        logic.SendMessage("GuessLetter", sendThis, SendMessageOptions.RequireReceiver);

        this.GetComponent<Button>().interactable = false;

        //GameObject logic = GameObject.Find("HangmanLogic");
        //logic.GuessLetter(sendThis);
*/