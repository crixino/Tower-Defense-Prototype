using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    private Timer timer;
    private WaveUI waveUI;
    private SpawnManager spawnManager;

    private bool wavesStarted = false;
    private bool isLastWave = false;

    private int numberOfWaves = 10;
    private int currentWave = 0;

    // Start is called before the first frame update
    void Start()
    {
        timer = this.GetComponent<Timer>();
        waveUI = this.GetComponent<WaveUI>();
        spawnManager = this.GetComponent<SpawnManager>();

        waveUI.CalculateWaveUISpeed(timer.GetTime());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextWave()
    {
        if (!isLastWave)
        {
            timer.ResetTimer();
            spawnManager.AddNextWaveToList(currentWave);
            waveUI.CalculateWaveUISpeed(timer.GetTime());
            waveUI.NextWaveUI();
            timer.StartTimer();
            spawnManager.WaveStarted();
        }
    }

    public void StartWaves()
    {
        waveUI.CalculateWaveUISpeed(timer.GetTime());
        spawnManager.AddNextWaveToList(currentWave);
        timer.StartTimer();
        waveUI.StartWaves();
        spawnManager.WaveStarted();
        wavesStarted = true;
    }

    public void SetIsLastWave(bool isLastWave)
    {
        this.isLastWave = isLastWave;
        if (isLastWave)
            timer.StopTimer();
    }

    public bool IsLastWave()
    {
        return this.isLastWave;
    }

    public void NextWaveButton_Clicked()
    {
        if(!wavesStarted)
        {
            StartWaves();
            currentWave++;
        } else
        {
            NextWave();
            currentWave++;
        }
        
    }

    public int GetNumberOfWaves()
    {
        return this.numberOfWaves;
    }

}
