using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSpawner : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject spawner;
    void Start()
    {
        Instantiate(playerPrefab);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
