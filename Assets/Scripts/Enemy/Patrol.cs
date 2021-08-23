using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : State
{
    public float speed;
    public float distance;
    public float playerDistance;

    public Attack attackState;
    public Death deathState;
    public Enemy enemy;

    public Vector2 detection;

    private bool movingLeft;

    public Transform groundDetection;
    public Transform playerDetection;

    private void Start()
    {
        attackState = GetComponent<Attack>();
        deathState = GetComponent<Death>();
        movingLeft = true;
    }
    private void Update()
    {
        
    }

    public void PatrolOnPlatform() 
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        int layerMask = LayerMask.GetMask("Floor");
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance, layerMask);
        if (groundInfo.collider == false)
        {
            if (movingLeft == true)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                movingLeft = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingLeft = true;
            }
        }

        int layerMasks = LayerMask.GetMask("Player");
        if (transform.eulerAngles.y > 0)
        {
            detection = new Vector2(1, 0);
        }
        else
        {
            detection = new Vector2(-1, 0);
        }
        RaycastHit2D playerInfo = Physics2D.Raycast(playerDetection.position, detection, playerDistance, layerMasks);
        if (playerInfo == true)
        {
            GetComponent<Enemy>().state = attackState;
        }

        if (GetComponent<Enemy>().health <= 0)
        {
            GetComponent<Enemy>().state = deathState;
        }
    }

    public override void ExecuteActionState()
    {
        PatrolOnPlatform();

        

    }
}
