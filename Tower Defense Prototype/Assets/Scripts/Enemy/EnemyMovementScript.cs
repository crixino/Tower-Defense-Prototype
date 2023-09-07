using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementScript : MonoBehaviour
{
    private Transform goal;
    private GameObject gameManager;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("Game Manager");
        goal = GameObject.FindGameObjectWithTag("Goal").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.destination = new Vector3(this.transform.position.x, goal.position.y, goal.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (goal.position.z - this.transform.position.z < 2)
        {
            destroyThisObject();
        }
    }

    public void destroyThisObject()
    {
            gameManager.GetComponent<GameManagerScript>().enemyDestroyed(this.gameObject);
            Destroy(this.transform.parent.gameObject);
    }

    public void SetEnemyMovementSpeed(float speed)
    {
        agent.speed = speed;
    }
}
