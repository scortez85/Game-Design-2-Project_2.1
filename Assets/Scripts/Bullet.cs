using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    private int damage;
    private int health;

    public Bullet()
    {
        damage = 50;
        health = 1;
    }


	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(health <= 0)
        {
            Destroy(gameObject);
        }
	}

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    public int GetDamage()
    {
        return damage;
    }

    public void SubrtractHealth(int health)
    {
        this.health -= health;
    }
}
