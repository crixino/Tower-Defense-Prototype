using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    private int enemyID;
    private string name;
    private int health;
    private float movementSpeed;
    private MovementType movementType;
    private string prefabLocation;

    public Enemy(int enemyID, string enemyName, int health, float movementSpeed, MovementType movementType, string prefabLocation)
    {
        this.enemyID = enemyID;
        this.name = enemyName;
        this.health = health;
        this.movementSpeed = movementSpeed;
        this.movementType = movementType;
        this.prefabLocation = prefabLocation;
    }

    public int GetEnemyID() { return enemyID; }
    public string GetEnemyName() { return name; }
    public int GetHealth() { return health; }
    public float GetMovementSpeed() {  return movementSpeed; }
    public MovementType GetMovementType() { return movementType; }
    public string GetPrefabLocation() {  return prefabLocation; }

}
