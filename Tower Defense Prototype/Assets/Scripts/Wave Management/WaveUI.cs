using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaveUI : MonoBehaviour
{
    [SerializeField]
    private GameObject waveUIParent;

    [SerializeField]
    Vector3 increaseValues;
    Vector3 defaultValue;

    int waveIndex = 0;

    private float cellSize;

    private bool startWaves = false;


    // Start is called before the first frame update
    void Start()
    {
        defaultValue = waveUIParent.transform.localPosition;

        SetWaveUINumbers();
    }

    // Update is called once per frame
    void Update()
    {
        MoveUI();
    }

    private void MoveUI()
    {
        if (startWaves)
        {
            if (waveUIParent.GetComponent<RectTransform>().localPosition.x > -50 && waveIndex + 1 != waveUIParent.transform.childCount)
            {
                waveUIParent.GetComponent<RectTransform>().localPosition -= increaseValues * Time.deltaTime;
            }
            else if(waveIndex + 1 == waveUIParent.transform.childCount)
            {
                this.GetComponent<WaveManager>().SetIsLastWave(true);
                this.startWaves = false;
            }
        }
    }

    private void UpdateIndex()
    {
        waveUIParent.transform.GetChild(waveIndex).gameObject.SetActive(false);
        waveIndex++;
    }

    public void NextWaveUI()
    {
        UpdateIndex();
        waveUIParent.GetComponent<RectTransform>().localPosition = defaultValue;
    }

    public void CalculateWaveUISpeed(float seconds)
    {
        cellSize = waveUIParent.GetComponent<GridLayoutGroup>().cellSize.x;
        increaseValues.x = cellSize/seconds;
    }

    public void StartWaves()
    {
        startWaves = true;
    }

    private void SetWaveUINumbers()
    {
        for(int i = 0; i <  waveUIParent.transform.childCount; i++)
        {
            waveUIParent.transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text = "" + (i+1);
        }
    }
}
