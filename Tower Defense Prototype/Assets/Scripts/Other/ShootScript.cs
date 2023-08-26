using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    private TroopManagerScript objectParent;

    private GameObject bullet;
    private IEnumerator coroutine;
    private Transform bulletSpawner;

    private float fireRate;
    private float damage = 0;

    private bool hasATarget = false;
    private GameObject enemyTarget;

    // Start is called before the first frame update
    void Start()
    {
        objectParent = this.transform.parent.gameObject.GetComponent<TroopManagerScript>();
        bulletSpawner = this.transform.parent.parent.GetChild(1);
        bullet = Resources.Load(objectParent.getBulletFilePath()) as GameObject;

        fireRate = objectParent.getFireRate();
        damage = objectParent.getDamage();

        coroutine = shoot();
        StartCoroutine(coroutine);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator shoot()
    {
        while (enabled)
        {
            if (hasATarget && enemyTarget != null)
            {
                GameObject bulletObject = Instantiate(bullet);
                bulletObject.transform.SetParent(bulletSpawner);
                bulletObject.transform.localPosition = Vector3.zero;
                bulletObject.transform.localScale = new Vector3(.2f, .2f, .5f);
                bulletObject.GetComponent<BasicBulletMovementScript>().targetEnemy(enemyTarget.transform);
                bulletObject.GetComponent<DamageScript>().setDamage(this);
                bulletObject.GetComponent<DamageScript>().SetTargetObject(enemyTarget);

                yield return new WaitForSeconds(fireRate);
            }
            else
                yield return new WaitForSeconds(.1f);
        }
    }

    public void enemyTargeted(GameObject enemy)
    {
        enemyTarget = enemy;
        hasATarget = true;
    }

    public void noMoreEnemies()
    {
        hasATarget = false;
    }

    public void newTargetEnemy(GameObject enemy)
    {
        enemyTarget = enemy;
    }

    public void upgradeShooting()
    {
        bullet = Resources.Load(objectParent.getBulletFilePath()) as GameObject;

        fireRate = objectParent.getFireRate();
        damage = objectParent.getDamage();
    }

    public float getDamage()
    {
        return this.damage;
    }
}
