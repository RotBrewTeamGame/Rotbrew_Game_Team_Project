using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class FMODEvents : MonoBehaviour
{
    [Header("Player Footsteps")]
    public EventReference playerFootsteps;

    public float footstepCooldown = 0.35f; // Adjust this value to set the cooldown between footstep sounds
    private float lastFootstepTime;

    [Header("Jump")]
    public EventReference jumpEvent;

    [Header("Landing")]
    public EventReference landingEvent;

    [Header("Crouch Start")]
    public EventReference crouchStartEvent;

    [Header("Crouch End")]
    public EventReference crouchEndEvent;

    [Header("Enemy Dissolve SFX")]
    public EventReference enemyDissolveSFX;

    [Header("Crafting")]
    public EventReference craftingEvent;

    [Header("Plant Collection")]
    public EventReference plantCollectionEvent;

    [Header("Loot Pick Up")]
    public EventReference pickupSound;

    [Header("City Centre")]
    public EventReference cityCentreSoundtrack;
    
    [Header("Industrial Zone")]
    public EventReference industrialZoneSoundtrack;

    [Header("Sewer Zone")]
    public EventReference sewersSoundtrack;

    public static FMODEvents instance;

    public FirstPersonAudio firstPersonAudio;
    public FirstPersonMovement firstPersonMovement;

    void Update()
    {
        if (firstPersonMovement.IsRunning)
        {
            footstepCooldown = 0.2f;
        }
        else
        {
            footstepCooldown = 0.35f;
        }
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one FMOD Events instance in this scene.");
        }
        instance = this;

        // Subscribe to FirstPersonMovement events
        FirstPersonMovement character = FindObjectOfType<FirstPersonMovement>();
        if (character != null)
        {
            character.Jumped += PlayJumpAudio;
            character.Landed += PlayLandingAudio;
            character.CrouchStarted += PlayCrouchStartAudio;
            character.CrouchEnded += PlayCrouchEndAudio;
        }
        else
        {
            Debug.LogWarning("FirstPersonMovement script not found in the scene.");
        }
    }

    private void OnDestroy()
    {
        // Unsubscribe from FirstPersonMovement events
        FirstPersonMovement character = FindObjectOfType<FirstPersonMovement>();
        if (character != null)
        {
            character.Jumped -= PlayJumpAudio;
            character.Landed -= PlayLandingAudio;
            character.CrouchStarted -= PlayCrouchStartAudio;
            character.CrouchEnded -= PlayCrouchEndAudio;
        }
    }

    public void PlayWalkingAudio()
    {
        // Check if the player is currently walking
        if (firstPersonAudio.playerIsMoving)
        {
            // Check if enough time has passed since the last footstep sound
            if (Time.time - lastFootstepTime >= footstepCooldown)
            {
                // Play footstep sound
                if (!playerFootsteps.IsNull)
                {
                    RuntimeManager.PlayOneShot(playerFootsteps, transform.position);
                    lastFootstepTime = Time.time; // Update last footstep time
                }
            }
        }
    }



    public void PlayJumpAudio()
    {
        // Play jump audio event
        Debug.Log("Jump audio played.");

        // Add FMOD logic here to trigger the jump audio event
        if (!jumpEvent.IsNull)
        {
            RuntimeManager.PlayOneShot(jumpEvent, transform.position);
        }
    }

    public void PlayLandingAudio()
    {
        // Play landing audio event
        Debug.Log("Landing audio played.");

        // Add FMOD logic here to trigger the landing audio event
        if (!landingEvent.IsNull)
        {
            RuntimeManager.PlayOneShot(landingEvent, transform.position);
        }
    }

    public void PlayCrouchStartAudio()
    {
        // Play crouch start audio event
        Debug.Log("Crouch start audio played.");

        // Add FMOD logic here to trigger the crouch start audio event
        if (!crouchStartEvent.IsNull)
        {
            RuntimeManager.PlayOneShot(crouchStartEvent, transform.position);
        }
    }

    public void PlayCrouchEndAudio()
    {
        // Play crouch end audio event
        Debug.Log("Crouch end audio played.");

        // Add FMOD logic here to trigger the crouch end audio event
        if (!crouchEndEvent.IsNull)
        {
            RuntimeManager.PlayOneShot(crouchEndEvent, transform.position);
        }
    }

    public void PlayEnemyDissolveSFX(Vector3 worldPos)
    {
        // Play enemy dissolve sound effect
        Debug.Log("Enemy dissolve SFX played.");

        // Add FMOD logic here to trigger the enemy dissolve SFX
        if (!enemyDissolveSFX.IsNull)
        {
            RuntimeManager.PlayOneShot(enemyDissolveSFX, worldPos);
        }
    }

    public void PlayHealthPotionCraftingAudio()
    {
        // Play health potion crafting audio event
        Debug.Log("Health potion crafting audio played.");

        // Add FMOD logic here to trigger the health potion crafting audio event
        if (!craftingEvent.IsNull)
        {
            RuntimeManager.PlayOneShot(craftingEvent, transform.position);
        }
    }

    public void PlayDamagePotionCraftingAudio()
    {
        // Play damage potion crafting audio event
        Debug.Log("Damage potion crafting audio played.");

        // Add FMOD logic here to trigger the damage potion crafting audio event
        if (!craftingEvent.IsNull)
        {
            RuntimeManager.PlayOneShot(craftingEvent, transform.position);
        }
    }

    public void PlayFirePotionCraftingAudio()
    {
        // Play fire potion crafting audio event
        Debug.Log("Fire potion crafting audio played.");

        // Add FMOD logic here to trigger the fire potion crafting audio event
        if (!craftingEvent.IsNull)
        {
            RuntimeManager.PlayOneShot(craftingEvent, transform.position);
        }
    }

    public void PlayFrostPotionCraftingAudio()
    {
        // Play fire potion crafting audio event
        Debug.Log("Frost potion crafting audio played.");

        // Add FMOD logic here to trigger the fire potion crafting audio event
        if (!craftingEvent.IsNull)
        {
            RuntimeManager.PlayOneShot(craftingEvent, transform.position);
        }
    }

    public void PlayPlantCollectionAudio()
    {
        // Play plant collection audio event
        Debug.Log("Plant collection audio played.");
    }
}