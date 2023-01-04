using UnityEngine;
using System.Text; //used by StringBuilder
using System.Text.RegularExpressions; //is regex overkill? yes. do I have SOME regex knowledge I want to use anyway? also yes.S

[System.Serializable]
public class HangmanGame
{
    string goalWord = "";
    string goalWordFancy = ""; //includes diacritics and uppercase    
    public string knownWord = "";
    public GameManager myManager;

    const int maxTriesLeft = 6;
    int currentTriesLeft;

    public HangmanGame(GameManager passManager) //constructor. automatically returns HangmanLogic instance
    {
        myManager = passManager;
        Debug.Log("Starting a hangman session...");
        goalWordFancy = GameManager.instance.GetRandomWord();
        InitializeNormalizedWord();
        InitalizeKnownWord();
        currentTriesLeft = maxTriesLeft;
    }

    public int SpriteVersion
    {
        get { return maxTriesLeft - currentTriesLeft; }
        //set { spriteVersionTest = value; }
    }

    void InitializeNormalizedWord()
    {
        //regex: we're essentially "normalizing" the word by brute force.
        goalWord = goalWordFancy.ToLower();
        goalWord = Regex.Replace(goalWord, "[àáâãäå]", "a");
        goalWord = Regex.Replace(goalWord, "æ", "ae");
        goalWord = Regex.Replace(goalWord, "ç", "c");
        goalWord = Regex.Replace(goalWord, "[èéêë]", "e");
        goalWord = Regex.Replace(goalWord, "[ìíîï]", "i");
        goalWord = Regex.Replace(goalWord, "ñ", "n");
        goalWord = Regex.Replace(goalWord, "[òóôõö]", "o");
        goalWord = Regex.Replace(goalWord, "œ", "oe");
        goalWord = Regex.Replace(goalWord, "[ùúûü]", "u");
        goalWord = Regex.Replace(goalWord, "[ýÿ]", "y");
    }

    void InitalizeKnownWord()
    {
        //regex: Replace all A-Z and a-z in word with ?. this leaves - intact.
        knownWord = Regex.Replace(goalWord, "[A-Za-z]", "?");

        Debug.Log("Goal is: " + goalWord + " (" + goalWordFancy + ")");
        Debug.Log("Hidden as: " + knownWord);
    }

    public bool GuessLetter(string stringLetter)
    {
        //returns a boolean I was intending to use to color a letterButton red or green if the guess was correct or not
        //but using sendMessage to trigger a function doesn't return what the function returns so this was too much work
        //so the boolean is unused right now

        //string str = "A";
        //char character = char.Parse(str);
        //char[] tempArray = stringLetter.ToCharArray();

        Debug.Log("Letter detected: " + stringLetter);

        char guessedLetter = stringLetter[0];
        //originally I was taking keystrokes as input and directly converting them to char
        //so this is kinda left over

        if (goalWord.Contains(guessedLetter.ToString()))
        {
            Debug.Log("Hey, that's in the word!");
            //iterate through goalWord to reveal that letter's instances in knownWord
            for (int i = 1; i < goalWord.Length; i++)
            {
                //lesson learned, chars and strings must be compared properly
                if (goalWord[i - 1] == guessedLetter) //If the letter exists at this position, put it in knownWord too
                {
                    //I want something like, after guessing O in Potato, ?????? changes to ?O???O
                    //strings are read only, so I can't just change the guessed letter like that
                    //I need to use, say, this StringBuilder thing.
                    StringBuilder sb = new StringBuilder(knownWord);
                    sb[i - 1] = guessedLetter;
                    knownWord = sb.ToString();
                }
            }
            Debug.Log("New known word: " + knownWord);
            if (knownWord == goalWord)
            {
                IHMController.instance.GameOverText("Bravo ! Le mot était bien : " + goalWordFancy);
            }
            //This - currentGame - est une instance de HangmanLogic
            IHMController.instance.UpdateDisplay(this);
            return true;
        }
        else
        {
            currentTriesLeft--;
            IHMController.instance.UpdateSprite(this);

            if (currentTriesLeft == 0)
            {
                IHMController.instance.GameOverText("Perdu ! Le mot était : " + goalWordFancy);
            }

            Debug.Log("No, that's not in the word. You have " + currentTriesLeft + " tries left.");
            return false;
        }
    }

    //below: I was originally detecting keystrokes instead of having a visual keyboard
    //this doesn't play nice with the "disable button once the letter has been tried" requirement though
    //so I disabled it

    /*void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey)
        {
            //Is this a letter?
            if (e.type == EventType.KeyDown && e.keyCode.ToString().Length == 1 && char.IsLetter(e.keyCode.ToString()[0]))
            {
                //Actual letter
                string tempString = e.keyCode.ToString().ToLower();//Convert all to lowercase
                //char guessedLetter = char.Parse(tempString);
                GuessLetter(tempString);
            }
        }
    }*/
}