using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : State
{

    public Patrol patrolState;
    public Attack attackState;

    Enemy enemy;

    private bool isAlive;

    public int dropForce;

    public GameObject itemDrop;

    private void Start()
    {
        patrolState = GetComponent<Patrol>();
        attackState = GetComponent<Attack>();
        enemy = GetComponent<Enemy>();
        isAlive = true;
    }
    public override void ExecuteActionState()
    {
        isAlive = false;
        Debug.Log("He Gone");
        Destroy(gameObject);
        Instantiate(itemDrop, enemy.transform.position, Quaternion.identity);
        itemDrop.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, dropForce), ForceMode2D.Impulse);

    }
}
