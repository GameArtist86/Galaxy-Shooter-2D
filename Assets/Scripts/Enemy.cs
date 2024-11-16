using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _speed = 4f;
    [SerializeField]
    private Player _player;
    [SerializeField]
    private Animator _animator;
    [SerializeField] 
    private Collider2D _collider;
    
    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        if (_player == null)
        {
            Debug.LogError("Player is NULL");
        }
        _animator = GetComponent<Animator>();
        if (_animator == null)
        {
            Debug.LogError("_animation is NULL");
        }
        _collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -8f)
        {
            transform.position = new Vector3(Random.Range(-11f,11f), 8f, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player") 
        {
            Player player = other.transform.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
            }
            _animator.SetTrigger("OnEnemyDeath");
            _speed = 0f;
            Destroy(_collider);
            Destroy(this.gameObject, 2.4f);
        }

        if (other.tag == "Laser")
        {
            if (_player != null)
            {
                _player.AddScore(10);
            }
            _animator.SetTrigger("OnEnemyDeath");
            _speed = 0f;
            Destroy(_collider);
            Destroy(other.gameObject);
            Destroy(this.gameObject, 2.4f);
        }
    }
}
