using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : PickUps
{
    public override void ActivatePowerUp(GameObject other)
    {
        Player player = other.GetComponent<Player>();
        player.extraJumpValue = 1;
        Destroy(gameObject);
    }

}
