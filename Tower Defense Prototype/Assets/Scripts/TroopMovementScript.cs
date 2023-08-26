using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopMovementScript : MonoBehaviour
{
    private GameObject pathObject;

    // Start is called before the first frame update
    void Awake()
    {
        pathObject = GameObject.FindGameObjectWithTag("Path").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //rotateTroopAtStart();
    }

    public void rotateTroopAtStart()
    {
        this.transform.LookAt(pathObject.transform.position);
    }

    public void rotateTroop(Vector3 pointTowards)
    {
        this.transform.LookAt(pointTowards);
    }
}
