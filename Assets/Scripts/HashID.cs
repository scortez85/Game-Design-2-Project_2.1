using UnityEngine;
using System.Collections;

public class HashID : MonoBehaviour {

    public int speed,shoot,dance,strafe;
	void Start () {
        speed = Animator.StringToHash("speed");
        shoot = Animator.StringToHash("shoot");
        dance = Animator.StringToHash("dance");
        strafe = Animator.StringToHash("strafe");
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
