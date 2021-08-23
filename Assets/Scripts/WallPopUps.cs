using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPopUps : MonoBehaviour
{

    public GameObject bossGate;
    public GameObject bossBackWall;

    Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        if (GameObject.FindWithTag("Boss") == null)
        {
            StartCoroutine(DeleteWall());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            bossGate.SetActive(true);
            bossBackWall.SetActive(true);
        }
    }


    IEnumerator DeleteWall()
    {
        yield return new WaitForSeconds(2);
        //gameObject.SetActive(false);
        bossGate.SetActive(false);
        bossBackWall.SetActive(false);
    }
}
