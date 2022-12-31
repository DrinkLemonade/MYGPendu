// Generates 26 letter buttons.

using UnityEngine;
using System.Collections;
using TMPro;

public class VirtualKeyboard : MonoBehaviour
{
    string[] alphabet = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
    int buttonSize = 45;
    int startX = 0;
    int startY = -50;
    int xOffset = 0;
    int yOffset = 0;

    public GameObject myButton; //instance to create
    public GameObject LetterButton; //prefab
    public Vector3 location = new Vector3(0, 0, 0); //where we want the instance

    void Start()
    {
        InitializeKeyboard();
    }

    void InitializeKeyboard()
    {
        for (int i = 0; i < alphabet.Length; i++)
        {

            GameObject buttonInstance;
            //instantiate
            buttonInstance = Instantiate(LetterButton, location, Quaternion.identity) as GameObject;
            buttonInstance.transform.SetParent(GameObject.Find("Canvas").transform, false);
            buttonInstance.transform.localPosition = new Vector3(startX + (xOffset * buttonSize) - ((26 / 4) * buttonSize), startY + (yOffset * buttonSize), 0);
            buttonInstance.transform.localScale = new Vector3(1, 1, 0); // change its local scale in x y z format

            //set button size
            RectTransform myRect = buttonInstance.GetComponent<RectTransform>();
            myRect.sizeDelta = new Vector2(buttonSize, buttonSize);

            LetterButton buttonController = buttonInstance.GetComponent<LetterButton>();
            buttonController.Initialize(alphabet[i]);

            xOffset++;

            if (i == 12) //new line of keys
            {
                xOffset = 0;
                yOffset--;
            }
        }
    }
}