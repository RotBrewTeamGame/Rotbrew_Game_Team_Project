using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using System;

public class FirstPersonAudio : MonoBehaviour
{
    public bool playerIsMoving;
    public FirstPersonMovement character;
    public GroundCheck groundCheck;
    public float velocityThreshold = .01f;
    Vector2 lastCharacterPosition;
    Vector2 CurrentCharacterPosition => new Vector2(character.transform.position.x, character.transform.position.z);

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
        Walking();
        /*
        // Play step or running audio based on character movement
        float velocity = Vector3.Distance(CurrentCharacterPosition, lastCharacterPosition);
        if (velocity >= velocityThreshold && groundCheck && groundCheck.isGrounded)
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

        lastCharacterPosition = CurrentCharacterPosition;
        */

        if (Input.GetKey(KeyCode.A))
        {
            playerIsMoving = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerIsMoving = true;
        }
        if (Input.GetKey(KeyCode.W))
        {
            playerIsMoving = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerIsMoving = true;
        }
        else
        {
            playerIsMoving = false;
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

void Walking()
{
    if (playerIsMoving == true)
    {
        FMODEvents.instance.PlayWalkingAudio();
    }
}

    /*
void PlayStepAudio()
    {
        // Play step audio
        if (!stepEventInstance.isValid())
        {
            //stepEventInstance = audioManager.CreateInstance(playerFootsteps);
            InvokeRepeating(“Walking”, 0.5f, walkingSpeed);
        }
        //stepEventInstance.start();
    }
    */
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
