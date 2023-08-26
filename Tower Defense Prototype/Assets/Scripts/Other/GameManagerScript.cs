using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    private List<GameObject> troops = new List<GameObject>(50);

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

    public void OnCancelTroopSelection()
    {
        this.GetComponent<GridClickedScript>().troopDeselect();
    }
}
