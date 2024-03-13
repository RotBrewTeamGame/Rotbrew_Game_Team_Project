using System;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5;

    [Header("Running")]
    public bool canRun = true;
    public bool IsRunning { get; private set; }
    public float runSpeed = 9;
    public KeyCode runningKey = KeyCode.LeftShift;

    Rigidbody rigidbody;
    /// <summary> Functions to override movement speed. Will use the last added override. </summary>
    public List<Func<float>> speedOverrides = new List<Func<float>>();

    // Define events for jumping, landing, crouch start, and crouch end
    public event Action Walked;
    
    // Delete the following
    public event Action Jumped;
    public event Action Landed;
    public event Action CrouchStarted;
    public event Action CrouchEnded;
    

    void Awake()
    {
        // Get the rigidbody on this.
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Update IsRunning from input.
        IsRunning = canRun && Input.GetKey(runningKey);

        // Get targetMovingSpeed.
        float targetMovingSpeed = IsRunning ? runSpeed : speed;
        if (speedOverrides.Count > 0)
        {
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
        }

        // Get targetVelocity from input.
        Vector2 targetVelocity = new Vector2(Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);

        // Apply movement.
        rigidbody.velocity = transform.rotation * new Vector3(targetVelocity.x, rigidbody.velocity.y, targetVelocity.y);

        
        if (targetVelocity.magnitude > 0)
        {
            if (IsRunning)
            {

            }
            else
            {
                Walked?.Invoke();
            }
        }
    }

    /*
    public float GetMovementVelocity()
    {
        // Implement logic to calculate movement velocity
        return 0f;
    }
    

    // Call these methods when the corresponding events occur
    public void OnJumped()
    {
        Jumped?.Invoke();
    }

    public void OnLanded()
    {
        Landed?.Invoke();
    }

    public void OnCrouchStarted()
    {
        CrouchStarted?.Invoke();
    }

    public void OnCrouchEnded()
    {
        CrouchEnded?.Invoke();
    }
    */
}
