using UnityEngine;

public class FirePotionCraft : MonoBehaviour
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
        if (GameManager.instance.damagePlantItemCount >= 1 && GameManager.instance.slimeBallItemCount >= 1)
        {
            GameManager.instance.damagePlantItemCount--;
            GameManager.instance.slimeBallItemCount--;
            GameManager.instance.firePotionItemCount++;

            // Play crafting audio
            if (fmodEvents != null)
            {
                fmodEvents.PlayFirePotionCraftingAudio(); // You need to define this method in the FMODEvents script
            }
            else
            {
                Debug.LogWarning("FMODEvents reference is not set.");
            }
        }
    }
}
