using UnityEngine;
using System.Collections;

/// <summary>
/// Attach this script to an OVRPlayerController to move along your facing vector while holding down the GearVR touchpad.
/// This works well for applications where you simply explore an environment and don't need to interact with anything else.
/// 
/// Written by @bkavs on 12/13/2015.
/// Using Unity 5.2.3f1
/// Using Oculus Utilities for Unity 5 V0.1.3.0-beta
/// Tested on a Samsung Galaxy S6 in Consumer GearVR.
/// </summary>

public class GVRPlayerMovement : MonoBehaviour {

    /// <summary>
    /// This is the reference to the OVRPlayerController's CharacterController
    /// </summary>
    CharacterController controller;

    /// <summary>
    /// The current speed of the CharacterController
    /// </summary>
    private float currentVelocity = 0.0F;

    /// <summary>
    /// The maximum speed of the CharacterController
    /// </summary>
    public float maxVelocity = 5.0F;

    /// <summary>
    /// The rate at which the CharacterController accelerates
    /// </summary>
    public float acceleration = 0.15F;



    void Start ()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        ForwardMovement();
    }

    /// <summary>
    /// Move the CharacterController forward along the viewing vector if the touchpad is being pressed.
    /// </summary>
    void ForwardMovement()
    {
        //Define the forward vector using your facing direction
        Vector3 forward = transform.TransformDirection(Vector3.forward);

        // The touchpad is button 0. If the touchpad is being held down...
        if (Input.GetMouseButton(0))
        {
            // Add the acceleration to the current velocity and clamp it to the maxVelocity
            currentVelocity += acceleration;
            currentVelocity = Mathf.Clamp(currentVelocity, 0.0F, maxVelocity);

            // Then move the CharacterController forward
            controller.SimpleMove(forward * currentVelocity);
        }

        // If the touchpad was released on this frame, stop movement and reset current speed.
        if (Input.GetMouseButtonUp(0))
        {
            currentVelocity = 0.0F;
        }
    }
}