﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5;

    [Header("Running")]
    public bool canRun = true;
    public bool IsRunning { get; private set; }
    public bool IsWalking;
    public float runSpeed = 9;
    public KeyCode runningKey = KeyCode.LeftControl;

    Rigidbody rigidbody;
    /// <summary> Functions to override movement speed. Will use the last added override. </summary>
    public List<Func<float>> speedOverrides = new List<Func<float>>();

    // Define events for walking
    public event Action WalkStarted;
    public event Action WalkEnded;

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
        IsWalking = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);

        // Get targetMovingSpeed.
        float targetMovingSpeed = IsRunning ? runSpeed : speed;
        if (speedOverrides.Count > 0)
        {
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
        }

        // Get targetVelocity from input.
        Vector2 targetVelocity = new Vector2(Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);

        // Apply movement using Rigidbody.MovePosition().
        Vector3 newPosition = rigidbody.position + transform.rotation * new Vector3(targetVelocity.x, 0, targetVelocity.y) * Time.fixedDeltaTime;
        rigidbody.MovePosition(newPosition);

        // Check if the player is walking and raise events accordingly
        if (IsWalking)
        {
            WalkStarted?.Invoke();
        }
        else
        {
            WalkEnded?.Invoke();
        }
    }
}
