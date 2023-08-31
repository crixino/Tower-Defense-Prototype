using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveUI : MonoBehaviour
{
    [SerializeField]
    private GameObject waveUIParent;

    [SerializeField]
    Vector3 increaseValues;
    Vector3 defaultValue;

    int waveIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        defaultValue = waveUIParent.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        MoveUI();
    }

    private void MoveUI()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            if (waveUIParent.GetComponent<RectTransform>().localPosition.x > -50)
            {
                waveUIParent.GetComponent<RectTransform>().localPosition -= increaseValues * Time.deltaTime;
            }

            else if(waveUIParent.transform.childCount > waveIndex)
            {
                UpdateIndex();
                waveUIParent.GetComponent<RectTransform>().localPosition = defaultValue;
            }
        }
    }

    private void UpdateIndex()
    {
        waveUIParent.transform.GetChild(waveIndex).gameObject.SetActive(false);
        waveIndex++;
    }
}
