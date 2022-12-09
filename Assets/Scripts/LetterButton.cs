using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;//used for Image

public class LetterButton : MonoBehaviour
{

    public GameObject logic;

    void Awake()
    {
        logic = GameObject.Find("HangmanLogic");
        //wasInWord = false;//1 for letters that were in the word, 2 for letters that weren't
        //if (logic == null) Debug.Log("NULL???");
        //else Debug.Log("not null");
    }

    void ClickHappens()
    {
        TextMeshProUGUI myGUI = this.GetComponentInChildren<TextMeshProUGUI>();
        //char sendThis = char.Parse(myGUI.text);
        string sendThis = myGUI.text.ToLower();
        //HangmanLogic logic = GetComponent<HangmanLogic>();
        //logic.Invoke("GuessedLetter", sendThis);
        Debug.Log("click happens");
        logic = GameObject.Find("HangmanLogic");
        //Oops, apparently SendMessage is void and can't get the bool returned by the function
        logic.SendMessage("GuessLetter", sendThis, SendMessageOptions.RequireReceiver);

        this.GetComponent<Button>().interactable = false;

        //GameObject logic = GameObject.Find("HangmanLogic");
        //logic.GuessLetter(sendThis);
    }

    void RestartHappens()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
