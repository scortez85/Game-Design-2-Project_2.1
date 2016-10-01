using UnityEngine;
using System.Collections;

public class HashID : MonoBehaviour {

    public int speed,shoot,dance;
	void Start () {
        speed = Animator.StringToHash("speed");
        shoot = Animator.StringToHash("shoot");
        dance = Animator.StringToHash("dance");
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
