using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopDatabase : MonoBehaviour
{
    private List<Troop> troops = new List<Troop>();

    // Start is called before the first frame update
    void Awake()
    {
        BuildDatabase();
    }

    private void BuildDatabase()
    {
        troops = new List<Troop>
        {
            new Troop(0, "Small Cannon Level 1", "This is a cheap turret that shoots a small cannon at enemies.", "Prefabs/SmallCannonBullet", new Dictionary<string, float>
            {
                {"Damage", -5f },
                {"Fire Rate", 1.2f },
                {"Range", 6f }
            }
            ,"Small Cannon Level 2"),
            new Troop(1, "Small Cannon Level 2", "This is a cheap turret that shoots a small cannon at enemies.", "Prefabs/SmallCannonBullet", new Dictionary<string, float>
            {
                {"Damage", -8f },
                {"Fire Rate", 1.1f },
                {"Range", 8f }
            }
            ,"Small Cannon Level 3"),
            new Troop(2, "Small Cannon Level 3", "This is a cheap turret that shoots a small cannon at enemies.", "Prefabs/SmallCannonBullet", new Dictionary<string, float>
            {
                {"Damage", -12f },
                {"Fire Rate", 1f },
                {"Range", 12f }
            }
            ,"Small Cannon Level 4"),
            new Troop(3, "Small Cannon Level 4", "This is a cheap turret that shoots a small cannon at enemies.", "Prefabs/SmallCannonBullet", new Dictionary<string, float>
            {
                {"Damage", -14f },
                {"Fire Rate", .95f },
                {"Range", 16f }
            }
            ,"Small Cannon Level 5"),
            new Troop(0, "Small Cannon Level 5", "This is a cheap turret that shoots a small cannon at enemies.", "Prefabs/SmallCannonBullet", new Dictionary<string, float>
            {
                {"Damage", -20f },
                {"Fire Rate", .9f },
                {"Range", 18f }
            }
            ,"none"),
        };
    }

    public Troop GetTroop(int id)
    {
        return troops.Find(troop => troop.getTroopId() == id);
    }

    public Troop GetTroop(string troopName)
    {
        return troops.Find(troop => troop.getTroopName() == troopName);
    }
}
