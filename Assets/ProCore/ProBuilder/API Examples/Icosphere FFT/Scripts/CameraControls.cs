using UnityEngine;
using System.Collections;

	public class CameraControls : MonoBehaviour {

    public Transform cam, point;
    public float distance, height,minHeight,maxHeight, orbitSpeed, vertSpeed;
    void Start()
    {
    }

    void Update()
    {
        point.position = gameObject.transform.position + new Vector3(0, 1.57f, 0);
        point.eulerAngles += new Vector3(0, Input.GetAxis("Mouse X") * Time.deltaTime * orbitSpeed, 0);
        height += Input.GetAxis("Mouse Y") * Time.deltaTime * vertSpeed;
        height = Mathf.Clamp(height, minHeight, maxHeight);

    }
    void LateUpdate()
    {
        point.position = point.position + point.forward * -1 * distance + Vector3.up * height;
        cam.LookAt(point);
    }
}