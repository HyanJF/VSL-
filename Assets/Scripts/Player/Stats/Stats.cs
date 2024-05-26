using System.Collections;
using UnityEngine;

public class Stats : MonoBehaviour
{
    // variables
    [SerializeField] private float totallife;
    [SerializeField] private float life;
    [SerializeField] private int lvl;
    [SerializeField] private float speed;
    [SerializeField] private float DeadAnimationTime;
    [SerializeField] private GameObject gameoverPanel;

    public int deathCounter;
    // variables balas 

    public static Stats instance;
    // Funciones
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            //Destroy(gameObject);
            Debug.Log("Hola");
        }
        // provicional
        takeDamage(0);

        life = totallife;
        gameoverPanel.SetActive(false);
    }

    public void takeDamage(float damage)
    {
        life -= damage;
        if(life < 0)
        {
            life = 0;
            StartCoroutine(dead());
        }
    }

    public IEnumerator dead()
    {
        yield return new WaitForSeconds(DeadAnimationTime);
        gameoverPanel.SetActive(true);
        Destroy(gameObject);
    }
    
    public float Speed()
    {
        return speed;
    }
    
    public void lvlUpdate()
    {
        lvl++;
        totallife++;
        speed++;
        life = totallife;
    }
    public int LvlActual()
    {
        return lvl;
    }
}
