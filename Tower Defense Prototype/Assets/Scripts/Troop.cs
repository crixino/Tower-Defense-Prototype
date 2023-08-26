using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troop
{
    private int id;
    private string troopName;
    private string description;
    private string filePathLocation;
    private Dictionary<string, float> stats = new Dictionary<string, float>();
    private string nextLevelName;

    public Troop(int id, string troopName, string description, string filePathLocation, Dictionary<string, float> stats, string nextLevelName)
    {
        this.id = id;
        this.troopName = troopName;
        this.description = description;
        this.filePathLocation = filePathLocation;
        this.stats = stats;
        this.nextLevelName = nextLevelName;
    }

    public Troop(Troop troop)
    {
        this.id = troop.id;
        this.troopName = troop.troopName;
        this.description = troop.description;
        this.filePathLocation = troop.filePathLocation;
        this.stats = troop.stats;
        this.nextLevelName = troop.nextLevelName;
    }

    public int getTroopId()
    {
        return this.id;
    }

    public string getTroopName()
    {
        return this.troopName;
    }

    public string getNextLevelName()
    {
        return this.nextLevelName;
    }

    public string getDescription()
    {
        return this.description;
    }

    public string getFilePath()
    {
        return this.filePathLocation;
    }

    public float getSpecificStat(string statName)
    {
        float value;
        if (this.stats.TryGetValue(statName, out value))
            return value;
        else
            return 0;
    }
}
