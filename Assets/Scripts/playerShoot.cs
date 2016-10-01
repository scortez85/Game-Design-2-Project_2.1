using UnityEngine;
using System.Collections;

public class playerShoot : MonoBehaviour {

    public GameObject bulletPrefab, gunLocation;
    public float shootTime, reloadTime;
    public int damage,playerScoreValue;
	void Start () {
        this.damage = 50;
        this.playerScoreValue = damage + 50;

    }

    // Update is called once per frame
    void Update () {
        if (shootTime > 0)
            shootTime--;
        if (Input.GetButton("Fire1") && shootTime.Equals(0))
        {
            GameObject bullet = (GameObject)Instantiate(bulletPrefab, gunLocation.transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody>().velocity = transform.forward * 200.0f;
            bullet.GetComponent<Bullet>().SetDamage(damage);
            bullet.GetComponent<Bullet>().setScoreValue(playerScoreValue);
            Destroy(bullet, 2);
            shootTime = reloadTime;
        }
	
	}
}
