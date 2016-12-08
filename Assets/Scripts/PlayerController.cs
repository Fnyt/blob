using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D _rb;
    private int _jumpforce = 200;
    private float _movespeed = 1.75f;
    private Animator _animator;

	// Use this for initialization
	void Start () {
		_rb = GetComponent<Rigidbody2D>();
		_animator = GetComponent<Animator>();
	}
	
    bool IsGrounded()
    {
        if (Mathf.Abs(_rb.velocity.y) < 0.01f)
            return true;
        return false;
    }

    bool IsMoving()
    {
        if (Mathf.Abs(_rb.velocity.x) < 0.001f && Mathf.Abs(_rb.velocity.y) < 0.001f)
            return false;
        return true;
    }

    void FixedUpdate()
    {
        //Debug.Log(_rb.velocity.x.ToString() + ", " + _rb.velocity.y.ToString());
    }

    // Update is called once per frame
    void Update () {
        _animator.SetBool("Grounded", IsGrounded());
        _animator.SetBool("IsMoving", IsMoving());

        _rb.velocity = new Vector2 (0f, _rb.velocity.y);
        

        if (Input.GetKey(KeyCode.LeftArrow))
        {
			//transform.Translate(Vector3.left * _movespeed * Time.deltaTime);
			GetComponent<SpriteRenderer> ().flipX = true;
			_rb.velocity += Vector2.left * _movespeed;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //transform.Translate(Vector3.right * _movespeed * Time.deltaTime);
			GetComponent<SpriteRenderer> ().flipX = false;
			_rb.velocity += Vector2.right * _movespeed;
        }
		if(Input.GetKeyDown(KeyCode.Z) && IsGrounded())
        {
            _rb.AddForce(Vector2.up * _jumpforce);
            //IsGrounded() = false;
        }

    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Button")
        {
            col.gameObject.GetComponent<ButtonController>().PlayerLeft();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Button")
        {
            col.gameObject.GetComponent<ButtonController>().PlayerEntered();
        }
    }


}
