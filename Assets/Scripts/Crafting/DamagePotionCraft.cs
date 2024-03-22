using UnityEngine;

public class DamagePotionCraft : MonoBehaviour
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
        // Check if there are enough items to craft the potion
        if (GameManager.instance.damagePlantItemCount >= 1)
        {
            // Decrease the number of damage plant items
            GameManager.instance.damagePlantItemCount--;

            // Increase the number of damage potion items
            GameManager.instance.damagePotionItemCount++;

            // Play crafting audio
            if (fmodEvents != null)
            {
                fmodEvents.PlayDamagePotionCraftingAudio(); // Changed to the appropriate method for damage potion crafting
            }
            else
            {
                Debug.LogWarning("FMODEvents reference is not set.");
            }
        }
    }
}
