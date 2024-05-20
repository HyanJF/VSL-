using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    public static PlayerAbilities Instance;

    [Serializable]
    public struct AbilityHolder
    {
        public Ability ability;
        public KeyCode keyCode;
    }

    public AbilityHolder ability1;
    public AbilityHolder ability2;
    public AbilityHolder ability3;
    public AbilityHolder ability4;

    public GameObject player;

    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        if(ability1.ability != null)
        {
            ability1.ability.UpdateCall(ability1.keyCode, player);
        }
        if (ability2.ability != null)
        {
            ability2.ability.UpdateCall(ability2.keyCode, player);
        }
        if (ability3.ability != null)
        {
            ability3.ability.UpdateCall(ability3.keyCode, player);
        }
        if (ability4.ability != null)
        {
            ability4.ability.UpdateCall(ability4.keyCode, player);
        }
    }
}
