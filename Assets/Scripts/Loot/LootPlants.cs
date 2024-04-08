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
    public int nextIndex;
    public int lastDisabledIndex = -1; // Index of the last disabled plant
    private int coroutineIndex = 0; // Index to keep track of current coroutine

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
        if (nextIndex == 0)
        {
            StartCoroutine(RegeneratePlants());
        }

        // Check if at least one game object in the list is active
        bool anyActivePlant = plants.Exists(plant => plant.activeSelf);

        if (anyActivePlant)
        {
            // Find the next enabled game object to disable
            nextIndex = lastDisabledIndex + 1;
            while (nextIndex < plants.Count && !plants[nextIndex].activeSelf)
            {
                nextIndex++;
            }

            // Check if there is an enabled game object to disable
            if (nextIndex < plants.Count)
            {
                // Disable the next enabled game object
                plants[nextIndex].SetActive(false);
                lastDisabledIndex = nextIndex;

                // Increment count based on plant type
                if (plant == 0)
                {
                    GameManager.instance.damagePlantItemCount++;
                }
                else if (plant == 1)
                {
                    GameManager.instance.healthHerbItemCount++;
                }
            }

            // Check if all plants are disabled
            bool allPlantsDisabled = plants.TrueForAll(plant => !plant.activeSelf);

            if (allPlantsDisabled)
            {
                // Reset indices
                lastDisabledIndex = -1;
                nextIndex = 0;

                // Start the regeneration coroutine again from the beginning
                StartCoroutine(RegeneratePlants());
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

        if (plants.Count > 0)
        {
            SetSpawnRatesToZero();
            // Start fading effect only if it's not already running
            if (fadeCoroutine == null)
            {
                fadeCoroutine = StartCoroutine(FadeLeafSpawnRate());
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

    IEnumerator RegeneratePlants()
    {
        // Wait for all plants to regenerate
        while (coroutineIndex < plants.Count)
        {
            yield return new WaitForSeconds(180f); // Wait for 3 minutes
            plants[coroutineIndex].SetActive(true);
            coroutineIndex++;
            lastDisabledIndex = -1;
            nextIndex = 0;
        }

        // Set spawn rate to 10 after regenerating all plants
        SetSpawnRateToMax();

        // Reset coroutine index after regenerating all plants
        coroutineIndex = 0;
    }

    private void SetSpawnRateToMax()
    {
        // Set float parameters in VFX to maximum (10)
        vfx.SetFloat(LeafSpawnRateParameterName, 10f);
    }
}