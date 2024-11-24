using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float _rotationSpeed = 20.0f;
    [SerializeField]
    private GameObject _explosion;

    private void Update()
    {
        transform.Rotate(Vector3.forward * _rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Laser laser = other.transform.GetComponent<Laser>();
        if (laser != null && other.gameObject.tag == "Laser")
        {
            GameObject newExplosion = Instantiate(_explosion, transform.position + new Vector3(), Quaternion.identity);
            Destroy(newExplosion, 2.5f);
            Destroy(other.gameObject);
            Destroy(this.gameObject, 0.25f);
        }


    }
}

    

