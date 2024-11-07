using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            Instantiate(_enemyPrefab, new Vector3((Random.Range(-11f, 11f)), 7.5f, 0), Quaternion.identity);
            yield return new WaitForSeconds(5);
        }
    }
}
