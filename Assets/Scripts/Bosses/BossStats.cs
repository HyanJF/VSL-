using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStatsz : MonoBehaviour
{
    [SerializeField] float bossMaxHP;
    float botActualHP;
    float bossSpeed;
    List<BossAbility> bossAbilities;

    enum BossAttackState
    {
        attacking,
        onCooldown,
        ready,
    }
    enum BossMovingState
    {
        running,
        chasing,
        standing,
        randomMovement
    }

    BossMovingState movingState;
    private void Start()
    {
        botActualHP = bossMaxHP;
        ActivateAbility();
    }

    private void Update()
    {
        switch (movingState)
        {
            case BossMovingState.running:
                Run();
                break;
            case BossMovingState.chasing:
                Chase();
                break;
            case BossMovingState.standing:
                Stand();
                break;
            case BossMovingState.randomMovement:
                RandomMovement();
                break;
            default:

                break;
        }
    }
    void DealDamage(float damage)
    {
        botActualHP -= damage;
        //ToDo update HP bar
    }

    private void ActivateAbility()
    {
        int randomIndex = Random.Range(0,bossAbilities.Count);
        bossAbilities[randomIndex].Ability();
        StartCoroutine(WaitTime(bossAbilities[randomIndex].cooldownTime));
    }

    IEnumerator WaitTime(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        ActivateAbility();
    }

    void Run()
    {
        
    }

    void Chase()
    {

    }

    void Stand()
    {

    }

    void RandomMovement()
    {

    }

}
