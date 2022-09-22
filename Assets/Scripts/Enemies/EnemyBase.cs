using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public EnemyTypes enemyType;

    private EnemyClasses enemyClass;
    private int attackPower;
    private int health;
    private float speed;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        InitializeStats();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    protected virtual void InitializeStats()
    {
        attackPower = enemyType.attackPower;
        health = enemyType.health;
        speed = enemyType.speed;
    }
}
