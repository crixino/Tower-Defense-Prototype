using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    private float damage = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setDamage(ShootScript shootScript)
    {
        this.damage = shootScript.getDamage();
    }

    public float getDamage()
    {
        return this.damage;
    }
}
