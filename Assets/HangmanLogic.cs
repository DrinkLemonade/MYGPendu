using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements; //used for keystroke events
using System.Text; //used by StringBuilder
using System.Text.RegularExpressions; //I have SOME regex knowledge, is it overkill? yes.

//TODO: Fix.
/*
static string RemoveDiacritics(this string text)
{
    if (string.IsNullOrWhiteSpace(text))
        return text;

    text = text.Normalize(NormalizationForm.FormD);
    var chars = text.Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark).ToArray();
    return new string(chars).Normalize(NormalizationForm.FormC);
}*/

public class HangmanLogic : MonoBehaviour
{
    string goalWord = "";
    string goalWordFancy = ""; //includes diacritics and uppercase    
    string knownWord = "";      

    const int maxTriesLeft = 6;
    int currentTriesLeft = maxTriesLeft;

    void Start()
    {
        // Import the list of words stored in our WordList asset, then split it into an array
        TextAsset wordListFile = Resources.Load("WordList") as TextAsset;
        string[] wordsArray = wordListFile.text.Split('\n');

        // Generate random number between 0 and max index, and pick the word with that array index
        System.Random RNG = new System.Random();
        int randomNumber = RNG.Next(wordsArray.Length);//Picks between 0 and chosen number - 1, so I don't need to adjust for array index (length - 1)
        goalWordFancy = wordsArray[randomNumber];
        goalWord = RemoveDiacritics(goalWordFancy.ToLower());

        // Regex: Replace all A-Z and a-z in word with ?. This leaves - intact.
        knownWord = Regex.Replace(goalWord,"[A-Za-z]","?");

        Debug.Log("Goal is: " + goalWord);
        Debug.Log("Displayed as: " + knownWord);
    }

    //From https://www.levibotelho.com/development/c-remove-diacritics-accents-from-a-string/
    public static string RemoveDiacritics(string text)//String has an issue: Extension method must be defined in a non-generic static class
    {
        if (string.IsNullOrWhiteSpace(text))
            return text;

        text = text.Normalize(NormalizationForm.FormD);
        var chars = text.Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark).ToArray();
        return new string(chars).Normalize(NormalizationForm.FormC);
    }

    void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey)
        {
            //Is this a letter?
            if (e.type == EventType.KeyDown && e.keyCode.ToString().Length == 1 && char.IsLetter(e.keyCode.ToString()[0]))
            {
                //Actual letter
                string tempString = e.keyCode.ToString().ToLower();//Convert all to lowercase
                char guessedLetter = char.Parse(tempString);
                
                Debug.Log("Letter detected: " + guessedLetter.ToString());
                if (goalWord.Contains(guessedLetter.ToString()))
                {
                    Debug.Log("Hey, that's in the word!");
                    //Iterate through goalWord to reveal that letter's instances in knownWord
                    for (int i = 1; i < goalWord.Length; i++)
                    {   
                        //Lesson learned, chars and strings must be compared properly
                        //TODO: Which one is the string again...?
                        if (goalWord[i-1] == guessedLetter) //If the letter exists at this position, put it in knownWord too
                        {
                            //I want something like, after guessing O in Potato, ?????? changes to ?O???O
                            //Strings are read only, so I can't just change the guessed letter like that
                            //I need to use, say, this StringBuilder thing.
                            StringBuilder sb = new StringBuilder(knownWord);
                            sb[i-1] = guessedLetter;
                            knownWord = sb.ToString();
                        }
                    }
                    Debug.Log("New known word: " + knownWord);
                    if (knownWord() == goalWord())
                    {
                        Debug.Log("Victory! That was the word: " + goalWordFancy);
                    }
                }
                else
                {
                    currentTriesLeft--;
                    if (currentTriesLeft == 0)
                    {
                        Debug.Log("No, that's not in the word. GAME OVER. The word was: " + goalWord);
                    }
                    else
                    {
                        Debug.Log("No, that's not in the word. You have " + currentTriesLeft + " tries left.");
                    }
                    
                }
            }
        }
    }
}

/*

    //Constructor
    public HangmanLogic()
    {        
    }

    // Start is called before the first frame update
    void Start()
    {
        
        //Player's knowledge of word to guess so far. If the word is "Potato" (6 letters), at the start this will display "??????" (6 question marks)
        


        

        
    }

    // Update is called once per frame
    void Update()
    {
    }

    
    
*/