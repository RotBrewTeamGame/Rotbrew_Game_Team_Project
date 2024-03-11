using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PickUpDamageLeaf : MonoBehaviour
{
    public string coreSpawnRateParameterName = "CoreSpawnRate"; // Name of the float parameter in VFX
    public string trailSpawnRateParameterName = "TrailSpawnRate";
    public string outerTrailSpawnRateParameterName = "OuterTrailSpawnRate";
    public VisualEffect vfx;

    private bool hasIncreasedDamageLeaf = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (!hasIncreasedDamageLeaf && collision.gameObject.CompareTag("Player"))
        {
            
            GameManager.instance.IncreaseDamagePlantAmount(1);
            hasIncreasedDamageLeaf = true;
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
