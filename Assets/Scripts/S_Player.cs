using UnityEngine;
using System.Collections;

public class S_Player : MonoBehaviour {
	
	private RaycastHit[] hits;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//E key to interact with clones/buttons/anything that has an interact function
		if (Input.GetKeyDown (KeyCode.E)) {
			hits = Physics.RaycastAll(transform.position, transform.forward, 1.5f);
			foreach (RaycastHit hit in hits){
				hit.collider.SendMessage ("Interact");
			}
		}
	}
}

