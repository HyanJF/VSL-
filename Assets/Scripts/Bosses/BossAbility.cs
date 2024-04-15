using UnityEngine;

public class BossAbility : ScriptableObject
{
    public float cooldownTime;
    public virtual void  Ability() { }
}
