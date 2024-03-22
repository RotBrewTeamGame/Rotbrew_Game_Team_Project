using UnityEngine;

public class FrostPotionCraft : MonoBehaviour
{
    public FMODEvents fmodEvents;

    void Start()
    {
        if (fmodEvents == null)
        {
            Debug.LogError("FMODEvents reference is not set.");
        }
    }

    void Update()
    {

    }

    public void OnButtonClick()
    {
        if (GameManager.instance.damagePlantItemCount >= 1 && GameManager.instance.iceCrystalItemCount >= 1)
        {
            GameManager.instance.damagePlantItemCount--;
            GameManager.instance.iceCrystalItemCount--;
            GameManager.instance.frostPotionItemCount++;

            if (fmodEvents != null)
            {
                fmodEvents.PlayFrostPotionCraftingAudio();
            }
            else
            {
                Debug.LogWarning("FMODEvents reference is not set.");
            }
        }
    }
}
