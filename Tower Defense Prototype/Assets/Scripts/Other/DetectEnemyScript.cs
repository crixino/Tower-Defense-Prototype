using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectEnemyScript : MonoBehaviour
{
    private TroopMovementScript troopMovementScript;
    private TroopManagerScript troopManagerScript;
    private bool enemyDetected = false;
    private GameObject enemyPos;

    private List<Transform> enemyTransforms = new List<Transform>(50);
    private int enemyTransformListCount = 0;

    private float range = 0;

    // Start is called before the first frame update
    void Start()
    {
        troopMovementScript = this.GetComponentInParent<TroopMovementScript>();
        troopManagerScript = this.GetComponentInParent<TroopManagerScript>();
        updateRange();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyDetected && enemyPos != null)
        {
            aimAtEnemy();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            enemyTransforms.Add(other.transform);
            enemyTransformListCount++;
            if (!enemyDetected)
            {
                enemyPos = other.gameObject;
                
                enemyDetected = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        enemyTransforms.Remove(other.transform);
        enemyTransformListCount--;

        if (enemyTransforms.Count == 0)
        {
            enemyDetected = false;
            this.GetComponent<ShootScript>().noMoreEnemies();
        }
        else
            enemyPos = GetClosestEnemy(enemyTransforms, this.transform).gameObject;
    }

    private void aimAtEnemy()
    {
        troopMovementScript.rotateTroop(enemyPos.transform.position);
        this.GetComponent<ShootScript>().enemyTargeted(enemyPos);
    }

    Transform GetClosestEnemy(List<Transform> enemies, Transform fromThis)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = fromThis.position;
        foreach (Transform potentialTarget in enemies)
        {
            if (potentialTarget != null)
            {
                Vector3 directionToTarget = potentialTarget.position - currentPosition;
                float dSqrToTarget = directionToTarget.sqrMagnitude;
                if (dSqrToTarget < closestDistanceSqr)
                {
                    closestDistanceSqr = dSqrToTarget;
                    bestTarget = potentialTarget;
                }
            }
        }
        return bestTarget;
    }

    public void enemyDestroyed(GameObject enemy)
    {
        if (enemyTransformListCount > 1 && enemyPos == enemy)
        {
            enemyTransforms.Remove(enemy.transform);
            this.enemyTransformListCount--;
            enemyPos = GetClosestEnemy(enemyTransforms, this.transform).gameObject;
        }
        else if (enemyTransformListCount == 1 && enemyPos == enemy)
        {
            enemyTransforms.Remove(enemy.transform);
            this.enemyTransformListCount--;
            enemyDetected = false;
            this.GetComponent<ShootScript>().noMoreEnemies();
        }
        else if (enemyTransforms.Contains(enemy.transform))
        {
            enemyTransforms.Remove(enemy.transform);
            this.enemyTransformListCount--;
        }
        
    }

    public void updateRange()
    {
        range = troopManagerScript.getRange();
        this.GetComponent<SphereCollider>().radius = range;
    }
}
