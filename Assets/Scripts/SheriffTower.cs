using UnityEngine;
using System.Collections;

public class SheriffTower : Tower
{
    public GameObject sherrifObj;
    public Animator ani;
    public sherrifHash sherrifHashId;

    public SheriffTower() : base()
    {

        this.cost = 500;
        range = 30;
        damage = 50;
        speed = 2;
    }
    void Start()
    {
        ani = GetComponent<SheriffTower>().sherrifObj.GetComponent<Animator>();
        sherrifHashId = GetComponent<sherrifHash>();
    }

    protected override void ExtraActions()
    {
        GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");
        for (int i = 0; i < towers.Length; i++)
        {
            //see if friendly tower is in range
            if (Vector3.Distance(towers[i].transform.position, transform.position) < range)
            {
                towers[i].GetComponent<Tower>().GiveBuff(0, 0.3, 0);
                Debug.DrawLine(transform.position, towers[i].transform.position);
            }
        }
    }

    protected override void Attack(GameObject target)
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
            //transform.rotation = new Quaternion(0, 0, 0, 0);
            //Debug.Log("Hit");
            //sherrifObj.transform.LookAt(target.transform.position);
            
        }
        ani.SetBool(sherrifHashId.hasTarget, true);
    }
    void LateUpdate()
    {
        ani.SetBool(sherrifHashId.hasTarget, false);
    }
}
