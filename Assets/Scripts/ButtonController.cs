using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {

    private bool _pressed = false;
    private bool _playerin = false;
    public Sprite PressedSprite;
    public GameObject ConnectedDoor;

    public void PlayerEntered()
    {
        _playerin = true;
    }

    public void PlayerLeft()
    {
        _playerin = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && !_pressed)
        {
            Press();
        }
    }

    public void Press()
    {
        _pressed = true;
        GetComponent<SpriteRenderer>().sprite = PressedSprite;
        StartCoroutine(ConnectedDoor.GetComponent<DoorController>().OpenDoor());
    }
}
