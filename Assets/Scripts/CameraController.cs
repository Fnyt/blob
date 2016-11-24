using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject Player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 position = transform.position;
		position.x = Player.transform.position.x;
		transform.position = position;
	}
}
