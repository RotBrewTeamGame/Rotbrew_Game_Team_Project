using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionSplash : MonoBehaviour
{
    [Header("Splash Prefab")]
    //[SerializeField] private GameObject splashEffectPrefab; // reference to explosion effect prefab
    [SerializeField] private Vector3 splashParticleOffset = new Vector3(0, 1, 0);

    [Header("Splash Settings")]
    [SerializeField] private float splashDelay = 1f; // delay before explosion
    [SerializeField] private float splashForce = 700f; // force applied by splash
    [SerializeField] private float splashRadius = 5f; // radius of splash

    [Header("Audio Effects")]

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
        //GameObject splashEffect = Instantiate(splashEffectPrefab, transform.position + splashParticleOffset, Quaternion.identity);

        //Destroy(splashEffect, 4f);

        // Play Sound Effect

        Destroy(gameObject);
    }
}
