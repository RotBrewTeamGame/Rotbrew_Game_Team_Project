using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using FMODUnity;
using FMOD.Studio;

public class LootPlants : MonoBehaviour
{
    // Reference to the FMODEvents script
    private FMODEvents fmodEvents;

    // Reference to the crafting event in the FMODEvents script
    public EventReference craftingEvent;

    public List<GameObject> plants;
    public bool inTrigger = false;
    public VisualEffect vfx;
    public string LeafSpawnRateParameterName = "LeafSpawnRate";
    public int plant;

    private Coroutine fadeCoroutine; // Coroutine reference for fading effect

    private void Start()
    {
        // Find and store the FMODEvents script in the scene
        fmodEvents = FindObjectOfType<FMODEvents>();
        if (fmodEvents == null)
        {
            Debug.LogError("FMODEvents script not found in the scene.");
        }
    }

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
            if (plant == 0)
            {
                GameManager.instance.damagePlantItemCount++;
            }
            if (plant == 1)
            {
                GameManager.instance.healthHerbItemCount++;
            }
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

            // Play crafting audio using the EventReference from the FMODEvents script
            if (fmodEvents != null)
            {
                RuntimeManager.PlayOneShot(craftingEvent, transform.position);
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
