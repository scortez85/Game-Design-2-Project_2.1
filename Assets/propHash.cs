using UnityEngine;
using System.Collections;

public class propHash : MonoBehaviour {

    public int ableToPlace;
	void Start () {
        ableToPlace = Animator.StringToHash("ableToPlace");

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
