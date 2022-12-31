using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class IHMController : MonoBehaviour
{
    public static IHMController instance;

    [SerializeField]
    private Image hangmanImage;
    [SerializeField]
    private Sprite[] sprites;
    [SerializeField]
    TextMeshProUGUI knownWordDisplayGUI;
    [SerializeField]
    TextMeshProUGUI gameOverMessageGUI;

    private GameObject display;
    private GameObject gameOver;

    public void UpdateDisplay(HangmanGame currentGame)
    {
        Debug.Log("Called UpdateDisplay");

        knownWordDisplayGUI.text = currentGame.knownWord.ToUpper();
    }

    public void GameOverText(string message)
    {
        gameOverMessageGUI.text = message;
    }

    public void UpdateSprite(HangmanGame currentGame)
    {
        hangmanImage.sprite = sprites[currentGame.spriteVersion];
    }

    void Awake()
    {
        instance = this;
        Debug.Log(gameObject.name);
    }
}
