using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    private Timer timer;
    private WaveUI waveUI;

    private bool wavesStarted = false;
    private bool isLastWave = false;

    // Start is called before the first frame update
    void Start()
    {
        timer = this.GetComponent<Timer>();
        waveUI = this.GetComponent<WaveUI>();

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
            waveUI.CalculateWaveUISpeed(timer.GetTime());
            waveUI.NextWaveUI();
            timer.StartTimer();
        }
    }

    public void StartWaves()
    {
        waveUI.CalculateWaveUISpeed(timer.GetTime());
        timer.StartTimer();
        waveUI.StartWaves();
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
        } else
        {
            NextWave();
        }
    }
}
