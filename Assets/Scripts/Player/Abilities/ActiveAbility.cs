using System.Collections;
using System.Collections.Generic;
using UnityEditor.Playables;
using UnityEngine;

public class ActiveAbility : Ability
{
    public float cooldown;
    public float activeDuration;

    private float cooldownTimer;
    private float activeTimer;
    enum AbilityState { ready, active, cooldown }
    AbilityState state = AbilityState.ready;

    public override void UpdateCall(KeyCode keyCode, GameObject player)
    {
        switch (state)
        {
        case AbilityState.ready:
            if (Input.GetKeyUp(keyCode)) {
                ActivateAbility(player);
                    state = AbilityState.active;
                    activeTimer = activeDuration;
            }
            break;
        case AbilityState.active:
            if (activeTimer > 0)
            {
                activeTimer -= Time.deltaTime;
            }
            else
            {
                state = AbilityState.cooldown;
                DeactivateAbility(player);
                cooldownTimer = cooldown;
            }
            break;
        case AbilityState.cooldown:
            if (cooldownTimer > 0)
            {
                cooldownTimer -= Time.deltaTime;
            }
            else
            {
                state = AbilityState.ready;
            }
            break;
        }
    }

    public virtual void ActivateAbility(GameObject player){}
    public virtual void DeactivateAbility(GameObject player) { }
}
    