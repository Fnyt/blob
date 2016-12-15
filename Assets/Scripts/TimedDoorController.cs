using UnityEngine;
using System.Collections;

public class TimedDoorController : MonoBehaviour {

    public float OpenedTime;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public IEnumerator OpenDoor()
    {
        _animator.SetBool("IsOpen", true);
        yield return new WaitForSeconds(OpenedTime);
        _animator.SetBool("IsOpen", false);
    }
}
