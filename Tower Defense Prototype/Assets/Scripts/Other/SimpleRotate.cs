using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotate : MonoBehaviour
{
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotateTroop(enemy.transform.position);
    }
    public void rotateTroop(Vector3 pointTowards)
    {
        this.transform.LookAt(pointTowards);
    }
}
