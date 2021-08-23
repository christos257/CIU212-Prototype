using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUps : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ActivatePowerUp(collision.gameObject);
        }
    }

    public abstract void ActivatePowerUp(GameObject other);
}
