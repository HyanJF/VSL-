using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject prefabBoss;
    public GameObject spawnPosition;
    private bool bossAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Se activo el script de el jefe");
        SpawnBoss(prefabBoss, spawnPosition, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnBoss(GameObject enemy, GameObject position, int counter, int timer)
    {
        Instantiate(enemy);
        prefabBoss.transform.position = spawnPosition.transform.position;
    }


}
