using UnityEngine;
using System.Collections;

public class S_Player : MonoBehaviour {
	
	private RaycastHit[] hits;
	private float recentlyInteracted = 0;
	public AudioSource whispers;

	// Use this for initialization
	void Start () {
		whispers = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		//E key to interact with clones/buttons/anything that has an interact function
		if (Input.GetKeyDown (KeyCode.E)) {
			hits = Physics.RaycastAll(transform.position, transform.forward, 1.5f);
			foreach (RaycastHit hit in hits){
				hit.collider.SendMessage ("Interact");

				//Have you recently interacted with a clone? (for whispering audio)
				if (hit.collider.tag == "Clone"){
					recentlyInteracted = 3f;
				}
			}
		}

		//Player whispering audio if you have recently interacted with a clone
		if (recentlyInteracted > 0 && !whispers.isPlaying) {
			whispers.Play ();
		} else if (recentlyInteracted <= 0 && whispers.isPlaying) {
			whispers.Stop ();
		}

		//Decrement timers
		recentlyInteracted -= Time.deltaTime;
	}
}

