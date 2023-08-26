using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject cancelTroopSelectionObject;

    // Start is called before the first frame update
    void Start()
    {
        disableCancelTroopSelectionObject();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void disableCancelTroopSelectionObject()
    {
        cancelTroopSelectionObject.SetActive(false);
    }

    public void enableCancelTroopSelectionObject()
    {
        cancelTroopSelectionObject.SetActive(true);
    }
}
