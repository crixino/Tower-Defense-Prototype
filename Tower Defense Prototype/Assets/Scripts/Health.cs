using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int maxHealth = 60;

    private int currentHealth;

    public event Action<float> OnHealthPctChanged = delegate { };


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
            this.GetComponent<EnemyMovementScript>().destroyThisObject();
        
    }


    public void ModifyHealth(int amount)
    {
        currentHealth += amount;

        float currentHealthPct = (float)currentHealth / (float)maxHealth;
        OnHealthPctChanged(currentHealthPct);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            ModifyHealth((int)other.GetComponent<DamageScript>().getDamage());
            

            Destroy(other.gameObject);
        }
    }
}
