using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    private WaveUI waveUI;
    private Timer timerScript;

    // Start is called before the first frame update
    void Start()
    {
        waveUI = this.GetComponent<WaveUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
