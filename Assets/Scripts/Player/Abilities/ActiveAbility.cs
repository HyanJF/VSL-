
using UnityEngine;
using UnityEngine.UI;

public class ActiveAbility : Ability
{
    public float cooldown;
    public float activeDuration;
    private float cooldownTimer;
    private float activeTimer;
    
    public Image imageC;
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
                imageC.fillAmount = (cooldownTimer / cooldown);
                    Debug.Log(imageC.fillAmount);
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
    