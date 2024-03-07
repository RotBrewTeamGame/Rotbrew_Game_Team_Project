using UnityEngine;

public class AltKeyVision : MonoBehaviour
{
    public Shader blackAndWhiteShader; // Shader for black and white effect
    public KeyCode toggleKey = KeyCode.LeftAlt; // Key to toggle effect
    public ParticleSystem[] particleSystems; // Array of particle systems to be visible through walls

    private bool visionEnabled = false;
    private Material blackAndWhiteMaterial;

    void Start()
    {
        blackAndWhiteMaterial = new Material(blackAndWhiteShader);
    }

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            visionEnabled = !visionEnabled;

            if (visionEnabled)
                EnableVision();
            else
                DisableVision();
        }
    }

    void EnableVision()
    {
        // Set all cameras to use the black and white shader
        foreach (Camera cam in Camera.allCameras)
        {
            cam.SetReplacementShader(blackAndWhiteShader, "");
        }

        // Set the particle systems to be visible through walls
        foreach (ParticleSystem ps in particleSystems)
        {
            ps.GetComponent<Renderer>().material.renderQueue = 3002;
        }
    }

    void DisableVision()
    {
        // Revert all cameras to their original shaders
        foreach (Camera cam in Camera.allCameras)
        {
            cam.ResetReplacementShader();
        }

        // Reset the render queue of particle systems
        foreach (ParticleSystem ps in particleSystems)
        {
            ps.GetComponent<Renderer>().material.renderQueue = 3000;
        }
    }
}
