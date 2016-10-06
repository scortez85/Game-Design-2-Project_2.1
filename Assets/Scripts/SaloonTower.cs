using UnityEngine;
using System.Collections;

public class SaloonTower : Tower
{
    public SaloonTower() : base()
    {
        cost = 500;
        range = 30;
        damage = 50;
        speed = 2;
    }

    protected override void ExtraActions()
    {
        GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");
        for (int i = 0; i < towers.Length; i++)
        {
            //see if friendly tower is in range
            if (Vector3.Distance(towers[i].transform.position, transform.position) < range)
            {
                towers[i].GetComponent<Tower>().GiveBuff(0.2, 0.3, 2);
                Debug.DrawLine(transform.position, towers[i].transform.position);
            }
        }
    }

    protected override void Attack(GameObject target)
    {
        //saloon has no attack code        
    }
}
