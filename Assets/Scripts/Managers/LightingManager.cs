using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingManager : MonoBehaviour
{
    private float ambientIntensity;
    private Color ambientLight;

    // Singleton instance
    private static LightingManager instance;
    public static LightingManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject lightingManagerObject = new GameObject("LightingManager");
                instance = lightingManagerObject.AddComponent<LightingManager>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // Ensure only one instance exists
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject); // Persist across scene changes
    }

    // Method to save current lighting settings
    public void SaveLightingSettings()
    {
        ambientIntensity = RenderSettings.ambientIntensity;
        ambientLight = RenderSettings.ambientLight;
    }

    // Method to restore saved lighting settings
    public void RestoreLightingSettings()
    {
        RenderSettings.ambientIntensity = ambientIntensity;
        RenderSettings.ambientLight = ambientLight;
    }
}