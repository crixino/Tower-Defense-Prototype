using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyScript : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private Transform parent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            spawnPrefab();
    }

    private void spawnPrefab()
    {
        GameObject enemy = Instantiate(prefab);
        enemy.transform.SetParent(parent);
        enemy.transform.position = new Vector3(0, 0, 0);
    }
}
