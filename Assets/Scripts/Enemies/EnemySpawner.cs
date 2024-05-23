using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Alc creo que est script ya no sirve pero por si a caso aun no lo borro
    public GameObject prefabEnemy;
    public GameObject spawnPosition;
    private int counter = 0;
    private bool bossAlive = false;
    private int waitTime = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateEnemy(prefabEnemy, spawnPosition, counter,waitTime));
        GetComponent<BossSpawner>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StopAllCoroutines();
            bossAlive = true;
            Debug.Log("Hola");
            StartCoroutine(CreateEnemy(prefabEnemy, spawnPosition, counter, waitTime));
        }

        if (bossAlive == true)
        {
            waitTime = 10;
            Debug.Log("El boss esta vivo");
            GetComponent<BossSpawner>().enabled = true;
            GetComponent<EnemySpawner>().enabled = false;
        }
        
    }
    public IEnumerator CreateEnemy(GameObject enemy, GameObject position, int counter, int timer)
    {
        Instantiate(prefabEnemy);
        prefabEnemy.transform.position = spawnPosition.transform.position;
        yield return new WaitForSeconds(timer);
        Debug.Log("se espero:"+ timer);
        StartCoroutine(CreateEnemy(enemy, position, counter, timer));
    }


}
