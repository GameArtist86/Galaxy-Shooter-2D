using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShot : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;

    // Update is called once per frame
    void Update()
    {
 
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
 
        if (transform.position.y <= -8.0f)
        {
            Destroy(this.gameObject);
        }
    }


    //OnTriggerCollision 
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            player.TripleShotCollected();
            Destroy(this.gameObject);
        }
    }
    
}
