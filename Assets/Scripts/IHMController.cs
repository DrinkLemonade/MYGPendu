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
    private TextMeshProUGUI knownWordDisplayGUI;
    [SerializeField]
    private TextMeshProUGUI gameOverMessageGUI;

    //private GameObject display;
    //private GameObject gameOver;

    public void UpdateDisplay(HangmanGame currentGame)
    {
        knownWordDisplayGUI.text = currentGame.knownWord.ToUpper();
    }

    public void GameOverText(string message)
    {
        gameOverMessageGUI.text = message;
    }

    public void UpdateSprite(HangmanGame currentGame)
    {
        hangmanImage.sprite = sprites[currentGame.SpriteVersion];
    }

    void Awake()
    {
        instance = this;
    }
}
