using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using System;

public class FirstPersonAudio : MonoBehaviour
{
    public FirstPersonMovement character;
    public GroundCheck groundCheck;

    [Header("Step")]
    public EventReference stepEvent;
    private EventInstance stepEventInstance;

    [Header("Running")]
    public EventReference runningEvent;
    private EventInstance runningEventInstance;

    [Header("Landing")]
    public EventReference landingEvent;

    [Header("Jump")]
    public EventReference jumpEvent;

    [Header("Crouch")]
    public EventReference crouchStartEvent;
    public EventReference crouchEndEvent;

    private AudioManager audioManager;

    void Start()
    {
        audioManager = AudioManager.instance;

        // Initialize FMOD events
        stepEventInstance = audioManager.CreateInstance(stepEvent);
        runningEventInstance = audioManager.CreateInstance(runningEvent);
    }

    void OnEnable()
    {
        SubscribeToEvents();
    }

    void OnDisable()
    {
        UnsubscribeToEvents();
    }

    void FixedUpdate()
    {
        // Implement logic for playing FMOD events based on character state
    }

    void SubscribeToEvents()
    {
        // Subscribe to game events to trigger FMOD events
    }

    void UnsubscribeToEvents()
    {
        // Unsubscribe from game events
    }

    #region Play instant-related audios
    void PlayLandingAudio()
    {
        audioManager.PlayOneShot(landingEvent, transform.position);
    }

    void PlayJumpAudio()
    {
        audioManager.PlayOneShot(jumpEvent, transform.position);
    }

    void PlayCrouchStartAudio()
    {
        audioManager.PlayOneShot(crouchStartEvent, transform.position);
    }

    void PlayCrouchEndAudio()
    {
        audioManager.PlayOneShot(crouchEndEvent, transform.position);
    }
    #endregion
}
