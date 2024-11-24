using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _tripleShotPrefab;
    [SerializeField]
    private GameObject _rightEngineDamage, _leftEngineDamage, _centerEngineDamage;
    [SerializeField]
    private float _fireRate = .2f;
    private float _canFire = -1;
    [SerializeField]
    private int _lives = 3;
    [SerializeField]
    private bool _isTripleShotActive = false;
    [SerializeField]
    private bool _isSpeedBoostActive = false;
    [SerializeField]
    private bool _isShieldActive = false;
    [SerializeField]
    private GameObject _shieldVisualizer;
    private SpawnManager _spawnManager;
    [SerializeField]
    private int _score;
    private UIManager _uiManager;


    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        _rightEngineDamage.SetActive(false);
        _leftEngineDamage.SetActive(false);
        _centerEngineDamage.SetActive(false);
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    void Update()
    {
        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            FireLaser();
        }

    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        transform.Translate(direction * _speed * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.9f, 0), 0);


        if (transform.position.x > 11.2f)
        {
            transform.position = new Vector3(-11.2f, transform.position.y, 0);
        }
        else if (transform.position.x < -11.2f)
        {
            transform.position = new Vector3(11.2f, transform.position.y, 0);
        }
    }

    void FireLaser()
    {
        _canFire = Time.time + _fireRate;

        if (_isTripleShotActive == true)
        {
            Instantiate(_tripleShotPrefab, transform.position + new Vector3(-.76f, 0.2f, 0), Quaternion.identity);
        }

        else
        {
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 1.3f, 0), Quaternion.identity);
        }

    }
    public void Damage()
    {
        if (_isShieldActive == true)
        {
            _shieldVisualizer.SetActive(false);
            _isShieldActive = false;
            return;
        }
        if (_lives > 0)
        {
            _lives--;
            _uiManager.UpdateLives(_lives);
            
            if (_lives == 2)
            {
                _rightEngineDamage.SetActive(true);
            }

            if ( _lives == 1)
            {
                _leftEngineDamage.SetActive(true);
            }

            if( _lives == 0)
            {
                _centerEngineDamage.SetActive(true);
            }
        }

        else if (_lives <= 0)
        {


            if (_spawnManager != null)
            {
                _spawnManager.OnPlayerDeath();
            }

            if (_uiManager != null)
            {
                _uiManager.GameOver();
            }

            Destroy(this.gameObject);
            
        }
    }
    public void AddScore(int points)
    {
        _score = _score + points;
        _uiManager.UpdateScore(_score);
    }


    public void TripleShotCollected()
    {
        _isTripleShotActive = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    public void SpeedBoostCollected()
    {
        _speed = 8.5f;
        _isSpeedBoostActive = true;
        StartCoroutine(SpeedBoostPowerDownRoutine());
    }

    public void ShieldPowerupCollected()
    {
        _isShieldActive = true;
        _shieldVisualizer.SetActive(true);
    }

    IEnumerator TripleShotPowerDownRoutine()
    {
        while (_isTripleShotActive)
        {
            yield return new WaitForSeconds(5);
            _isTripleShotActive = false;
        }
    }

    IEnumerator SpeedBoostPowerDownRoutine()
    {
        while (_isSpeedBoostActive)
        {
            yield return new WaitForSeconds(5);
            _speed = 5;
            _isSpeedBoostActive = false;
        }
    }


}
    



