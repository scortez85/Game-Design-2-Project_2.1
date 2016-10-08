using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Tower : MonoBehaviour {
    protected int cost; // purchase cost
    protected int damage; // per shot damage measure in health removed
    protected int range; // attack range
    protected double speed; // attack speed measured in shots per second
    protected int towerScoreValue; //score multiplier for tower
    protected double timeSinceLastShot;
    protected int rangeBuff;
    protected int damageBuff;
    protected double speedBuff;
    protected AttackPattern pattern;
    protected List<Upgrade> availableUpgrades; // all upgrades available to be added to this tower
    protected List<Upgrade> activeUpgrades; // all upgrades currently active on this tower
    public GameObject bulletPrefab;
    public GameObject towerRange;
    public bool selected;

    public enum AttackPattern {First, Last, Close, Strong};

    public Tower()
    {
        /*
         * TODO these numbers need to be tweaked to appropriate values
         * these are just placeholders
         * TODO come up with upgrade lists for towers
         */
        //basic tower
        cost = 100;
        range = 40;
        damage = 50;
        speed = 1;
        timeSinceLastShot = 0;
        rangeBuff = 0;
        damageBuff = 0;
        speedBuff = 0;
        pattern = AttackPattern.First;
        activeUpgrades = new List<Upgrade>();
        availableUpgrades = new List<Upgrade>();
        towerScoreValue = damage + 25;
    }

	// Use this for initialization
	void Start()
    {
        Vector3 rangeScale = new Vector3(range, 0, range);
        towerRange.transform.localScale = rangeScale;

	}
	
	// Update is called once per frame
	void Update()
    {
        ExtraActions();

        //show range
        if (selected)
            towerRange.GetComponent<MeshRenderer>().enabled = true;
        else towerRange.GetComponent<MeshRenderer>().enabled = false;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        bool hasTarget = false;
        GameObject target = new GameObject(); // might need to find a better way to instantiate an empty object
        for (int i = 0; i < enemies.Length; i++)
        {
            //see if enemy is in range
            if (Vector3.Distance(enemies[i].transform.position, transform.position) < range)
            {
                switch (pattern)
                {
                    case AttackPattern.First:
                        if (hasTarget)
                        {
                            // see if enemy is furter along than current target
                            if (enemies[i].GetComponent<Enemy>().GetDistanceToEnd() < target.GetComponent<Enemy>().GetDistanceToEnd())
                            {
                                Destroy(target);
                                target = enemies[i];
                            }
                        }
                        else
                        {
                            Destroy(target);
                            target = enemies[i];
                            hasTarget = true;
                        }
                        break;
                    case AttackPattern.Last:
                        if (hasTarget)
                        {
                            // see if enemy is not as far along as the current target
                            if (enemies[i].GetComponent<Enemy>().GetDistanceToEnd() > target.GetComponent<Enemy>().GetDistanceToEnd())
                            {
                                Destroy(target);
                                target = enemies[i];
                            }
                        }
                        else
                        {
                            Destroy(target);
                            target = enemies[i];
                            hasTarget = true;
                        }
                        break;
                    case AttackPattern.Close:
                        if (hasTarget)
                        {
                            // see if enemy is closer than current target
                            if (Vector3.Distance(enemies[i].transform.position, transform.position) < Vector3.Distance(target.transform.position, transform.position))
                            {
                                Destroy(target);
                                target = enemies[i];
                            }
                        }
                        else
                        {
                            Destroy(target);
                            target = enemies[i];
                            hasTarget = true;
                        }
                        break;
                    case AttackPattern.Strong:
                        if (hasTarget)
                        {
                            // see if enemy is stronger than current target
                            if (enemies[i].GetComponent<Enemy>().GetHealth() > target.GetComponent<Enemy>().GetHealth())
                            {
                                Destroy(target);
                                target = enemies[i];
                            }
                        }
                        else
                        {
                            Destroy(target);
                            target = enemies[i];
                            hasTarget = true;
                        }
                        break;
                }
            }
        }

        if (hasTarget)
        {
            Attack(target);
        }
        timeSinceLastShot--;

        //delete empty game object, prevents memory leak. 
        //we may want to find a way to avoid that all together
        if (!target.tag.Equals("Enemy"))
        {
            Destroy(target);
        }

        //reset buffs after each tick
        rangeBuff = 0;
        damageBuff = 0;
        speedBuff = 0;
    }

    public void UpgradeTower()
    {
        /* 
         * TODO: Move first upgrade from availabeUpgrades to activeUpgrades
         */
    }

    protected virtual void Attack(GameObject target)
    {
        //run attack code
            transform.LookAt(target.transform);
        Debug.DrawLine(transform.position, target.transform.position);
        if (timeSinceLastShot <= 0)
        {
            GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody>().velocity = transform.forward * 200.0f;
            bullet.GetComponent<Bullet>().SetDamage(damage + damageBuff);
            Destroy(bullet, 2);
            timeSinceLastShot = 60 / (speed + speedBuff);
        }
    }

    protected virtual void ExtraActions()
    {
        //tower has no extra actions
    }

    public void GiveBuff(double rangeBuffPercent, double damageBuffPercent, double speedBuffPercent)
    {
        rangeBuff += Convert.ToInt32(range * rangeBuffPercent);
        damageBuff += Convert.ToInt32(damage * damageBuffPercent);
        speedBuff += Convert.ToInt32(speed * speedBuffPercent);
    }

    //BEGIN getters
    public int GetCost()
    {
        return cost;
    }

    public int GetDamage()
    {
        return damage;
    }

    public int GetRange()
    {
        return range;
    }

    public double GetSpeed()
    {
        return speed;
    }
    //END getters

    //BEING setters
    public void setPattern(AttackPattern pattern)
    {
        this.pattern = pattern;
    }
    //END setters

    //maybe this should be its own file? but we can do that later
    protected class Upgrade
    {
        private int damageUp; // damage added to tower once upgrade is active
        private int rangeUp; // range added to tower once upgrade is active
        private int speedUp; // attack speed added to tower once upgrade is active
        private int cost; // cost to add this upgrade to the tower
        protected Upgrade(int rangeUp, int damageUp, int speedUp, int cost)
        {
            this.rangeUp = rangeUp;
            this.damageUp = damageUp;
            this.speedUp = speedUp;
            this.cost = cost;
        }

        private int GetDamageUpgrade()
        {
            return damageUp;
        }

        private int GetRangeUpgrade()
        {
            return rangeUp;
        }

        private int GetSpeedUpgrade()
        {
            return rangeUp;
        }
    }
}
