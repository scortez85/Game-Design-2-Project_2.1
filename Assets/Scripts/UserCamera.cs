using UnityEngine;
using System.Collections;

public class UserCamera : MonoBehaviour {

	public Transform target; 							
	private float targetHeight = 1.7f;                  
    private float distance = 12.0f;                     
    private float offsetFromWall = 0.1f;                
    private float maxDistance = 20;                     
    private float minDistance = 0.6f;                   
    private float xSpeed = 200.0f;                      
    private float ySpeed = 200.0f;                         
    private float yMinLimit = -80;                         
    private float yMaxLimit = 80;                          
    private float zoomRate = 40;                           
    private float rotationDampening = 3.0f;                
    private float zoomDampening = 5.0f;                    
    private LayerMask collisionLayers = -1;     

    private bool lockToRearOfTarget;
    private bool allowMouseInputX = true;
    private bool allowMouseInputY = true; 

    private float xDeg = 0.0f;
    private float yDeg = 0.0f;
    private float currentDistance;
    private float desiredDistance; 
	private float correctedDistance; 
	private bool rotateBehind;

    private GameObject userModel;
    public bool inFirstPerson;

    public int camAngle;
		
	void Start () { 

		Vector3 angles = transform.eulerAngles; 
		xDeg = angles.x; 
		yDeg = angles.y; 
		currentDistance = distance; 
		desiredDistance = distance; 
		correctedDistance = distance; 
		
		// Make the rigid body not change rotation 
		if (GetComponent<Rigidbody>()) 
			GetComponent<Rigidbody>().freezeRotation = true;
		
		if (lockToRearOfTarget)
			rotateBehind = true;
	} 
	
	void Update () {
        if (Input.GetMouseButton(1))
        {
            //camAngle = 0;
            //target = GameObject.Find("Player").transform;

        }
        else
        {
            
            camAngle = 1;
            target = GameObject.Find("cameraAnchor").transform;
            
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0) {
			
			if(inFirstPerson == true) {
				
				minDistance = 10;
				desiredDistance = 15;
				userModel.SetActive(true);
				inFirstPerson = false;
			}
		}
		
		if(desiredDistance == 10) {
			
			minDistance = 0;
			desiredDistance = 0;
			userModel.SetActive(false);
			inFirstPerson = true;
		}	
	}
	
	void LateUpdate () 
	{ 

		if (!target) 
			return;
		
		Vector3 vTargetOffset3;

		if (GUIUtility.hotControl == 0)
		{
			if(Input.GetKey(KeyCode.LeftControl)) {
				
			}
			else {
            
				if (Input.GetMouseButton(0) || Input.GetMouseButton(1)) 
				{ 
					if (allowMouseInputX)
						xDeg += Input.GetAxis ("Mouse X") * xSpeed * 0.02f; 
					if (allowMouseInputY)
						yDeg -= Input.GetAxis ("Mouse Y") * ySpeed * 0.02f; 

				} 
			}
		}
		Quaternion rotation = Quaternion.Euler (yDeg, xDeg, 0); 
		
		desiredDistance -= Input.GetAxis ("Mouse ScrollWheel") * Time.deltaTime * zoomRate * Mathf.Abs (desiredDistance); 
		desiredDistance = Mathf.Clamp (desiredDistance, minDistance, maxDistance); 
		correctedDistance = desiredDistance; 
		
		Vector3 vTargetOffset = new Vector3 (0, -targetHeight, 0);
		Vector3 position = target.position - (rotation * Vector3.forward * desiredDistance + vTargetOffset); 
		
		RaycastHit collisionHit; 
		Vector3 trueTargetPosition = new Vector3 (target.position.x, target.position.y + targetHeight, target.position.z); 
		
		bool isCorrected = false; 
		if (Physics.Linecast (trueTargetPosition, position,out collisionHit, collisionLayers)) 
		{ 
			correctedDistance = Vector3.Distance (trueTargetPosition, collisionHit.point) - offsetFromWall; 
			isCorrected = true;
		}
		
		currentDistance = !isCorrected || correctedDistance > currentDistance ? Mathf.Lerp (currentDistance, correctedDistance, Time.deltaTime * zoomDampening) : correctedDistance; 
		
		currentDistance = Mathf.Clamp (currentDistance, minDistance, maxDistance); 
		
		position = target.position - (rotation * Vector3.forward * currentDistance + vTargetOffset);

        if (camAngle.Equals(0))
        {
            transform.rotation = rotation;
            transform.position = position;
        }
        else if (camAngle.Equals(1))
        {
            transform.position = target.position;
            transform.rotation = target.rotation;
        }
        else if (camAngle.Equals(-1))
        {
            transform.position = new Vector3(0, 7, -8);
            transform.rotation = GameObject.Find("cameraAnchor").transform.rotation;
        }
    } 
    
	void ClampAngle (float angle)
	{
		if (angle < -360)
			angle += 360;
		if (angle > 360)
			angle -= 360;

		yDeg = Mathf.Clamp(angle, -60, 80);
	}

}