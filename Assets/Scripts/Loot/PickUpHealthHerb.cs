using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PickUpHealthHerb : MonoBehaviour
{
    public string coreSpawnRateParameterName = "CoreSpawnRate"; // Name of the float parameter in VFX
    public string trailSpawnRateParameterName = "TrailSpawnRate";
    public string outerTrailSpawnRateParameterName = "OuterTrailSpawnRate";
    public VisualEffect vfx;

    private bool hasIncreasedHealthHerb = false; // Flag to track if IncreaseHealthHerbAmount has been called

    private void OnCollisionEnter(Collision collision)
    {
        if (!hasIncreasedHealthHerb && collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.IncreaseHealthHerbAmount(1);
            hasIncreasedHealthHerb = true; // Set flag to true to prevent further calls
            SetSpawnRatesToZero();
            StartCoroutine(DestroyAfterDelay(7f));
            DisableCollider();
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
