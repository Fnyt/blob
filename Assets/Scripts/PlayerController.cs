using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D rb;
    private int _jumpforce = 200;
    private float _movespeed = 2.5f;
	private bool _facingright = true;
	private bool _grounded = true;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = new Vector2 (0f, rb.velocity.y);
		_grounded = (rb.velocity.y == 0);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
			//transform.Translate(Vector3.left * _movespeed * Time.deltaTime);
			GetComponent<SpriteRenderer> ().flipX = true;
			rb.velocity += Vector2.left * _movespeed;
			_facingright = false;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //transform.Translate(Vector3.right * _movespeed * Time.deltaTime);
			GetComponent<SpriteRenderer> ().flipX = false;
			rb.velocity += Vector2.right * _movespeed;
			_facingright = true;
        }
		if(Input.GetKeyDown(KeyCode.Z) && _grounded)
        {
            rb.AddForce(Vector2.up * _jumpforce);
        }
	}

	void OnCollisionStay2D(Collision2D col)
	{
		Vector3 dir = (col.gameObject.transform.position - gameObject.transform.position).normalized;
		Debug.Log (dir.ToString ());
		if (dir == Vector3.left)
		{
			Debug.Log ("Hit left side");
		}
		else if (dir == Vector3.right)
		{
			Debug.Log ("Hit right side");
		}
	}
}
