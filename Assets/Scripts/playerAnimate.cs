using UnityEngine;
using System.Collections;

public class playerAnimate : MonoBehaviour {
    public Animator ani;
    public HashID hash;
    public bool winRound;
    
	void Start () {
        ani = GetComponent<Animator>();
        hash = GetComponent<HashID>();
	
	}
	
	// Update is called once per frame
	void Update () {
        //movement
        float vert = Input.GetAxis("Vertical");
        float horiz = Input.GetAxis("Horizontal");
        float strafe = Input.GetAxis("Strafe");

        if (!vert.Equals(0))
        {
            ani.SetFloat(hash.speed, 5 * vert);
            ani.SetBool(hash.dance, false);
        }
        else ani.SetFloat(hash.speed, 0);

        //shoot
        if (Input.GetButton("Fire1"))
        {
            ani.SetBool(hash.shoot, true);
            ani.SetBool(hash.dance, false);
        }
        else
        {
            ani.SetBool(hash.shoot, false);
            ani.SetBool(hash.dance, false);
        }

        //dance
        if (Input.GetButton("Jump") || winRound)
            ani.SetBool(hash.dance, true);
        else ani.SetBool(hash.dance, false);

        //strafe
        ani.SetFloat(hash.strafe, strafe);

    }
}
