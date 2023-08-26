
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopManagerScript : MonoBehaviour
{
    private GameObject gameManager;
    private Troop troop;
    private GameObject cell;
    [SerializeField]
    private GameObject troopLevelObject;
    [SerializeField]
    private GameObject troopLevelObjectSelected;

    private float damage, fireRate, range;
    private string description, nextLevelName, bulletFilePath;

    private int troopLevel = 1;
    private bool isTroopSelected = false;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("Game Manager");
        troop = gameManager.GetComponent<TroopDatabase>().GetTroop(this.name);

        setUpTroopStats();
        levelObjectStart();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U) && isTroopSelected)
            upgradeTroop();
    }

    public string getNextLevelName()
    {
        return this.nextLevelName;
    }

    public string getDescription()
    {
        return this.description;
    }

    public string getBulletFilePath()
    {
        return this.bulletFilePath;
    }

    public float getFireRate()
    {
        return fireRate;
    }

    public float getDamage()
    {
        return damage;
    }

    public float getRange()
    {
        return range;
    }

    public void upgradeTroop()
    {
        if (nextLevelName != "none")
        {
            troopLevel++;
            troop = gameManager.GetComponent<TroopDatabase>().GetTroop(this.nextLevelName);
            this.name = nextLevelName;

            setUpTroopStats();

            this.GetComponentInChildren<ShootScript>().upgradeShooting();
            this.GetComponentInChildren<DetectEnemyScript>().updateRange();
            troopLevelObjectIncreased(troopLevel);
        }
    }

    private void setUpTroopStats()
    {
        damage = troop.getSpecificStat("Damage");
        fireRate = troop.getSpecificStat("Fire Rate");
        range = troop.getSpecificStat("Range");
        description = troop.getDescription();
        nextLevelName = troop.getNextLevelName();
        bulletFilePath = troop.getFilePath();
    }

    public void setCell(GameObject cell)
    {
        this.cell = cell;
    }

    public GameObject getCell()
    {
        return this.cell;
    }

    private void levelObjectStart()
    {
        for(int i=1; i<=4; i++)
        {
            this.troopLevelObject.transform.GetChild(i).gameObject.SetActive(false);
            this.troopLevelObjectSelected.transform.GetChild(i).gameObject.SetActive(false);
        }
        this.troopLevelObjectSelected.SetActive(false);
    }

    private void troopLevelObjectIncreased(int level)
    {
        this.troopLevelObject.transform.GetChild(level-1).gameObject.SetActive(true);
        this.troopLevelObjectSelected.transform.GetChild(level - 1).gameObject.SetActive(true);
    }

    public void SetIsTroopSelected(bool isTroopSelected)
    {
       this.isTroopSelected = isTroopSelected;
       this.troopLevelObjectSelected.SetActive(isTroopSelected);
       this.troopLevelObject.SetActive(!isTroopSelected);
    }
}
