using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PotionThrower : MonoBehaviour
{
    [Header("Potion Prefab")]
    [SerializeField] private GameObject potionPrefab; // reference to potion prefab

    [Header("Potion Settings")]
    [SerializeField] private KeyCode throwKey = KeyCode.Mouse0;
    [SerializeField] private Transform throwPosition;
    [SerializeField] private Vector3 throwDirection = new Vector3(0, 1, 0);

    [Header("Potion Force")]
    [SerializeField] private float throwForce = 10f; // force applied to throw potion
    [SerializeField] private float maxForce = 20f; // maximum force applied to throw potion

    [Header("SFX")]
    [SerializeField] private EventReference PotionThrowSFX;

    private Camera mainCam;


    private bool isCharging = false; // check if player is charging the throw
    private float chargeTime = 0f; // time player has been charging throw

    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(throwKey))
        {
            StartThrowing();
        }
        if (isCharging)
        {
            ChargeThrow();
        }
        if (Input.GetKeyUp(throwKey))
        {
            ReleaseThrow();
        }
    }

    void StartThrowing()
    {
        isCharging = true;
        chargeTime = 0f;
    }

    void ChargeThrow()
    {
        chargeTime += Time.deltaTime;

        Vector3 potionVelocity = (mainCam.transform.forward + throwDirection).normalized * Mathf.Min(chargeTime * throwForce, maxForce);
    }

    void ReleaseThrow()
    {
        ThrowPotion(Mathf.Min(chargeTime + throwForce, maxForce));
        isCharging = false;
    }

    void ThrowPotion(float force)
    {
        Vector3 spawnPos = throwPosition.position + mainCam.transform.forward;

        GameObject potion = Instantiate(potionPrefab, spawnPos, mainCam.transform.rotation);

        Rigidbody rb = potion.GetComponent<Rigidbody>();

        Vector3 finalThrowDirection = (mainCam.transform.forward + throwDirection).normalized;
        rb.AddForce(finalThrowDirection * force, ForceMode.VelocityChange);
        AudioManager.instance.PlayOneShot(PotionThrowSFX, this.transform.position);
    }
}
