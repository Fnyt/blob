using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D _rb;
    private int _jumpforce = 200;
    private float _movespeed = 2.5f;
	private bool _facingright = true;
	private bool _grounded = true;
    private Animator _animator;

	// Use this for initialization
	void Start () {
		_rb = GetComponent<Rigidbody2D>();
		_animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		_rb.velocity = new Vector2 (0f, _rb.velocity.y);
		_grounded = (_rb.velocity.y == 0);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
			//transform.Translate(Vector3.left * _movespeed * Time.deltaTime);
			GetComponent<SpriteRenderer> ().flipX = true;
			_rb.velocity += Vector2.left * _movespeed;
			_facingright = false;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //transform.Translate(Vector3.right * _movespeed * Time.deltaTime);
			GetComponent<SpriteRenderer> ().flipX = false;
			_rb.velocity += Vector2.right * _movespeed;
			_facingright = true;
        }
		if(Input.GetKeyDown(KeyCode.Z) && _grounded)
        {
            _rb.AddForce(Vector2.up * _jumpforce);
            _grounded = false;
            _animator.SetInteger("State", 2);
        }
        if (_grounded)
            _animator.SetInteger("State", _rb.velocity.x == 0 ? 0 : 1);


    }

	void OnCollisionStay2D(Collision2D col)
	{

	}
}
