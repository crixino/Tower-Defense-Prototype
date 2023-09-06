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

    private int enemiesToSpawn = 7;
    private int spawnCount = 0;
    private bool waveEnded = true;
    private float spawnSpeed = 1f;

    private IEnumerator spawning;

    // Start is called before the first frame update
    void Start()
    {
        enemyPrefab = Resources.Load(enemyPrefabLocation) as GameObject;

        spawning = Spawning();
        StartCoroutine(spawning);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnPrefab()
    {
        GameObject enemy = Instantiate(enemyPrefab);
        Debug.Log("Spawnpoint: " + spawnPoint);
        enemy.transform.SetParent(parent[GetSpawnPoint()]);
        enemy.transform.localPosition = new Vector3(0, 0, 0);
        spawnCount++;
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

    private IEnumerator Spawning()
    {
        while (enabled)
        {
            if (!waveEnded)
            {
                spawnPrefab();

                if(spawnCount == enemiesToSpawn)
                {
                    spawnCount = 0;
                    waveEnded = true;
                }

                yield return new WaitForSeconds(spawnSpeed);
            }
            else
                yield return new WaitForSeconds(.1f);
        }
    }

    public void WaveStarted()
    {
        waveEnded = false;
    }
}
