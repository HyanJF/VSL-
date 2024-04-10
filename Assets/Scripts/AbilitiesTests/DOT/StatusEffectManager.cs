using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectManager : MonoBehaviour
{
    private DOTHealth healthScript;
    public int dmg;
    public List<int> tickTimer = new List<int>();

    void Start()
    {
        healthScript = GetComponent<DOTHealth>();
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
    }

    IEnumerator DOT()
    {
        while(tickTimer.Count > 0)
        {
            for(int i = 0; i < tickTimer.Count; i++)
            {
                tickTimer[i]--;
            }
            healthScript.health -= dmg;
            tickTimer.RemoveAll(i => i == 0);
            yield return new WaitForSeconds(0.75f);
        }
    }
}
