using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xpManager : MonoBehaviour
{
    [SerializeField] private Stats Stats;
    [SerializeField] private int xpRequire;
    [SerializeField] private int xpActual;


    private void Start()
    {
        Stats = GetComponent<Stats>();
    }

    public void AddXp(int xpAmmount)
    {

    }

}
