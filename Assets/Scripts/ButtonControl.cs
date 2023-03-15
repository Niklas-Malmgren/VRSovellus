using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    public GameObject button, door;
    public UnityEvent onPressed, onRelease;

    private GameObject presser;
    private bool isPressed, isOpening;
    private float doorPositionY;

    // Start is called before the first frame update
    void Start()
    {
        isPressed = false;
        isOpening = false;

        doorPositionY = door.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPressed)
        {
            button.transform.localPosition = Vector3.Lerp(button.transform.localPosition, new Vector3(0, 0.01f, 0), Time.deltaTime * 2);
        }
        else
        {
            button.transform.localPosition = Vector3.Lerp(button.transform.localPosition, new Vector3(0, 0.04f, 0), Time.deltaTime * 2);
        }

        if(isOpening)
        {
            door.transform.position = Vector3.Lerp(door.transform.position, new Vector3(door.transform.position.x, doorPositionY + 4f, door.transform.position.z), Time.deltaTime);
        }
        else 
        {
            door.transform.position = Vector3.Lerp(door.transform.position, new Vector3(door.transform.position.x, doorPositionY, door.transform.position.z), Time.deltaTime);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            presser = other.gameObject;
            isPressed = true;
            onPressed.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser)
        {
            isPressed = false;
            onRelease.Invoke();
        }
    }

    public void OpenDoor()
    {
        isOpening = true;
    }

    public void CloseDoor()
    {
        isOpening = false;
    }


}
