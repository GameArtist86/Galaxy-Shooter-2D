using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private GameObject _laserPrefab;
    private float _laserOffsetY = .8f;
    
    void Start()
    {
      transform.position = new Vector3(0,0,0);
    }

    void Update()
    {
        CalculateMovement();
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_laserPrefab, new Vector3(transform.position.x, (transform.position.y + _laserOffsetY), 0), Quaternion.identity);
            
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
}
