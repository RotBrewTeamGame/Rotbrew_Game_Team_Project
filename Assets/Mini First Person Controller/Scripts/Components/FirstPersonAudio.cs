using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using System;

public class FirstPersonAudio : MonoBehaviour
{
    public FirstPersonMovement character;
    public GroundCheck groundCheck;

    [Header("Step")]
    public EventReference playerFootsteps;
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
        stepEventInstance = audioManager.CreateInstance(playerFootsteps);
        runningEventInstance = audioManager.CreateInstance(runningEvent);

        // Set 3D attributes for the event instances
        Set3DAttributes();
    }

    void Set3DAttributes()
    {
        // Set 3D attributes for step event instance
        if (stepEventInstance.isValid())
        {
            FMOD.ATTRIBUTES_3D attributes = RuntimeUtils.To3DAttributes(transform.position);
            stepEventInstance.set3DAttributes(attributes);
        }

        // Set 3D attributes for running event instance
        if (runningEventInstance.isValid())
        {
            FMOD.ATTRIBUTES_3D attributes = RuntimeUtils.To3DAttributes(transform.position);
            runningEventInstance.set3DAttributes(attributes);
        }
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
        // Play step or running audio based on character movement
        float velocity = character.GetMovementVelocity();
        if (velocity > 0.01f && groundCheck.isGrounded)
        {
            if (character.IsRunning)
            {
                PlayRunningAudio();
            }
            else
            {
                PlayStepAudio();
            }
        }
    }

    void SubscribeToEvents()
    {
        // Subscribe to game events to trigger FMOD events
        character.Landed += PlayLandingAudio;
        character.Jumped += PlayJumpAudio;
        character.CrouchStarted += PlayCrouchStartAudio;
        character.CrouchEnded += PlayCrouchEndAudio;
    }

    void UnsubscribeToEvents()
    {
        // Unsubscribe from game events
        character.Landed -= PlayLandingAudio;
        character.Jumped -= PlayJumpAudio;
        character.CrouchStarted -= PlayCrouchStartAudio;
        character.CrouchEnded -= PlayCrouchEndAudio;
    }


    void PlayStepAudio()
    {
        // Play step audio
        if (!stepEventInstance.isValid())
        {
            stepEventInstance = audioManager.CreateInstance(playerFootsteps);
        }
        stepEventInstance.start();
    }

    void PlayRunningAudio()
    {
        // Play running audio
        if (!runningEventInstance.isValid())
        {
            runningEventInstance = audioManager.CreateInstance(runningEvent);
        }
        runningEventInstance.start();
    }

    void PlayLandingAudio()
    {
        // Play landing audio
        audioManager.PlayOneShot(landingEvent, transform.position);
    }

    void PlayJumpAudio()
    {
        // Play jump audio
        audioManager.PlayOneShot(jumpEvent, transform.position);
    }

    void PlayCrouchStartAudio()
    {
        // Play crouch start audio
        audioManager.PlayOneShot(crouchStartEvent, transform.position);
    }

    void PlayCrouchEndAudio()
    {
        // Play crouch end audio
        audioManager.PlayOneShot(crouchEndEvent, transform.position);
    }
}
