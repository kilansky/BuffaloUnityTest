using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Kilan Larsen
 * Description: A scriptable object to generate each enemy type and associated information
 * Last Modified: 9/22/22
*/

public enum EnemyClasses
{
    Archers,
    Assassins,
    Grunts,
    Any //Used for inspector purposes only
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

    //Prevent negative value inputs in the inspector
    private void OnValidate()
    {
        attackPower = Mathf.Clamp(attackPower, 0, int.MaxValue);
        health = Mathf.Clamp(health, 0, int.MaxValue);
        speed = Mathf.Clamp(speed, 0, float.MaxValue);
    }
}