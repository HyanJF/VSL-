using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject prefabEnemy;
    public GameObject spawnPosition;
    private bool bossAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<EnemySpawner>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            bossAlive = false;
        }

        if(!bossAlive)
        {
            GetComponent<EnemySpawner>().enabled = true;
            GetComponent<BossSpawner>().enabled = false;
        }
    }
    public void SpawnBoss(GameObject enemy, GameObject position, int counter, int timer)
    {
        Instantiate(prefabEnemy);
        prefabEnemy.transform.position = spawnPosition.transform.position;
    }


}
