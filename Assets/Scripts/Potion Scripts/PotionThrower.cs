using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PotionThrower : MonoBehaviour
{
    [Header("Potion Prefab")]
    [SerializeField] private GameObject damagePotionPrefab; // reference to potion prefab
    [SerializeField] private GameObject frostPotionPrefab; // reference to potion prefab
    [SerializeField] private GameObject firePotionPrefab; // reference to potion prefab

    [Header("Potion Settings")]
    [SerializeField] private KeyCode throwKey = KeyCode.Mouse0;
    [SerializeField] private Transform throwPosition;
    [SerializeField] private Vector3 throwDirection = new Vector3(0, 1, 0);
    public FirstPersonMovement player;

    [Header("Potion Force")]
    [SerializeField] private float throwForce = 10f; // force applied to throw potion
    [SerializeField] private float maxForce = 20f; // maximum force applied to throw potion

    [Header("Trajectory Settings")]
    [SerializeField] private LineRenderer trajectoryLine;

    [Header("SFX")]
    [SerializeField] private EventReference damagePotionThrow;

    private Camera mainCam;

    private bool isCharging = false; // check if player is charging the throw
    private float chargeTime = 0f; // time player has been charging throw
    public GameObject craftingUI;
    public GameObject damagePotionUI;
    public GameObject frostPotionUI;
    public GameObject firePotionUI;

    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(throwKey) && GameManager.instance.damagePotionItemCount != 0 && !craftingUI.activeSelf && damagePotionUI.activeSelf ||
            Input.GetKeyDown(throwKey) && GameManager.instance.frostPotionItemCount != 0 && !craftingUI.activeSelf && frostPotionUI.activeSelf ||
            Input.GetKeyDown(throwKey) && GameManager.instance.firePotionItemCount != 0 && !craftingUI.activeSelf && firePotionUI.activeSelf)
        {
            StartThrowing();
        }
        if (isCharging && GameManager.instance.damagePotionItemCount != 0 && !craftingUI.activeSelf && damagePotionUI.activeSelf ||
            isCharging && GameManager.instance.frostPotionItemCount != 0 && !craftingUI.activeSelf && frostPotionUI.activeSelf ||
            isCharging && GameManager.instance.firePotionItemCount != 0 && !craftingUI.activeSelf && firePotionUI.activeSelf)
        {
            ChargeThrow();
        }
        if (Input.GetKeyUp(throwKey) && GameManager.instance.damagePotionItemCount != 0 && !craftingUI.activeSelf && damagePotionUI.activeSelf ||
            Input.GetKeyUp(throwKey) && GameManager.instance.frostPotionItemCount != 0 && !craftingUI.activeSelf && frostPotionUI.activeSelf ||
            Input.GetKeyUp(throwKey) && GameManager.instance.firePotionItemCount != 0 && !craftingUI.activeSelf && firePotionUI.activeSelf)
        {
            ReleaseThrow();
            if (damagePotionUI.activeSelf)
            {
                GameManager.instance.damagePotionItemCount = GameManager.instance.damagePotionItemCount - 1;
            }
            if (frostPotionUI.activeSelf)
            {
                GameManager.instance.frostPotionItemCount = GameManager.instance.frostPotionItemCount - 1;
            }
            if (firePotionUI.activeSelf)
            {
                GameManager.instance.firePotionItemCount = GameManager.instance.firePotionItemCount - 1;
            }
        }
    }

    void StartThrowing()
    {
        isCharging = true;
        chargeTime = 0f;

        trajectoryLine.enabled = true;
    }

    void ChargeThrow()
    {
        chargeTime += Time.deltaTime;

        Vector3 potionVelocity = (mainCam.transform.forward + throwDirection).normalized * Mathf.Min(chargeTime * throwForce, maxForce);
        ShowTrajectory(throwPosition.position + throwPosition.forward, potionVelocity);
    }

    void ReleaseThrow()
    {
        ThrowPotion(Mathf.Min(chargeTime * throwForce, maxForce));

        isCharging = false;

        trajectoryLine.enabled = false;
    }

    void ThrowPotion(float force)
    {
        Vector3 spawnPos = throwPosition.position + mainCam.transform.forward;

        if (damagePotionUI.activeSelf)
        {
            GameObject damagePotion = Instantiate(damagePotionPrefab, spawnPos, mainCam.transform.rotation);
            Rigidbody potionRB = damagePotion.GetComponent<Rigidbody>();
            Rigidbody playerRB = this.GetComponent<Rigidbody>();

            AudioManager.instance.PlayOneShot(damagePotionThrow, this.transform.position);

            potionRB.velocity = playerRB.velocity;

            Vector3 finalThrowDirection = (mainCam.transform.forward + throwDirection).normalized;
            potionRB.AddForce(finalThrowDirection * force, ForceMode.VelocityChange);

            AudioManager.instance.PlayOneShot(damagePotionThrow, this.transform.position);
        }
        if (frostPotionUI.activeSelf)
        {
            GameObject frostPotion = Instantiate(frostPotionPrefab, spawnPos, mainCam.transform.rotation);
            Rigidbody potionRB = frostPotion.GetComponent<Rigidbody>();
            Rigidbody playerRB = this.GetComponent<Rigidbody>();

            AudioManager.instance.PlayOneShot(damagePotionThrow, this.transform.position);

            potionRB.velocity = playerRB.velocity;

            Vector3 finalThrowDirection = (mainCam.transform.forward + throwDirection).normalized;
            potionRB.AddForce(finalThrowDirection * force, ForceMode.VelocityChange);

            AudioManager.instance.PlayOneShot(damagePotionThrow, this.transform.position);
        }
        if (firePotionUI.activeSelf)
        {
            GameObject firePotion = Instantiate(firePotionPrefab, spawnPos, mainCam.transform.rotation);
            Rigidbody potionRB = firePotion.GetComponent<Rigidbody>();
            Rigidbody playerRB = this.GetComponent<Rigidbody>();

            AudioManager.instance.PlayOneShot(damagePotionThrow, this.transform.position);

            potionRB.velocity = playerRB.velocity;

            Vector3 finalThrowDirection = (mainCam.transform.forward + throwDirection).normalized;
            potionRB.AddForce(finalThrowDirection * force, ForceMode.VelocityChange);

            AudioManager.instance.PlayOneShot(damagePotionThrow, this.transform.position);
        }
    }

    void ShowTrajectory(Vector3 origin, Vector3 speed)
    {
        Vector3[] points = new Vector3[100];
        trajectoryLine.positionCount = points.Length;

        for (int i = 0; i < points.Length; i++)
        {
            float time = i * 0.1f;
            points[i] = origin + speed * time + 0.5f * Physics.gravity * time * time; 
        }
        trajectoryLine.SetPositions(points);
    }
}
