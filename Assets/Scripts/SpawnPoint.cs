using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Kilan Larsen
 * Description: Spawns an enemy at game start based on publically set parameters
 * Last Modified: 9/22/22
*/

public class SpawnPoint : MonoBehaviour
{
    public EnemyClasses spawnableClass;
    public List<EnemyTypes> spawnableTypes = new List<EnemyTypes>();

    void Start()
    {
        RemoveUnspawnableClasses();
        SpawnEnemy(EnemyToSpawn());
    }

    //Checks the spawnableTypes list for any classes that cannot be spawned and removes them from the list
    private void RemoveUnspawnableClasses()
    {
        if (spawnableClass == EnemyClasses.Any)
            return;

        //Store all unspawnable enemies
        List<EnemyTypes> unspawnableEnemies = new List<EnemyTypes>();
        foreach (EnemyTypes enemyType in spawnableTypes)
        {
            if (enemyType.enemyClass != spawnableClass)
                unspawnableEnemies.Add(enemyType);
        }

        //Remove unspawnable enemies from the spawnableTypes list until there are no more unspawnableEnemies
        while (unspawnableEnemies.Count > 0)
        {
            spawnableTypes.Remove(unspawnableEnemies[0]);
            unspawnableEnemies.RemoveAt(0);
        }
    }

    //Returns a random enemy type from the spawnableEnemies List
    private EnemyTypes EnemyToSpawn()
    {
        int numEnemyTypes = spawnableTypes.Count;

        if (numEnemyTypes == 0)
        {
            Debug.LogWarning("No enemy types were added to the spawnableEnemies list");
            return null;
        }

        int randEnemyIndex = Random.Range(0, numEnemyTypes);
        return spawnableTypes[randEnemyIndex];
    }

    //Attempts to spawn the given enemyType at this spawn point's location
    private void SpawnEnemy(EnemyTypes enemyType)
    {
        Debug.Log("Attempting to spawn " + enemyType.name + " at " + gameObject.name + " with spawnRate " + enemyType.spawnRate);
        float spawnRate = SetSpawnProbability(enemyType);

        //Check enemy spawnRate to see if it spawns
        if (Random.Range(0, 1f) < spawnRate)
        {
            //Spawn the new enemy type
            Instantiate(enemyType.enemyPrefab, transform.position, Quaternion.identity);
            Debug.Log(enemyType.name + " successfully spawned at " + gameObject.name);
        }
    }

    //Check the time of day to modify the spawn rate of the given enemy
    private float SetSpawnProbability(EnemyTypes enemyType)
    {
        float spawnRate = enemyType.spawnRate;

        //Morning Spawn Rate Changes
        if (GameManager.Instance.GetTimeOfDay() == TimeOfDay.Morning)
        {
            if (enemyType.enemyClass == EnemyClasses.Archers)
            {
                spawnRate += Random.Range(0.2f, 0.4f);
                Debug.Log("Archer spawn rate increased to " + spawnRate + " in the Morning");
            }

            if(enemyType.name == "Brown")
            {
                spawnRate += Random.Range(-0.1f, -0.3f);
                Debug.Log("Brown spawn rate decreased to " + spawnRate + " in the Morning");
            }
        }
        //Afternoon Spawn Rate Changes
        else if (GameManager.Instance.GetTimeOfDay() == TimeOfDay.Afternoon)
        {
            if (enemyType.enemyClass == EnemyClasses.Assassins)
            {
                spawnRate = 0;
                Debug.Log("Assassin spawn rate decreased to " + spawnRate + " in the Afternoon");
            }
            else if (enemyType.enemyClass != EnemyClasses.Grunts)
            {
                spawnRate += Random.Range(-0.2f, 0.2f);
                Debug.Log("Non-Assassin/Grunt classes spawn rate changed to " + spawnRate + " in the Afternoon");
            }
        }
        //Night Spawn Rate Changes
        else
        {
            Debug.Log("No spawn rate changes at Night");
        }

        //Clamp modified spawn rate between 0-1
        spawnRate = Mathf.Clamp(spawnRate, 0f, 1f);
        return spawnRate;
    }
}