using UnityEngine;
using System.Collections;

public class selectableProp : MonoBehaviour {

    public Vector3 propPos;
    public RaycastHit hit;

    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000.0f))
        {
            if (hit.collider.gameObject.tag.Equals("Terrain"))
            {
                propPos.x = hit.transform.position.x;
                propPos.z = hit.transform.position.z;
                propPos.y = 3.84f;
            }
        }   
        

        transform.position = hit.point  ;
	
	}
}
