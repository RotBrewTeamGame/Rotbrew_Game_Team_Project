using UnityEngine;

public class TextureRotator : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 50f; // Speed of rotation

    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        // Calculate the new offset based on time and rotation speed
        float offset = Time.time * rotationSpeed % 360f;

        // Set the texture offset to create the rotation effect
        rend.material.mainTextureOffset = new Vector2(offset, 0);
    }
}
