using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _scoreText;
    [SerializeField]
    private Image _livesImage;
    [SerializeField]
    private Sprite[] _livesSprites;
    [SerializeField]
    private GameObject _gameOverImage;
    //private TMP_Text _gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = ("Score: " + 0);
        //_gameOverText.text = " ";
        _gameOverImage.gameObject.SetActive(false);
    }

    public void UpdateScore(int playerScore)
    {
        _scoreText.text = "Score: " + playerScore;
    }

    public void UpdateLives(int currentLives)
    {
        _livesImage.sprite = _livesSprites[currentLives];
    }

    public void GameOver()
    {
        //_gameOverText.text = "GAME OVER";
        _gameOverImage.gameObject.SetActive(true);

        
        
    }
}
