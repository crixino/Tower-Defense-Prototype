using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    private Timer timer;
    private WaveUI waveUI;

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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            NextWave();
        }
    }

    public void NextWave()
    {
        timer.ResetTimer();
        waveUI.CalculateWaveUISpeed(timer.GetTime());
        waveUI.NextWaveUI();
        timer.StartTimer();
    }

    public void StartWaves()
    {
        waveUI.CalculateWaveUISpeed(timer.GetTime());
        timer.StartTimer();
        waveUI.StartWaves();
    }
}
