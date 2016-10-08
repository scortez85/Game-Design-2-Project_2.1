using UnityEngine;
using System.Collections;

public class nuggetValues : MonoBehaviour {

    public int nuggetValue;
    public bool moveToPlayer;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (moveToPlayer)
        {
            transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
            GetComponent<Rigidbody>().velocity = transform.forward * 50;
        }
	
	}
}
