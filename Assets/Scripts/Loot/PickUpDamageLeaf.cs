using UnityEngine;
using UnityEngine.VFX;
using FMODUnity;
using FMOD.Studio;
using System.Collections; // Add this line to fix the error

public class PickUpDamageLeaf : MonoBehaviour
{
    // Reference to the FMODEvents script
    private FMODEvents fmodEvents;

    // Reference to the crafting event in the FMODEvents script
    public EventReference pickupSound;

    public VisualEffect vfx;
    public string coreSpawnRateParameterName = "CoreSpawnRate";
    public string trailSpawnRateParameterName = "TrailSpawnRate";
    public string outerTrailSpawnRateParameterName = "OuterTrailSpawnRate";

    private bool hasIncreasedDamageLeaf = false;

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
        if (!hasIncreasedDamageLeaf && collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.IncreaseDamagePlantAmount(1);
            hasIncreasedDamageLeaf = true;
            SetSpawnRatesToZero();
            StartCoroutine(DestroyAfterDelay(7f));
            DisableCollider();

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
