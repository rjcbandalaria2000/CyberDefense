using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    [SerializeField]
    Transform spawnPoint;
    //  public List<GameObject> waypoints = new List<GameObject>();
    public Transform Destination;
    public int numOfEnemiesToSpawn = 1;

    public Coroutine spawnEnemiesRoutine;
    // Start is called before the first frame update
    void Start()
    {
        //spawnEnemiesRoutine = StartCoroutine(SpawningEnemies());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemies()
    {
        //if(numOfEnemiesToSpawn > 0)
        //{
           // for (int i = 0; i < numOfEnemiesToSpawn; i++)
            //{
                Assert.IsNotNull(enemyPrefab, "Enemy prefab should not be null or empty");
                GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
                //spawnedEnemy.GetComponent<AIMovement>().waypoints = waypoints;
                spawnedEnemy.GetComponent<NavMesh_AI>().waypoint = Destination;
        //}

        //}
    }

    public void BeginSpawning()
    {
        spawnEnemiesRoutine = StartCoroutine(SpawningEnemies());
    }

    IEnumerator SpawningEnemies()
    {
        yield return null;
        for(int i = 0; i < numOfEnemiesToSpawn; i++)
        {
            yield return new WaitForSeconds(1.5f);
            SpawnEnemies();
        }
    }

}
