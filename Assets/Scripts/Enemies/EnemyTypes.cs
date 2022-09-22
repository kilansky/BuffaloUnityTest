using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyClasses
{
    Archers,
    Assassins,
    Grunts
}

[CreateAssetMenu(menuName = "Enemy Type")]
public class EnemyTypes : ScriptableObject
{
    public EnemyClasses enemyClass;
    public GameObject enemyPrefab;
    public int attackPower;
    public int health;
    public float speed;
    [Range(0, 1)] public float spawnRate;

    private void Start()
    {
        Debug.Log("Testing!!");
        //SetTimeOfDayStatChanges();
    }

    private void SetTimeOfDayStatChanges()
    {
        //Morning Stat Changes
        if (GameManager.Instance.GetTimeOfDay() == TimeOfDay.Morning)
        {
            if (enemyClass == EnemyClasses.Archers)
            {
                //enemyType.
            }
        }
        //Afternoon Stat Changes
        else if (GameManager.Instance.GetTimeOfDay() == TimeOfDay.Afternoon)
        {

        }
        //Night Stat Changes
        else
        {

        }
    }

    //Prevent negative value inputs
    private void OnValidate()
    {
        attackPower = Mathf.Clamp(attackPower, 0, int.MaxValue);
        health = Mathf.Clamp(health, 0, int.MaxValue);
        speed = Mathf.Clamp(speed, 0, float.MaxValue);
    }
}