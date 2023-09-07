using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDatabase : MonoBehaviour
{
    private List<Enemy> enemies = new List<Enemy>();

    // Start is called before the first frame update
    void Awake()
    {
        BuildDatabase();
    }

    private void BuildDatabase()
    {
        enemies = new List<Enemy>
        {
            new Enemy(0, "Enemy1", 50, 1.6f, MovementType.GROUND, "Prefabs/Enemy1"),
            new Enemy(1, "Enemy2", 60, 1.6f, MovementType.GROUND, "Prefabs/Enemy2"),
            new Enemy(2, "Enemy3", 70, 1.6f, MovementType.GROUND, "Prefabs/Enemy3"),
            new Enemy(3, "Enemy1", 80, 1.6f, MovementType.GROUND, "Prefabs/Enemy1"),
            new Enemy(4, "Enemy2", 50, 5f, MovementType.GROUND, "Prefabs/Enemy2"),
            new Enemy(5, "Enemy3", 70, 1.6f, MovementType.GROUND, "Prefabs/Enemy3"),
            new Enemy(6, "Enemy1", 80, 1.6f, MovementType.GROUND, "Prefabs/Enemy1"),
            new Enemy(7, "Enemy2", 95, 5f, MovementType.GROUND, "Prefabs/Enemy2"),
            new Enemy(8, "Enemy3", 100, 1.6f, MovementType.GROUND, "Prefabs/Enemy3"),
            new Enemy(9, "Enemy1", 100, 1.6f, MovementType.GROUND, "Prefabs/Enemy1"),
            new Enemy(10, "Enemy2", 75, 5f, MovementType.GROUND, "Prefabs/Enemy2"),
        };
    }

    public Enemy GetEnemy(int id)
    {
        return enemies.Find(enemy => enemy.GetEnemyID() == id);
    }

    public Enemy GetEnemy(string enemyName)
    {
        return enemies.Find(enemy => enemy.GetEnemyName() == enemyName);
    }
}
