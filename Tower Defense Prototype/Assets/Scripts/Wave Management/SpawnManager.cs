using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private List<Wave> waves = new List<Wave>();
    private List<Wave> activeWaves = new List<Wave>();
    private EnemyDatabase enemyDatabase;

    private string enemyPrefabLocation = "Prefabs/Enemy";
    [SerializeField]
    private Transform[] parent;

    private int spawnPoint = 0;
    private bool waveEnded = true;
    private float spawnSpeed = 1f;

    private IEnumerator spawning;

    // Start is called before the first frame update
    void Start()
    {
        enemyDatabase = GetComponent<EnemyDatabase>();
        CreateWaves();

        spawning = Spawning();
        StartCoroutine(spawning);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnPrefab()
    {
        GameObject enemy;
        foreach (Wave wave in activeWaves)
        {
            enemy = Instantiate(Resources.Load(wave.GetEnemyPrefabLocation()) as GameObject);
            enemy.GetComponentInChildren<EnemyMovementScript>().SetEnemyMovementSpeed(wave.GetEnemystats().GetMovementSpeed());
            enemy.GetComponentInChildren<Health>().SetMaxHealth(wave.GetEnemystats().GetHealth());
            enemy.transform.SetParent(parent[GetSpawnPoint()]);
            enemy.transform.localPosition = new Vector3(0, 0, 0);
        }
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

                if(activeWaves.Count == 0)
                {
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

    public void AddNextWaveToList(int currentWave)
    {
        activeWaves.Add(waves[currentWave]);
    }

    private void CreateWaves()
    {
        Wave wave;
        for(int i = 0; i < this.GetComponent<WaveManager>().GetNumberOfWaves(); i++)
        {
            wave = new Wave(enemyDatabase.GetEnemy(i), 7);
            waves.Add(wave);
        }
    }
}
