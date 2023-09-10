using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if(cancelTroopSelectionObject != null)
        cancelTroopSelectionObject.SetActive(false);
    }

    public void enableCancelTroopSelectionObject()
    {
        cancelTroopSelectionObject.SetActive(true);
    }

    public void MainMenuPlayBtn_Clicked()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("MainMenuScene"));
    }

    public void QuitToDesktopBtn_Clicked()
    {
        Application.Quit();
    }
}
