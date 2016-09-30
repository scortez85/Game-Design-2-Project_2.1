using UnityEngine;
using System.Collections;

public class HashID : MonoBehaviour {

    public int speed;
	void Start () {
        speed = Animator.StringToHash("speed");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
