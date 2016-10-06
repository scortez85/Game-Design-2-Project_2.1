using UnityEngine;
using System.Collections;

public class playerMove : MonoBehaviour {

    private float speed, turning;
    private GameObject thirdCam,camAnchor;

	void Start () {
        speed = 20;
        turning = 100;
        thirdCam = GameObject.Find("thirdCam");
        camAnchor = GameObject.Find("cameraAnchor"); 
	
	}
	
	// Update is called once per frame
	void Update () {
        //set camera anchor
        thirdCam.transform.position = camAnchor.transform.position;
        thirdCam.transform.rotation = camAnchor.transform.rotation;

        //get input and move player
        float vert = Input.GetAxis("Vertical");
        float horiz = Input.GetAxis("Horizontal");
        float strafe = Input.GetAxis("Strafe");
        if (vert >0)
            transform.Translate(strafe * 4 * Time.deltaTime, 0, vert * Time.deltaTime * speed);
        else if (vert <0)
            transform.Translate(strafe * 4 * Time.deltaTime, 0, vert * Time.deltaTime * speed/2);
        transform.Rotate(0, horiz * Time.deltaTime * turning, 0);
	    transform.Translate(strafe * 15 * Time.deltaTime, 0, 0);
	}
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("Nugget"))
        {
            Destroy(col.gameObject);
            GameObject.Find("GameController").GetComponent<gameControl>().setNugget(col.gameObject.GetComponent<nuggetValues>().nuggetValue);
        }
    }
}
