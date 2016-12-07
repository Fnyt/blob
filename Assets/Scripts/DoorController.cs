using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

    private Animator _animator;

    private void Start()
    {
       _animator = GetComponent<Animator>();
    }

    public IEnumerator OpenDoor()
    {
        _animator.SetBool("IsOpen", true);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
