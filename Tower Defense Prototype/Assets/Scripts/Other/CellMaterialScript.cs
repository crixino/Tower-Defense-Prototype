using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellMaterialScript : MonoBehaviour
{
    private GameObject gameManager;
    private bool isActive = false;
    private bool isCellOccupied = false;

    [SerializeField]
    private Material cellMaterial;
    [SerializeField]
    private Material activeMaterial;
    [SerializeField]
    private Material cellNoTroopSelectedMaterial;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("Game Manager");
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive)
            checkIfHovered();
    }

    private void checkIfHovered()
    {
        if(gameManager.GetComponent<GridClickedScript>().cellActiveName() != this.name)
        {
            this.GetComponentInChildren<MeshRenderer>().material = cellMaterial;
            this.isActive = false;
        }
    }

    public void setToActive()
    {
        isActive = true;
        this.GetComponentInChildren<MeshRenderer>().material = activeMaterial;
    }

    public void setToNoTroopActive()
    {
        isActive = true;
        this.GetComponentInChildren<MeshRenderer>().material = cellNoTroopSelectedMaterial;
    }

    public bool getIsCellOccupied()
    {
        return this.isCellOccupied;
    }

    public void setIsCellOccupied(bool isCellOccupied)
    {
        this.isCellOccupied = isCellOccupied;
    }
}
