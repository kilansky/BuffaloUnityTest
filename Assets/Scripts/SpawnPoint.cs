using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public List<EnemyTypes> spawnableEnemies = new List<EnemyTypes>();

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy(EnemyToSpawn());
    }

    //Returns a random enemy type from the spawnableEnemies List
    private EnemyTypes EnemyToSpawn()
    {
        int numEnemyTypes = spawnableEnemies.Count;

        if (numEnemyTypes == 0)
        {
            Debug.LogWarning("No enemy types were added to the spawnableEnemies list");
            return null;
        }

        int randEnemyIndex = Random.Range(0, numEnemyTypes - 1);
        return spawnableEnemies[randEnemyIndex];
    }

    //Attempts to spawn the given enemyType at this spawn point's location
    private void SpawnEnemy(EnemyTypes enemyType)
    {
        //Check enemy spawnRate to see if it spawns
        if(Random.Range(0, 1f) <= enemyType.spawnRate)
        {
            //Spawn the new enemy type
            Instantiate(enemyType.enemyPrefab, transform.position, Quaternion.identity);
        }
    }
}
