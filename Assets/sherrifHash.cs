using UnityEngine;
using System.Collections;

public class sherrifHash : MonoBehaviour {

    public int hasTarget;
	void Start () {
        hasTarget = Animator.StringToHash("hasTarget");
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
