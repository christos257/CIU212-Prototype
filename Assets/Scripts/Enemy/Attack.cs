using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : State
{

    public Patrol patrolState;
    public Death deathState;
    public Enemy enemy;

    public float damage;
    public float speed;
    public float distance;
    public float range;
    public float playerHealth;

    public GameObject playerGameObject;

    public Transform player;
    public Transform playerDetection;


    private void Start()
    {
        playerHealth = playerGameObject.GetComponent<Player>().health;
        patrolState = GetComponent<Patrol>();
        deathState = GetComponent<Death>();
        playerGameObject = GameObject.FindGameObjectWithTag("Player");
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public void PlayerDetection()
    {
        

        int layerMask = LayerMask.GetMask("Player");
        RaycastHit2D playerInfo = Physics2D.Raycast(playerDetection.position, new Vector2(-1, 0), distance, layerMask);
        if (playerInfo == true)
        {
            
            if (Vector3.Distance(transform.position, player.position) > 1f)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
        }
        else
        {
            GetComponent<Enemy>().state = patrolState;
        }

        if (GetComponent<Enemy>().health <= 0)
        {
            GetComponent<Enemy>().state = deathState;
        }

    }

    public IEnumerator AttackSpeed() 
    {
        yield return new WaitForSeconds(1f);
        if (playerHealth > 0)
        {
            playerHealth = playerHealth - damage;
        }
        else
        {
            playerHealth = 0;
        }
        
    }

    public override void ExecuteActionState()
    {
        PlayerDetection();
    }
}
