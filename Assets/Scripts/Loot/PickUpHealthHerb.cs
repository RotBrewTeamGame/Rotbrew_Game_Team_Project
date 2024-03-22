using UnityEngine;
using UnityEngine.VFX;
using FMODUnity;
using FMOD.Studio;
using System.Collections;

public class PickUpHealthHerb : MonoBehaviour
{
    // Reference to the FMODEvents script
    private FMODEvents fmodEvents;

    // Reference to the new pickup sound event in the FMODEvents script
    public EventReference pickupSound;

    public VisualEffect vfx;
    public string coreSpawnRateParameterName = "CoreSpawnRate";
    public string trailSpawnRateParameterName = "TrailSpawnRate";
    public string outerTrailSpawnRateParameterName = "OuterTrailSpawnRate";

    private bool hasIncreasedHealthHerb = false;

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
        if (!hasIncreasedHealthHerb && collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.IncreaseHealthHerbAmount(1);
            hasIncreasedHealthHerb = true;
            SetSpawnRatesToZero();
            StartCoroutine(DestroyAfterDelay(7f));
            DisableCollider();

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
