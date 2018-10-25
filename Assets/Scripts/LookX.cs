using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookX : MonoBehaviour {
    [SerializeField]
    float _sensitivity = 5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        float _mouseX = Input.GetAxis("Mouse X");

        Vector3 newRotation = transform.localEulerAngles;
        newRotation.y += _mouseX * _sensitivity;
        transform.localEulerAngles = newRotation;
        
	}
}
