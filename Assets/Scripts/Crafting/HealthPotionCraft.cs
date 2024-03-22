using UnityEngine;

public class HealthPotionCraft : MonoBehaviour
{
    // Reference to the FMODEvents script
    public FMODEvents fmodEvents;

    // Start is called before the first frame update
    void Start()
    {
        // Ensure that FMODEvents instance is assigned
        if (fmodEvents == null)
        {
            Debug.LogError("FMODEvents reference is not set.");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnButtonClick()
    {
        if (GameManager.instance.healthHerbItemCount >= 2)
        {
            GameManager.instance.healthHerbItemCount -= 2;
            GameManager.instance.healthPotionItemCount++;

            // Play crafting audio
            if (fmodEvents != null)
            {
                fmodEvents.PlayHealthPotionCraftingAudio(); // You need to define this method in the FMODEvents script
            }
            else
            {
                Debug.LogWarning("FMODEvents reference is not set.");
            }
        }
    }
}
