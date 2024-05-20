using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject prefabEnemy;
    public GameObject spawnPosition;
    private int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateEnemy(prefabEnemy, spawnPosition, counter));
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.A))
        {
        }
        */
        
    }

    public IEnumerator CreateEnemy(GameObject enemy, GameObject position, int counter)
    {
        Instantiate(prefabEnemy);
        prefabEnemy.transform.position = spawnPosition.transform.position;
        yield return new WaitForSeconds(1f);
        StartCoroutine(CreateEnemy(enemy, position, counter));
    }


}
