using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Kilan Larsen
 * Description: A superclass to handle base enemy stats and behaviors
 * Last Modified: 9/22/22
*/

public class EnemyBase : MonoBehaviour
{
    public EnemyTypes enemyType;

    private int attackPower;
    private int health;
    private float speed;

    protected virtual void Awake()
    {
        InitializeStats();
        ModifySpawnStats();
    }

    protected virtual void Update()
    {
        
    }

    //Get the stat values from the enemyType scriptable object to set enemy stats 
    protected virtual void InitializeStats()
    {
        attackPower = enemyType.attackPower;
        health = enemyType.health;
        speed = enemyType.speed;
    }

    //Check the time of day to modify the stats of the given enemy
    private void ModifySpawnStats()
    {
        //Morning Stat Changes
        if (GameManager.Instance.GetTimeOfDay() == TimeOfDay.Morning)
        {
            Debug.Log("No enemy stat changes in the Morning");
        }
        //Afternoon Stat Changes
        else if (GameManager.Instance.GetTimeOfDay() == TimeOfDay.Afternoon)
        {
            if (enemyType.enemyClass == EnemyClasses.Grunts)
            {
                attackPower += 1;
                Debug.Log("Grunt attackPower increased by 1 in the Afternoon");
            }
        }
        //Night Stat Changes
        else
        {
            if (enemyType.enemyClass == EnemyClasses.Assassins)
            {
                speed += Random.Range(0f, 2f);
                Debug.Log("Assassin speed increased to " + speed + " at Night");
            }
        }
    }
}