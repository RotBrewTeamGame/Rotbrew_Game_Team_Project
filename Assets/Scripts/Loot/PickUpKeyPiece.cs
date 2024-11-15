using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using FMODUnity;

public class PickUpKeyPiece : MonoBehaviour
{
    public EventReference pickupSound; // New pickup sound event reference
    public string coreSpawnRateParameterName = "CoreSpawnRate"; // Name of the float parameter in VFX
    public string trailSpawnRateParameterName = "TrailSpawnRate";
    public string outerTrailSpawnRateParameterName = "OuterTrailSpawnRate";
    public VisualEffect vfx; // Reference to the VFX Graph component

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (GameManager.instance != null)
            {
                GameManager.instance.IncreaseKeyPieceAmount(1);

            }

            SetSpawnRatesToZero();
            StartCoroutine(DestroyAfterDelay(7f));
            DisableCollider();

            Debug.Log("Collided");

            // Play the new pickup sound
            RuntimeManager.PlayOneShot(pickupSound, transform.position);
        }
    }

    private void SetSpawnRatesToZero()
    {
        // Reset float parameters in VFX
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
