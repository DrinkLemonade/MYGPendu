// Draws 2 buttons, one with an image, and other with a text
// And print a message when they got clicked.

using UnityEngine;
using System.Collections;
using TMPro;

public class VirtualKeyboard : MonoBehaviour
{
    string[] alphabet = {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"};
    int buttonSize = 45;
    int startX = 0;
    int startY = -50;
    int xOffset = 0;
    int yOffset = 0;

    public GameObject myButton;
    public GameObject LetterButton; //prefab
    public Vector3 location = new Vector3(0, 0, 0); //where I want the instance
    
    void Start()
    {
        for(int i = 0; i < 26; i++)
        {
        myButton = Instantiate(LetterButton, location, Quaternion.identity) as GameObject;
        myButton.transform.SetParent(GameObject.Find("Canvas").transform,false);
        myButton.transform.localPosition = new Vector3(startX+(xOffset*buttonSize)-((26/4)*buttonSize), startY+(yOffset*buttonSize), 0);
        myButton.transform.localScale = new Vector3(1, 1, 0); // change its local scale in x y z format
        
        RectTransform myRect = myButton.GetComponent<RectTransform>();
        myRect.sizeDelta = new Vector2 (buttonSize, buttonSize);

        TextMeshProUGUI myGUI = myButton.GetComponentInChildren<TextMeshProUGUI>();
        myGUI.text = alphabet[i];

        //onClick.AddListener(TaskOnClick);

        xOffset++;

        if (i == 12)// (i%13 == 0) //Reached letter 10 or letter 20
        {
            xOffset = 0;
            yOffset--;
        }
        }

        


        Debug.Log("Instantiated!");
    }

    /*void OnGUI()
    {
        if (true)//(this.buttonsCreated == false)// (buttonsCreated == false)
        {

            buttonsCreated = true;
        }

        //if (GUI.Button(new Rect(10, 10, 50, 50), btnTexture))
            //Debug.Log("Clicked the button with an image");
        


    }
    */
}