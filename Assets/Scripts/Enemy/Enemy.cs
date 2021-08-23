using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    /*public enum EnemyStates
    {
        Patrol,
        Idle,
        Attack,
        Dead
    }*/

    //public Patrol patrol;
    //private float waitTime;
    //public float startWaitTime;
    //public EnemyStates state;

    public float damage;
    public float speed;
    public float health;

    public Vector3[] patrolPoint;
    public Enemy enemy;
    public State state;

    public GameObject playerGameObject;

    private void Start()
    {
        state = GetComponent<Patrol>();
        playerGameObject = GameObject.FindGameObjectWithTag("Player");
        //waitTime = startWaitTime;
    }
    private void Update()
    {

        //instantKill
        if (Input.GetKeyDown(KeyCode.H))
        {
            health = 0;
        }

        state.ExecuteActionState();

       
        /*switch (enemy.state)
        {
            case EnemyStates.Patrol:
                patrol.PatrolOnPlatform();

                /*for (int i = 0; i < patrolPoint.Length; i++)
                {
                    if (Vector3.Distance(transform.position, patrolPoint[i]) < 0.2f)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, patrolPoint[i], speed * Time.deltaTime);
                    }
                    
                    
                }
                break;
            case EnemyStates.Idle:
                break;
            case EnemyStates.Attack:
                break;
            case EnemyStates.Dead:
                break;
            default:
                break;
        }*/
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            float playerHealth = playerGameObject.GetComponent<Player>().health;
            playerHealth -= damage;
            Debug.Log(playerHealth);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(GetComponent<Attack>().AttackSpeed());
            Debug.Log(GetComponent<Attack>().playerHealth);
        }
    }

}

