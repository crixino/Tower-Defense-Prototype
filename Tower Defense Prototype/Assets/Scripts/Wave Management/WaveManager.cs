using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
<<<<<<< HEAD
    private WaveUI waveUI;
    private Timer timerScript;
=======
    private Timer timer;
    private WaveUI waveUI;
>>>>>>> 69624d517b739dc83532f1d1b3526aec5342ea34

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD
        waveUI = this.GetComponent<WaveUI>();
=======
        timer = this.GetComponent<Timer>();
        waveUI = this.GetComponent<WaveUI>();

        waveUI.CalculateWaveUISpeed(timer.GetTime());
>>>>>>> 69624d517b739dc83532f1d1b3526aec5342ea34
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
