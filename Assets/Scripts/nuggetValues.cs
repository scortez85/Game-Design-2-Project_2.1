using UnityEngine;
using System.Collections;

public class nuggetValues : MonoBehaviour {

    public int nuggetValue;
    public bool moveToPlayer;
    public GameObject coin, bag;
	void Start () {
        if (nuggetValue<=20)
        {
            coin.SetActive(true);
            bag.SetActive(false);
        }
        else
        {
            coin.SetActive(false);
            bag.SetActive(true);
        }
	
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
