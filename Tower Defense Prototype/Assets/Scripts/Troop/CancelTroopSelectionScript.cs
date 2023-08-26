using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelTroopSelectionScript : MonoBehaviour
{
    private GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("Game Manager");
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        gameManager.GetComponent<GridClickedScript>().troopDeselect();
    }
}
