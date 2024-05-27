using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    [SerializeField] private Animator animator;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI inGameScoreText;
    public int score = 0;

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
            animator.SetTrigger("IsDead");
            StartCoroutine(Dead());
        }
    }

    public void UpdateScore(int _score)
    {
        score += _score;
        inGameScoreText.text = "Score " + score;
    }

    public IEnumerator Dead()
    {
        yield return new WaitForSeconds(DeadAnimationTime);
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < Enemies.Length; i++)
        {
            Destroy(Enemies[i]);
        }
        Enemies = GameObject.FindGameObjectsWithTag("EnemyHealer");
        for (int i = 0; i < Enemies.Length; i++)
        {
            Destroy(Enemies[i]);
        }

        gameoverPanel.SetActive(true);
        scoreText.text = "Score " + score;
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
