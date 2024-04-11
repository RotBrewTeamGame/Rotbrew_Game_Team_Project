using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using System;

public class FirstPersonAudio : MonoBehaviour
{
    public bool playerIsMoving;
    public bool playerIsGrounded; // Add a flag to track if the player is grounded
    public FirstPersonMovement character;
    public FMODEvents fmodEvents; // Reference to the FMODEvents script
    public Jump jump;
    public Crouch crouch;
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

        character.WalkStarted += OnWalkStarted;
        character.WalkEnded += OnWalkEnded;
        character.Jumped += OnJumped;
        character.Landed += OnLanded;
    }

    void OnDestroy()
    {
        // Unsubscribe from walk events
        character.WalkStarted -= OnWalkStarted;
        character.WalkEnded -= OnWalkEnded;
        character.Jumped -= OnJumped;
        character.Landed -= OnLanded;
    }

    void OnWalkStarted()
    {
        playerIsMoving = true;
    }

    void OnWalkEnded()
    {
        playerIsMoving = false;
    }

    void OnJumped()
    {
        playerIsGrounded = false;
    }

    void OnLanded()
    {
        playerIsGrounded = true;
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
        
    }

    void SubscribeToEvents()
    {
        Debug.Log("FirstPersonAudio::SubscribeToEvents");

        // Subscribe to game events to trigger FMOD events
        character.Landed += PlayLandingAudio;
        jump.Jumped += PlayJumpAudio;
        crouch.CrouchStart += PlayCrouchStartAudio;
        crouch.CrouchEnd += PlayCrouchEndAudio;
    }

    void UnsubscribeToEvents()
    {
        // Unsubscribe from game events
        //character.Landed -= PlayLandingAudio;
        jump.Jumped -= PlayJumpAudio;
        crouch.CrouchStart -= PlayCrouchStartAudio;
        crouch.CrouchEnd -= PlayCrouchEndAudio;
    }

    void Walking()
    {
        if (playerIsMoving == true)
        {
            FMODEvents.instance.PlayWalkingAudio();
        }
    }

    
    void PlayStepAudio()
    {
        Debug.Log("FirstPersonAudio::PlayStepAudio");

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
        Debug.Log("FirstPersonAudio::PlayJumpAudio");

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

    void Update()
    {
        // Check if the player is moving, grounded, and not jumping, then tell FMODEvents to play footstep sounds accordingly
        if (playerIsMoving && groundCheck.isGrounded)
        {
            fmodEvents.PlayWalkingAudio();
        }
    }
}
