using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    private List<GameObject> troops = new List<GameObject>(50);

    private void Awake()
    {
        EventSystem.current.enabled = false;
        LoadSceneAdditively("MainMenuScene");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addTroopToList(GameObject troop)
    {
        troops.Add(troop);
    }

    public void deleteTroopFromList(GameObject troop)
    {
        troops.Remove(troop);
    }

    public void enemyDestroyed(GameObject enemy)
    {
        for(int i = 0; i<troops.Count; i++)
        {
            troops[i].GetComponentInChildren<DetectEnemyScript>().enemyDestroyed(enemy);
        }
    }

    public void enemyDestroyed(GameObject enemy, GameObject troop)
    {
        for (int i = 0; i < troops.Count; i++)
        {
            if (troops[i] != troop)
                troops[i].GetComponentInChildren<DetectEnemyScript>().enemyDestroyed(enemy);
        }
    }
    public void OnCancelTroopSelection()
    {
        this.GetComponent<GridClickedScript>().troopDeselect();
    }

    private static void LoadSceneAdditively(string name)
    {
        SceneManager.LoadScene(name, LoadSceneMode.Additive);
    }
}
