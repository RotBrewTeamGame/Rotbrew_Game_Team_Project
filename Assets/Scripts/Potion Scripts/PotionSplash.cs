using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.VFX;

public class PotionSplash : MonoBehaviour
{
    [Header("Splash Prefab")]
    //[SerializeField] private GameObject splashEffectPrefab; // reference to explosion effect prefab
    [SerializeField] private Vector3 splashParticleOffset = new Vector3(0, 1, 0);

    [Header("Splash Settings")]
    [SerializeField] private float splashDelay = 1f; // delay before explosion
    [SerializeField] private float splashForce = 700f; // force applied by splash
    [SerializeField] private float splashRadius = 5f; // radius of splash
    [SerializeField] public EventReference S100PotionSmashSFX;
    [SerializeField] public VisualEffectAsset potionSmashEffect;
    [SerializeField] public GameObject VFXPrefab;

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

    public void BreakPotion()
    {
        GameObject potionSmashEffect = Instantiate(VFXPrefab, transform.position, Quaternion.identity);
        VisualEffectAsset potionSmashEffectComponent = potionSmashEffect.GetComponent<VisualEffectAsset>();

        Destroy(potionSmashEffectComponent, 10f);
        Destroy(potionSmashEffect, 10f);

        Destroy(gameObject);
    }

}
