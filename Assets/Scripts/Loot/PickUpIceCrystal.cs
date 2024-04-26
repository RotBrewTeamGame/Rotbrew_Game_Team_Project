using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PickUpIceCrystal : MonoBehaviour
{
    private FMODEvents fmodEvents;

    public EventReference pickupSound;

    public VisualEffect vfx;
    public string coreSpawnRateParameterName = "CoreSpawnRate";
    public string trailSpawnRateParameterName = "TrailSpawnRate";
    public string outerTrailSpawnRateParameterName = "OuterTrailSpawnRate";

    private void Start()
    {
        // Find and store the FMODEvents script in the scene
        fmodEvents = FindObjectOfType<FMODEvents>();
        if (fmodEvents == null)
        {
            Debug.LogError("FMODEvents script not found in the scene.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (GameManager.instance != null)
            {
                GameManager.instance.IncreaseIceCrystalAmount(1);
            }

            SetSpawnRatesToZero();
            StartCoroutine(DestroyAfterDelay(1f)); //float originally 7
            DisableCollider();

            Debug.Log("Collided");

            // Play the new pickup sound using the EventReference from the FMODEvents script
            if (fmodEvents != null)
            {
                RuntimeManager.PlayOneShot(pickupSound, transform.position);
            }
            else
            {
                Debug.LogWarning("FMODEvents reference is not set.");
            }
        }
    }
    
    private void SetSpawnRatesToZero()
    {
        // Set float parameters in VFX to zero
        vfx.SetFloat(coreSpawnRateParameterName, 0f);
        vfx.SetFloat(trailSpawnRateParameterName, 0f);
        vfx.SetFloat(outerTrailSpawnRateParameterName, 0f);
    }

    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
    
    private void DisableCollider()
    {
        Collider collider = GetComponent<Collider>();
        if (collider != null)
        {
            collider.enabled = false;
        }
    }  
}
