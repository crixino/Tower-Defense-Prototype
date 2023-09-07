using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave
{
    private int totalNumberOfEnemies;
    private string enemyPrefabLocation;
    private int enemiesLeft;
    private Enemy enemyStats;

    public Wave(Enemy enemyStats, int totalNumberOfEnemies)
    {
        this.enemyStats = enemyStats;
        this.totalNumberOfEnemies = totalNumberOfEnemies;
        this.enemyPrefabLocation = enemyStats.GetPrefabLocation();
        this.enemiesLeft = totalNumberOfEnemies;
    }

    public string GetEnemyPrefabLocation()
    {
        enemiesLeft--;
        return enemyPrefabLocation;
    }

    public Enemy GetEnemystats()
    {
        return enemyStats;
    }

    public int GetEnemiesLeft()
    {
        return enemiesLeft;
    }
}
