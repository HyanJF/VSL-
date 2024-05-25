using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SpawnManager : MonoBehaviour
{
    public GameObject prefab;
    public Transform[] spawnPoints;
    public GameObject[] enemies;
    // Variable pública para el intervalo de tiempo entre apariciones
    public float timeInterval = 2f;
    //Espera entre spawns
    public float timeWait = 1f;

    public GameObject player;

    void Start()
    {
        // Inicia la invocación repetitiva de la función SpawnPrefab
        InvokeRepeating("SpawnPrefab", timeWait, timeInterval);
    }

    private void Update()
    {
        if (Stats.instance.deathCounter == 8) 
        { 
            GetComponentInChildren<BossSpawner>().enabled = true;
        }
        if (Stats.instance.deathCounter == 16)
        {
            spawnPoints[1].GetComponentInChildren<BossSpawner>().enabled = true;
        }
    }

    void SpawnPrefab()
    {
        if (spawnPoints.Length == 0 || enemies.Length == 0)
        {
            Debug.LogWarning("No haz asignado los spawns xd.");
            return;
        }

        // Aqui se agarra el spawn aleatorio
        int SpawnerIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[SpawnerIndex];

        int enemiesIndex = Random.Range(0, enemies.Length);

        // Instancia el prefab en la posición y rotación del punto de aparición seleccionado
        Instantiate(enemies[enemiesIndex], spawnPoint.position, spawnPoint.rotation);
    }
}

