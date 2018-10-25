using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitMarkerCleanup : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
