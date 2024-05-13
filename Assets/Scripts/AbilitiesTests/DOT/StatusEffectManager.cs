using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectManager : MonoBehaviour
{
    private EnemyStats healthScript;
    public int dmg;
    public List<int> tickTimer = new List<int>();

    void Start()
    {
        healthScript = GetComponent<EnemyStats>();
    }

    public void ApplyDOT(int ticks)
    {
        if(tickTimer.Count <= 0)
        {
            tickTimer.Add(ticks);
            StartCoroutine(DOT());
        }
        else
        {
            tickTimer.Add(ticks);
        }
      //Si se usa el tesla junto con las balas de fuego, se stackean demasiados ticks lo cual puede dar pedos muy cabrones de memoria
      //Hay que  arreglar eso eventualmente
    }

    IEnumerator DOT()
    {
        while(tickTimer.Count > 0)
        {
            for(int i = 0; i < tickTimer.Count; i++)
            {
                tickTimer[i]--;
            }
            healthScript.Health -= dmg;
            tickTimer.RemoveAll(i => i == 0);
            yield return new WaitForSeconds(0.75f);
        }
    }
}
