using UnityEngine;
using System.Collections;

public class S_Kill : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider col) {
		col.SendMessage ("Kill");
	}
}
