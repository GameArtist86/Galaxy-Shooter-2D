using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _tripleShotPrefab;
    [SerializeField]
    private float _fireRate = .2f;
    private float _canFire = -1;
    [SerializeField]
    private int _lives = 3;
    [SerializeField]
    private bool _isTripleShotActive = false;
   
    
    void Start()
    {
      transform.position = new Vector3(0,0,0);
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
        if (_lives > 0)
        {
            _lives--;
        }

        else if (_lives <= 0)
        {
            SpawnManager _spawnManager = GameObject.Find("SpawnManager").transform.GetComponent<SpawnManager>();

            if (_spawnManager != null)
            {
                _spawnManager.OnPlayerDeath();
            }
            Destroy(this.gameObject);
        }
    }
}
