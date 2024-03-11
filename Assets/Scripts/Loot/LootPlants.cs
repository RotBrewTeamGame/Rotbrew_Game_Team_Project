using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class LootPlants : MonoBehaviour
{
    public List<GameObject> plants;
    public int currentObject = 0;
    public bool inTrigger = false;
    public int plant;
    public VisualEffect vfx;
    public string LeafSpawnRateParameterName = "LeafSpawnRate";

    private Coroutine fadeCoroutine; // Coroutine reference for fading effect

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            inTrigger = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            inTrigger = false;
        }
    }

    void Update()
    {
        if (inTrigger && Input.GetKeyDown(KeyCode.E))
        {
            if (currentObject < plants.Count)
            {
                Destroy(plants[currentObject]);
                currentObject++;
                if (plant == 0)
                {
                    GameManager.instance.damagePlantItemCount++;
                }
                if (plant == 1)
                {
                    GameManager.instance.healthHerbItemCount++;
                }
                // Check if the gameObject list is empty
                if (plants.Count == 0)
                {
                    SetSpawnRatesToZero ();
                    // Start fading effect only if it's not already running
                    if (fadeCoroutine == null)
                    {
                        fadeCoroutine = StartCoroutine(FadeLeafSpawnRate());
                    }
                }
            }
        }
    }

    private void SetSpawnRatesToZero()
    {
        // Set float parameters in VFX to zero
        vfx.SetFloat(LeafSpawnRateParameterName, 0f);
    }

    IEnumerator FadeLeafSpawnRate()
    {
        float duration = 3f;
        float elapsedTime = 0f;
        float startValue = 10f;
        float endValue = 0f;

        while (elapsedTime < duration)
        {
            // Calculate the interpolation factor (0 to 1)
            float t = elapsedTime / duration;

            // Interpolate the LeafSpawnRate value from startValue to endValue
            float newValue = Mathf.Lerp(startValue, endValue, t);

            // Set the new value of the LeafSpawnRate parameter
            vfx.SetFloat("LeafSpawnRate", newValue);

            // Increment the timer
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        // Ensure the final value is set
        vfx.SetFloat("LeafSpawnRate", endValue);

        // Reset coroutine reference
        fadeCoroutine = null;
    }
}
