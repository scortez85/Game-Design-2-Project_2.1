using UnityEngine;
using System.Collections;

public class cameraController : MonoBehaviour {
    private GameObject cam, camThrird;
    private Vector3 topDownCamPos;
    private Quaternion topDownCamRot;
    public int camAngle;
    private float camSpeed = 100;

	void Start () {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        camThrird = GameObject.Find("thirdCam");
        topDownCamPos = new Vector3(0, 140, 0);
        topDownCamRot = new Quaternion(0.7071068f, 0, 0, 0.7071068f); 
	
	}
    public void setCamera(int num)
    {
        if (num.Equals(0))
        {
            cam.transform.position = topDownCamPos;
            cam.transform.rotation = topDownCamRot;
        }
        else if (num.Equals(1))
        {
            cam.transform.position = camThrird.transform.position;
            cam.transform.rotation = camThrird.transform.rotation;
        }
        else if (num.Equals(2))
        {
            cam.transform.position = Vector3.MoveTowards(cam.transform.position, topDownCamPos, camSpeed * Time.deltaTime);
            cam.transform.rotation = topDownCamRot;
            
        }
        else if (num.Equals(3))
        {
            cam.transform.position = Vector3.MoveTowards(cam.transform.position, camThrird.transform.position, camSpeed * Time.deltaTime);
            cam.transform.rotation = camThrird.transform.rotation;
            cam.transform.LookAt(GameObject.Find("Player").transform.position);
        }
     
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.B))//this is a test and only a test
            camAngle = 3;
        
        setCamera(camAngle);
        //switch to 3dperson camera
        if (camAngle.Equals(3) && cam.transform.position.Equals(camThrird.transform.position) || camAngle.Equals(-1))
        {
            //enable playermovement, camera, animations, and shooting
            cam.GetComponent<UserCamera>().enabled = true;
            GameObject.Find("Player").GetComponent<playerMove>().enabled = true;
            GameObject.Find("Player").GetComponent<playerAnimate>().enabled = true;
            GameObject.Find("Player").GetComponent<HashID>().enabled = true;
            GameObject.Find("Player").GetComponent<playerShoot>().enabled = true;
            //gameObject.GetComponent<cameraController>().enabled = false;
            camAngle = -1;
        }
        else if (!camAngle.Equals(3) || !camAngle.Equals(-1))
        {
            cam.GetComponent<UserCamera>().enabled = false;
            GameObject.Find("Player").GetComponent<playerMove>().enabled = false;
            GameObject.Find("Player").GetComponent<playerAnimate>().enabled = false;
            GameObject.Find("Player").GetComponent<HashID>().enabled = false;
            GameObject.Find("Player").GetComponent<playerShoot>().enabled = false;
            //gameObject.GetComponent<cameraController>().enabled = true;
        }

    }
}
