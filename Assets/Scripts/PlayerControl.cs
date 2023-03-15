using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public InputActionReference runReferenceLeft = null, runReferenceRight = null;

    public GameObject controllerLeft, controllerRight;
    private Vector3 controllerLeftPosition, controllerRightPosition;

    private float valueLeft, valueRight;

    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        controllerLeftPosition = controllerLeft.transform.position;
        controllerRightPosition = controllerRight.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        valueLeft = runReferenceLeft.action.ReadValue<float>();
        valueRight = runReferenceRight.action.ReadValue<float>();

        if (valueLeft >= 0.8f && valueRight >= 0.8f)
        {
            Vector3 movementLeft;
            movementLeft = controllerLeftPosition - controllerLeft.transform.position;
            movementLeft = new Vector3(Math.Abs(movementLeft.x), Math.Abs(movementLeft.y), Math.Abs(movementLeft.z));
            float left = movementLeft.x + movementLeft.y;

            Vector3 movementRight;
            movementRight = controllerRightPosition - controllerRight.transform.position;
            movementRight = new Vector3(Math.Abs(movementRight.x), Math.Abs(movementRight.y), Math.Abs(movementRight.z));
            float right = movementRight.x + movementRight.y;

            rb.velocity = transform.forward * (left + right) * 50;
        }
        else
        {
            rb.velocity = Vector3.zero;
        }

        controllerLeftPosition = controllerLeft.transform.position;
        controllerRightPosition = controllerRight.transform.position;
    }
}
