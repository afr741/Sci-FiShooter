using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        float _mouseY = Input.GetAxis("Mouse Y");
        Vector3 newRotation = transform.localEulerAngles;
        newRotation.x += _mouseY;
        transform.localEulerAngles = newRotation;
    }
}
