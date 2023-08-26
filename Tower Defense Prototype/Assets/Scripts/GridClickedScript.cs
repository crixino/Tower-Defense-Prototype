using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GridClickedScript : MonoBehaviour
{
    [SerializeField]
    private Transform troopParent;
    [SerializeField]
    private Material greenMaterial;
    [SerializeField]
    private Material cellMaterial;

    private GameObject troop;

    private Camera mainCam;
    private LayerMask layerMask = ~(1 << 6);
    
    private GameObject prevCell = null;

    private bool isTroopSelected = false;
    private GameObject troopAvailabelUIObject;
    private int lastBtnIndex = -1;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
        troop = Resources.Load("Prefabs/Troop") as GameObject;
        troopAvailabelUIObject = GameObject.FindGameObjectWithTag("Troop Available UI").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTroopSelected && Input.GetKeyDown(KeyCode.Mouse0))
        {
            TroopPlacement();
        }

        HoverCheck();
    }

    private void TroopPlacement()
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            if (!IsPointerOverUIObject() && hit.transform.gameObject.tag == "Cell" && !hit.transform.GetComponent<CellMaterialScript>().getIsCellOccupied())
            {
                placeTroop(hit.transform);
            }
        }
    }

    private void HoverCheck()
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (isTroopSelected && Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            if (hit.transform.gameObject.tag == "Cell")
            {

                if (!prevCell && !hit.transform.GetComponent<CellMaterialScript>().getIsCellOccupied())
                {
                    prevCell = hit.transform.gameObject;
                    prevCell.GetComponent<CellMaterialScript>().setToActive();
                }
                else if (prevCell && prevCell.name != hit.transform.gameObject.name)
                {
                    prevCell = null;
                }
            }
            else
            {
                prevCell = null;
            }
        }
        else if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            if (hit.transform.gameObject.tag == "Cell")
            {

                if (!prevCell && !hit.transform.GetComponent<CellMaterialScript>().getIsCellOccupied())
                {
                    prevCell = hit.transform.gameObject;
                    prevCell.GetComponent<CellMaterialScript>().setToNoTroopActive();
                }
                else if (prevCell && prevCell.name != hit.transform.gameObject.name)
                {
                    prevCell = null;
                }
            }
            
        }
        else
        {
            prevCell = null;
        }
    }

    private void placeTroop(Transform cell)
    {
        GameObject troopObject = Instantiate(troop);
        
        troopObject.transform.SetParent(troopParent);
        troopObject.transform.localPosition = new Vector3(cell.position.x, 1f, cell.transform.position.z);
        troopObject.GetComponentInChildren<TroopMovementScript>().rotateTroopAtStart();
        this.GetComponent<GameManagerScript>().addTroopToList(troopObject);
        cell.GetComponent<CellMaterialScript>().setIsCellOccupied(true);

    }

    private void changeMaterial(GameObject cell, Material material)
    {
        cell.GetComponentInChildren<MeshRenderer>().material = material;
    }

    public string cellActiveName()
    {
        if (prevCell)
            return prevCell.name;
        else
            return "";
    }

    public void troopSelectedButton(int btnIndex)
    {
        if (isTroopSelected)
        {
            troopDeselect();
        }
        else
        {
            lastBtnIndex = btnIndex;
            isTroopSelected = true;
            troopAvailabelUIObject.transform.GetChild(btnIndex).GetComponent<Image>().color = Color.green;
            this.GetComponent<UIManagerScript>().enableCancelTroopSelectionObject();
        }
    }

    public void troopDeselect()
    {
        isTroopSelected = false;
        changeTroopBtnColorToDefault(lastBtnIndex);
        this.GetComponent<UIManagerScript>().disableCancelTroopSelectionObject();
    }

    private void changeTroopBtnColorToDefault(int btnIndex)
    {
        troopAvailabelUIObject.transform.GetChild(btnIndex).GetComponent<Image>().color = Color.white;
    }

    public bool IsTroopSelected()
    {
        return isTroopSelected;
    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
