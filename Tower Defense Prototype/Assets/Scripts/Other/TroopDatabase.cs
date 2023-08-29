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
            new Troop(4, "Small Cannon Level 5", "This is a cheap turret that shoots a small cannon at enemies.", "Prefabs/SmallCannonBullet", new Dictionary<string, float>
            {
                {"Damage", -20f },
                {"Fire Rate", .9f },
                {"Range", 18f }
            }
            ,"none"),
            new Troop(5, "Turret Level 1", "This is a cheap turret that shoots rapid fire at enemies.", "Prefabs/SmallCannonBullet", new Dictionary<string, float>
            {
                {"Damage", -3f },
                {"Fire Rate", 1f },
                {"Range", 8f }
            }
            ,"Turret Level 2"),
            new Troop(6, "Turret Level 2", "This is a cheap turret that shoots rapid fire at enemies.", "Prefabs/SmallCannonBullet", new Dictionary<string, float>
            {
                {"Damage", -5f },
                {"Fire Rate", .95f },
                {"Range", 10f }
            }
            ,"Turret Level 3"),
            new Troop(7, "Turret Level 3", "This is a cheap turret that shoots rapid fire at enemies.", "Prefabs/SmallCannonBullet", new Dictionary<string, float>
            {
                {"Damage", -7f },
                {"Fire Rate", .9f },
                {"Range", 14f }
            }
            ,"Turret Level 4"),
            new Troop(8, "Turret Level 4", "This is a cheap turret that shoots rapid fire at enemies.", "Prefabs/SmallCannonBullet", new Dictionary<string, float>
            {
                {"Damage", -10f },
                {"Fire Rate", .8f },
                {"Range", 18f }
            }
            ,"Turret Level 5"),
            new Troop(9, "Turret Level 5", "This is a cheap turret that shoots rapid fire at enemies.", "Prefabs/SmallCannonBullet", new Dictionary<string, float>
            {
                {"Damage", -14f },
                {"Fire Rate", .7f },
                {"Range", 20f }
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
