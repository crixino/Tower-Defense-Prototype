using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopShowRangeScript : MonoBehaviour
{
    private GameObject sphere;
    [SerializeField]
    private SphereCollider sphereCollider;
    [SerializeField]
    private GameObject levelObjectSelected;
    [SerializeField]
    private GameObject levelObject;

    // Start is called before the first frame update
    void Start()
    {
        sphere = this.transform.GetChild(0).gameObject;
        checkRadius();
        changeEnabled();
    }

    // Update is called once per frame
    void Update()
    {
        checkRadius();
    }

    public void changeEnabled()
    {
        sphere.SetActive(!sphere.activeSelf);
    }

    private void checkRadius()
    {
        if(sphere.transform.localScale.x/2 != sphereCollider.radius)
        {
            sphere.transform.localScale = new Vector3(sphereCollider.radius * 2, -.1f, sphereCollider.radius * 2);
        }
    }

}
