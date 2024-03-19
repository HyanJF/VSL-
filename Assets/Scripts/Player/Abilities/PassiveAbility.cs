using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveAbility : Ability
{
    public override void UpdateCall(KeyCode keyCode, GameObject player)
    {
        ActivateAbility(player);
    }

    public virtual void ActivateAbility(GameObject player) { }
}
