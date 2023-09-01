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

    private int waveIndex = 0;

    private int totalWaves;

    private

    private float cellSize;

    private bool startWaves = false;


    // Start is called before the first frame update
    void Start()
    {
        totalWaves = waveUIParent.transform.childCount;
        defaultValue = waveUIParent.transform.localPosition;
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
            if (waveUIParent.GetComponent<RectTransform>().localPosition.x > -50)
            {
                waveUIParent.GetComponent<RectTransform>().localPosition -= increaseValues * Time.deltaTime;
            }
<<<<<<< HEAD

            else if(totalWaves > waveIndex)
            {
                UpdateIndex();
                waveUIParent.GetComponent<RectTransform>().localPosition = defaultValue;
            }
=======
>>>>>>> 69624d517b739dc83532f1d1b3526aec5342ea34
        }

        /*else if(waveUIParent.transform.childCount > waveIndex)
        {
            NextWaveUI();
        }*/
    }

    private void UpdateIndex()
    {
        waveUIParent.transform.GetChild(waveIndex).gameObject.SetActive(false);
        waveIndex++;
    }

<<<<<<< HEAD
    public int GetWaveCount()
    {
        return totalWaves;
=======
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
>>>>>>> 69624d517b739dc83532f1d1b3526aec5342ea34
    }
}
