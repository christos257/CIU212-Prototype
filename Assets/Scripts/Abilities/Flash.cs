using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : PickUps
{
    public override void ActivatePowerUp(GameObject other)
    {
        Player player = other.GetComponent<Player>();
        player.flashCountValue = 1;
        Destroy(gameObject);
    }

  
}
