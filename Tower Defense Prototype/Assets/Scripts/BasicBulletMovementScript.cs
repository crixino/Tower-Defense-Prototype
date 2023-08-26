using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBulletMovementScript : MonoBehaviour
{
    private Transform enemy;
    private bool hasTarget = false;
    private float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hasTarget && enemy != null)
            moveTowardsEnemy();
        else
            Destroy(this.gameObject);
    }

    public void targetEnemy(Transform enemy)
    {
        //Debug.Log("enemy: " + enemy.name);
        this.enemy = enemy;
        hasTarget = true;
    }

    private void moveTowardsEnemy()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, enemy.position, speed * Time.deltaTime);
        this.transform.LookAt(enemy);
    }


}
