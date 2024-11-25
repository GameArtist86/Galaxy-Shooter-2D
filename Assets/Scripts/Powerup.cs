using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private int _powerupID;
    [SerializeField]
    private AudioClip _powerupCollectedAudio;

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
            AudioSource.PlayClipAtPoint(_powerupCollectedAudio, transform.position);
            if (player != null)
            {
                
                switch (_powerupID)
                {
                    case 0:
                        player.TripleShotCollected();
                        break;
                    case 1:
                        player.SpeedBoostCollected();
                        break;
                    case 2:
                        player.ShieldPowerupCollected();
                        break;
                }
                Destroy(this.gameObject);

            }

            
        }
    }

}
