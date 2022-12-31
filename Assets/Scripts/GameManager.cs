using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static string[] wordsArray;
    //[SerializeField]
    public HangmanGame currentGame;

    public static GameManager instance;

    static void NewGame()
    {
        Debug.Log("Starting new game...");
        instance.currentGame = new HangmanGame();
        IHMController.instance.UpdateDisplay(instance.currentGame);
    }
    static void LoadWordList()
    {
        Debug.Log("Importing the word list...");
        //import the list of words stored in our WordList asset, then split it into an array
        TextAsset wordListFile = Resources.Load("WordList") as TextAsset; //could also cast
        wordsArray = wordListFile.text.Split('\n');
    }

    public string GetRandomWord()
    {
        Debug.Log("Generating random word...");
        //generate random number between 0 and max index, and pick the word with that array index
        System.Random RNG = new System.Random();
        int randomNumber = RNG.Next(wordsArray.Length);//picks between 0 and chosen number - 1, so I don't need to adjust for array index (length - 1)
        Debug.Log("Generated : " + wordsArray[randomNumber]);
        return wordsArray[randomNumber];
    }

    void Awake()
    {
        instance = this;
        LoadWordList();
        //string goalWordFancy = GetRandomWord();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        NewGame();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
