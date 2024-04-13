using FMODUnity;
using UnityEngine;
using UnityEngine.VFX;

public class PotionSplash : MonoBehaviour
{
    [Header("Splash Prefab")]
    [SerializeField] private Vector3 splashParticleOffset = new Vector3(0, 1, 0);

    [Header("Splash Settings")]
    [SerializeField] private float splashDelay = 1f; // delay before explosion
    [SerializeField] private float splashForce = 700f; // force applied by splash
    [SerializeField] private float splashRadius = 5f; // radius of splash
    [SerializeField] private EventReference potionSmashed;
    [SerializeField] private GameObject VFXPrefab;

    // Define sound references for each potion type
    [SerializeField] private EventReference frostPotionSound;
    [SerializeField] private EventReference firePotionSound;
    [SerializeField] private EventReference damagePotionSound;

    private float countdown;
    public bool hasBroke = false;

    private void Start()
    {
        countdown = splashDelay;
    }

    private void Update()
    {
        if (!hasBroke)
        {
            countdown -= Time.deltaTime;

            if (countdown <= 0f)
            {
                BreakPotion();
                hasBroke = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (gameObject.CompareTag("frostPotion"))
            {
                AudioManager.instance.PlayOneShot(frostPotionSound, transform.position);
            }
            else if (gameObject.CompareTag("firePotion"))
            {
                AudioManager.instance.PlayOneShot(firePotionSound, transform.position);
            }
            else if (gameObject.CompareTag("damagePotion"))
            {
                AudioManager.instance.PlayOneShot(damagePotionSound, transform.position);
            }
        }
    }

    public void BreakPotion()
    {
        GameObject potionSmashEffect = Instantiate(VFXPrefab, transform.position, Quaternion.identity);
        VisualEffectAsset potionSmashEffectComponent = potionSmashEffect.GetComponent<VisualEffectAsset>();
        AudioManager.instance.PlayOneShot(potionSmashed, transform.position);
        Destroy(potionSmashEffectComponent, 6f);
        Destroy(potionSmashEffect, 6f);

        Destroy(gameObject);
    }
}
