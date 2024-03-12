using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class LootPlants : MonoBehaviour
{
    public List<GameObject> plants;
    public bool inTrigger = false;
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
            CollectPlant();
        }
    }

    void CollectPlant()
    {
        if (plants.Count > 0)
        {
            Destroy(plants[0]);
            plants.RemoveAt(0);
            if (plants.Count == 0)
            {
                SetSpawnRatesToZero();
                // Start fading effect only if it's not already running
                if (fadeCoroutine == null)
                {
                    fadeCoroutine = StartCoroutine(FadeLeafSpawnRate());
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
            vfx.SetFloat(LeafSpawnRateParameterName, newValue);

            // Increment the timer
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        // Ensure the final value is set
        vfx.SetFloat(LeafSpawnRateParameterName, endValue);

        // Reset coroutine reference
        fadeCoroutine = null;
    }
}
