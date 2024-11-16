using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

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
    [SerializeField]
    private TMP_Text _restartText;
    [SerializeField]
    private GameManager _gameManager;
    //private TMP_Text _gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        _scoreText.text = ("Score: " + 0);
        //_gameOverText.text = " ";
        _gameOverImage.gameObject.SetActive(false);
        _restartText.gameObject.SetActive(false);
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
        _gameManager.GameOver();
        StartCoroutine(RestartBlinkRoutine());
        
    }
    IEnumerator RestartBlinkRoutine()
    {
        while (true)
        {
            _restartText.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            _restartText.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
