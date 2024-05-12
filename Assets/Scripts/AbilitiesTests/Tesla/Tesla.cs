using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Tesla : MonoBehaviour
{

    public int DMG;
   
    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.CompareTag("Enemy"))
        {

            try
            {
                Debug.Log("Zapping an enemy");
                other.GetComponent<EnemyStats>().health -= DMG;
                StartCoroutine(Wait() );
            }
            catch (NullReferenceException)
            {
                Debug.Log("The tesla aint teslaing");
            }
        }
    }
    IEnumerator Wait()
    {
        //No funciona esta mamada
        yield return new WaitForSeconds(100f);
        
    }

}
