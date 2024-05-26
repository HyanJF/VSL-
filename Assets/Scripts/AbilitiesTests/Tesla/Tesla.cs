using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Tesla : MonoBehaviour
{

    public float DMG;
   
    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.CompareTag("Enemy"))
        {

            try
            {
                other.GetComponent<EnemyStats>().health -= DMG * Time.deltaTime;
                
            }
            catch (NullReferenceException)
            {
            }
        }
    }

}
