using FMODUnity;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    public SwitchPotion potions;
    public PlayerHealth health;
    public PauseGame pauseGame;

    [SerializeField] private EventReference healthPotionSound; // Reference to the FMOD sound for the health potion

    void Update()
    {
        if (pauseGame != null && !pauseGame.isPaused)
        {
            if (potions.healthPotionON && Input.GetKeyDown(KeyCode.Mouse1) && GameManager.instance.healthPotionItemCount != 0 && health.health != health.maxHealth)
            {
                health.HealHealth(1);
                GameManager.instance.healthPotionItemCount--;

                // Play the health potion sound
                AudioManager.instance.PlayOneShot(healthPotionSound, transform.position);
            }
        }
    }
}
