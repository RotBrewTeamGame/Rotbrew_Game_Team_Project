using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using FMODUnity;

public class WinLoot : MonoBehaviour
{
    public EventReference winPickUpSound; // New pickup sound event reference
    public string winCoreSpawnRateParameterName = "CoreSpawnRate"; // Name of the float parameter in VFX
    public string winTrailSpawnRateParameterName = "TrailSpawnRate";
    public string winOuterTrailSpawnRateParameterName = "OuterTrailSpawnRate";
    public VisualEffect winVfx; // Reference to the VFX Graph component
    public WinGame winGame;

    void Start()
    {
        winGame = GameObject.Find("Win").GetComponent<WinGame>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (GameManager.instance != null)
            {
                winGame.win = true;
                Time.timeScale = 0f;
            }

            SetWinSpawnRatesToZero();
            StartCoroutine(WinDestroyAfterDelay(7f));
            WinDisableCollider();

            Debug.Log("Collided");

            // Play the new pickup sound
            RuntimeManager.PlayOneShot(winPickUpSound, transform.position);
        }
    }

    private void SetWinSpawnRatesToZero()
    {
        // Reset float parameters in VFX
        winVfx.SetFloat(winCoreSpawnRateParameterName, 0f);
        winVfx.SetFloat(winTrailSpawnRateParameterName, 0f);
        winVfx.SetFloat(winOuterTrailSpawnRateParameterName, 0f);
    }

    private IEnumerator WinDestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

    private void WinDisableCollider()
    {
        Collider collider = GetComponent<Collider>();
        if (collider != null)
        {
            collider.enabled = false;
        }
    }
}
