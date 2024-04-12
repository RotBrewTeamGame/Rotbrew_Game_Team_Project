using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PickUpIceCrystal : MonoBehaviour
{
    //public string coreSpawnRateParameterName = "CoreSpawnRate"; // Name of the float parameter in VFX
    //public string trailSpawnRateParameterName = "TrailSpawnRate";
    //public string outerTrailSpawnRateParameterName = "OuterTrailSpawnRate";
    //public VisualEffect vfx;

    private FMODEvents fmodEvents;

    public EventReference pickupSound;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (GameManager.instance != null)
            {
                GameManager.instance.IncreaseIceCrystalAmount(1);
            }

            //SetSpawnRatesToZero();
            StartCoroutine(DestroyAfterDelay(1f)); //float originally 7
            //DisableCollider();

            Debug.Log("Collided");
        }
    }

    /*
    private void SetSpawnRatesToZero()
    {
        // Set float parameters in VFX to zero
        vfx.SetFloat(coreSpawnRateParameterName, 0f);
        vfx.SetFloat(trailSpawnRateParameterName, 0f);
        vfx.SetFloat(outerTrailSpawnRateParameterName, 0f);
    }
    */

    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
    /*
    private void DisableCollider()
    {
        Collider collider = GetComponent<Collider>();
        if (collider != null)
        {
            collider.enabled = false;
        }
    }
    */
}
