using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public Rigidbody2D rb;

    private int _jumpforce = 200;
    private float _movespeed = 2.5f;
 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * _movespeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * _movespeed * Time.deltaTime);
        }
        if(Input.GetKeyDown(KeyCode.Z))
        {
            rb.AddForce(Vector2.up * _jumpforce);
        }
	}
}
