using UnityEngine;
using System.Collections;

public class playerShoot : MonoBehaviour {

    public GameObject bulletPrefab, gunLocation;
    public float shootTime, reloadTime;
    public int damage,playerScoreValue;
    public AudioSource sfxSource;
    public AudioClip shootSfx,moneySfx;
    void Start () {
        this.damage = 50;
        this.playerScoreValue = damage + 50;
        sfxSource = GetComponent<AudioSource>();
        sfxSource.clip = shootSfx;

    }

    // Update is called once per frame
    void Update () {
        
            
        if (shootTime > 0)
            shootTime--;
        if (Input.GetButton("Fire1") && shootTime.Equals(0))
        {
            sfxSource.clip = shootSfx;
            sfxSource.Play();

            GameObject bullet = (GameObject)Instantiate(bulletPrefab, gunLocation.transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody>().velocity = transform.forward * 200.0f;
            bullet.GetComponent<Bullet>().SetDamage(damage);
            bullet.GetComponent<Bullet>().setScoreValue(playerScoreValue);
            Destroy(bullet, 2);
            shootTime = reloadTime;
        }
	
	}
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("Nugget"))
        {
            sfxSource.clip = moneySfx;
            sfxSource.Play();

        }


    }
    void OnTriggerExit()
    {
    }
}
