using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition += new Vector3(Input.GetAxis("Vertical")+Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical") - Input.GetAxis("Horizontal"));
	    Camera.main.orthographicSize += Input.GetAxis("Mouse ScrollWheel")*-2f;
	}
}
