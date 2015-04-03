using UnityEngine;
using System.Collections;

public class S_Clone : MonoBehaviour {

	public Rigidbody rb;
	public RaycastHit[] nearClones;
	public float alertTimer;
	public Quaternion originalFacing;
	public GameObject player;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		originalFacing = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		//Face player if alerted
		alertTimer -= Time.deltaTime;
		if (alertTimer > 0) {
			transform.LookAt (player.transform.position);
		} else {
			transform.rotation = originalFacing;
		}
	}

	//This is called when the player pressed E on this object
	void Interact(){
		rb.AddForce (Vector3.back * 5, ForceMode.Impulse);
		nearClones = Physics.SphereCastAll (transform.position, 20f, Vector3.forward, 20f);
		foreach (RaycastHit clone in nearClones) {
			clone.collider.SendMessage("Alert", SendMessageOptions.DontRequireReceiver);
		}
	}

	//Alerted when a neaby clone is "Interacted"
	void Alert(){
		alertTimer = 5f;
	}

	//Is called when the clone enters a trigger with the "kill" script
	void Kill(){

	}
}
