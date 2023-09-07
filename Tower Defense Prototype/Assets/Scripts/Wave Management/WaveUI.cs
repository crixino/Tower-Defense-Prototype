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
    private GameObject waveUIPrefab;

    private WaveManager waveManager;

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
        waveManager = GetComponent<WaveManager>();

        CreateWaveUI();
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
                this.waveManager.SetIsLastWave(true);
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

    public void CreateWaveUI()
    {
        GameObject waveUI;
        for(int i = 0; i < waveManager.GetNumberOfWaves(); i++)
        {
            waveUI = Instantiate(waveUIPrefab);
            waveUI.transform.SetParent(waveUIParent.transform);
            
            SetWaveUIColor(waveUI, i);
            SetWaveUINumber(waveUI, i + 1);
        }
    }

    private void SetWaveUINumber(GameObject wave, int waveNumber)
    {
        wave.GetComponentInChildren<TextMeshProUGUI>().text = "" + waveNumber;
    }

    private void SetWaveUIColor(GameObject wave, int waveNumber)
    {
        if (waveNumber % 2 == 0)
        {
            wave.GetComponent<Image>().color = Color.black;
            wave.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
        }
        else
            wave.GetComponent<Image>().color = Color.white;
    }
}
