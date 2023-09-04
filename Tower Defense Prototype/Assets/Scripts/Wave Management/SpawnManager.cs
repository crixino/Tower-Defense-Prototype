using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private string enemyPrefabLocation = "Prefabs/Enemy";
    [SerializeField]
    private Transform[] parent;

    private GameObject enemyPrefab;

    private int spawnPoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        enemyPrefab = Resources.Load(enemyPrefabLocation) as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnPrefab()
    {
        GameObject enemy = Instantiate(enemyPrefab);
        enemy.transform.SetParent(parent[GetSpawnPoint()]);
        enemy.transform.position = new Vector3(0, 0, 0);
    }

    private int GetSpawnPoint()
    {
        int result = spawnPoint;
        if (spawnPoint == 0)
            spawnPoint++;
        else
            spawnPoint--;

        return result;
    }
}
