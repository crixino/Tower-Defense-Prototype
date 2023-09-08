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
    private Transform parent;

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
        List<Wave> removeWaves = new List<Wave>();
        foreach (Wave wave in activeWaves)
        {
            //Debug.Log("Wave " + wave.GetEnemystats().GetEnemyID() + " Enemy Name: " + wave.GetEnemystats().GetEnemyName());
            enemy = Instantiate(Resources.Load(wave.GetEnemyPrefabLocation()) as GameObject);
            
            enemy.transform.SetParent(parent);
            enemy.transform.localPosition = new Vector3(GetSpawnPoint(), 0, 0);
            enemy.GetComponentInChildren<EnemyMovementScript>().SetEnemyMovementSpeed(wave.GetEnemystats().GetMovementSpeed());
            enemy.GetComponentInChildren<Health>().SetMaxHealth(wave.GetEnemystats().GetHealth());
            if(wave.GetEnemiesLeft() <= 0)
                removeWaves.Add(wave);
        }
        foreach(Wave wave in removeWaves)
            activeWaves.Remove(wave);

    }

    private float GetSpawnPoint()
    {
        float result = Random.Range(-1.3f, 1.3f);

        /*int result = spawnPoint;

        
        if (spawnPoint == 0)
            spawnPoint++;
        else
            spawnPoint--;*/

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
        Debug.Log("currentWave: " + currentWave);
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

    private void Debug_ListOfWaves()
    {
        string result = "";
        foreach(Wave wave in waves)
        {
            result = "Wave " + wave.GetEnemystats().GetEnemyID() + " Enemy Name: " + wave.GetEnemystats().GetEnemyName();
            Debug.Log(result);
        }
        
    }
}
