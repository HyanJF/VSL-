using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86;

public class xpManager : MonoBehaviour
{
    [SerializeField] private Stats Stats;
    [SerializeField] private int xpRequire;
    [SerializeField] private int xpActual;


    private void Start()
    {
        Stats = GetComponent<Stats>();
    }

    private void Update()
    {
        updateXp();
    }

    public int showXpNeded()
    {
        return xpRequire;
    }

    public int showXp()
    {
        return xpActual;
    }
    
    public void AddXp(int xpAmmount)
    {
        xpActual += xpAmmount;
    }

    private void updateXp()
    {
        if (xpActual >= xpRequire)
        {
            int aux = xpActual - xpRequire;
            newXpAmmout();
            xpActual = 0;
            Stats.lvlUpdate();
            xpActual += aux;
        }
    }
    private void newXpAmmout()
    {
        xpRequire *= 2;
        if(xpRequire == 4)
        {
            xpRequire = 5;
        }
        if(xpRequire == 80)
        {
            xpRequire = 100;
        }
        if (xpRequire == 800)
        {
            xpRequire = 1000;
        }
        if (xpRequire == 8000)
        {
            xpRequire = 10000;
        }
        if(xpRequire > 80000)
        {
            xpRequire = 80000;
        }
    }
}
