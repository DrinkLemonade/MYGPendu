using UnityEngine;

public class GameManager : MonoBehaviour
{
    static string[] wordsArray;
    public HangmanGame currentGame;

    public static GameManager instance;
    GameObject[] allLetterButtons;

    static void NewGame()
    {
        Debug.Log("------Starting a game...------");
        instance.currentGame = new HangmanGame(instance);
        IHMController.instance.UpdateDisplay(instance.currentGame);
        IHMController.instance.UpdateSprite(instance.currentGame);
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

    public void RestartHangman()
    {
        Debug.Log("-------RESTARTING------");
        ReactivateKeyboard();
        NewGame();
        IHMController.instance.UpdateDisplay(instance.currentGame);
        IHMController.instance.GameOverText("");
    }

    void ReactivateKeyboard()
    {
        allLetterButtons = GameObject.FindGameObjectsWithTag("LetterButton");
        foreach (GameObject go in allLetterButtons)
        {
            LetterButton script = (LetterButton)go.GetComponent("LetterButton"); //casting from Component to LetterButton
            script.ButtonSetState(true); //enable
        }
    }

    void Awake()
    {
        Debug.Log("GameManager is awake");
        instance = this;
        LoadWordList();
        //string goalWordFancy = GetRandomWord();
    }
    
    void Start()
    {
        Debug.Log("GameManager is starting");
        NewGame();   
    }

}
