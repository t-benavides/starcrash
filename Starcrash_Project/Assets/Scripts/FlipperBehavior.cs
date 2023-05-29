using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperBehavior : MonoBehaviour
{
    //Allow the left and right flippers to be assigned in the Unity Editor
    [SerializeField] Rigidbody2D leftFlipper, rightFlipper;
    [SerializeField] float leftTorque, rightTorque;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            leftFlipper.AddTorque(leftTorque);
            Debug.Log("Flipper Activated: Right");
        }
        else
        {
            leftFlipper.AddTorque(-leftTorque * 0.5f);
        }
        if (Input.GetKey(KeyCode.RightShift))
        {
            rightFlipper.AddTorque(-rightTorque);
            Debug.Log("Flipper Activated: Right");
        }
        else
        {
            rightFlipper.AddTorque(rightTorque * 0.5f);
        }

    }
}
