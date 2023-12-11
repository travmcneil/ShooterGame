using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private float _spawnTime = 5f;
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;

    private bool _stopSpawning = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Spawn game objects every 5 seconds
    //Create a coroutine of type IEnumerator -- Yield Events
    IEnumerator SpawnRoutine()
    {
        //while loop(infinite loop
            //instantiate enemy prefab
                //yield wat for 5 seconds
        while (_stopSpawning == false)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-8f, 8f), 7, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, spawnPos, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(_spawnTime);
        }

        //WE WILL NEVER GET HERE
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
