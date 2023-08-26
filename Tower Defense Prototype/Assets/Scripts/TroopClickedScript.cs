using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TroopClickedScript : MonoBehaviour
{
    private GameObject troop;

    private Camera mainCam;
    private LayerMask layerMask = ~(1 << 6);
    
    private GameObject selectedTroop = null;
    private GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
        gameManager = GameObject.FindGameObjectWithTag("Game Manager");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            TroopClickedCheck();
        }

        
    }

    private void TroopClickedCheck()
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            if (!IsPointerOverUIObject() && hit.transform.gameObject.tag == "Troop Sphere Collider")
            {
                if (!selectedTroop)
                {
                    selectedTroop = hit.transform.gameObject;
                    selectedTroop.GetComponent<TroopShowRangeScript>().changeEnabled();
                    selectedTroop.GetComponentInChildren<TroopManagerScript>().SetIsTroopSelected(true);
                }
                else if (selectedTroop != hit.transform.gameObject)
                {
                    selectedTroop.GetComponent<TroopShowRangeScript>().changeEnabled();
                    selectedTroop.GetComponentInChildren<TroopManagerScript>().SetIsTroopSelected(false);
                    selectedTroop = hit.transform.gameObject;
                    selectedTroop.GetComponent<TroopShowRangeScript>().changeEnabled();
                    selectedTroop.GetComponentInChildren<TroopManagerScript>().SetIsTroopSelected(true);
                }

                if (gameManager.GetComponent<GridClickedScript>().IsTroopSelected())
                {
                    gameManager.GetComponent<GridClickedScript>().troopDeselect();
                }
            }
            else if(selectedTroop)
            {
                selectedTroop.GetComponent<TroopShowRangeScript>().changeEnabled();
                selectedTroop.GetComponentInChildren<TroopManagerScript>().SetIsTroopSelected(false);
                selectedTroop = null;
            }
        }
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
