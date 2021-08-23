using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : PickUps
{
    public override void ActivatePowerUp(GameObject other)
    {
        Player player = other.GetComponent<Player>();
        player.dashCountValue = 1;
        Destroy(gameObject);  
    }

    
}
