using UnityEngine;
using System.Collections;

public class CactusTower : Tower
{
    public CactusTower() : base()
    {
        cost = 300;
        range = 20;
        damage = 50;
        speed = 0.5;
    }

    protected override void Attack(GameObject target)
    {
        //run attack code
        if (timeSinceLastShot <= 0)
        {
            Vector3[] offsets = { new Vector3(1,1,0), new Vector3(-1,1,0), new Vector3(0,1,1), new Vector3(0,1,-1),
                                  new Vector3(Mathf.Sqrt(2),1,-Mathf.Sqrt(2)), new Vector3(-Mathf.Sqrt(2),1,-Mathf.Sqrt(2)), new Vector3(Mathf.Sqrt(2),1,Mathf.Sqrt(2)), new Vector3(-Mathf.Sqrt(2),1,Mathf.Sqrt(2))};
            GameObject[] bullet = new GameObject[8];
            for (int i = 0; i < 8; i++)
            {
                bullet[i] = (GameObject)Instantiate(bulletPrefab, transform.position + 1 * offsets[i], Quaternion.Euler(0, 90*i, 0));
                bullet[i].GetComponent<Rigidbody>().velocity = bullet[i].transform.forward * 200.0f;
                bullet[i].GetComponent<Bullet>().SetDamage(damage + damageBuff);
                Destroy(bullet[i], 1);
            }
            timeSinceLastShot = 60 / (speed + speedBuff);
        }
    }
}
