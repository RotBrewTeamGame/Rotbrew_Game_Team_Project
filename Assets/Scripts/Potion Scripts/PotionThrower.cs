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

    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(throwKey) && GameManager.instance.damagePotionItemCount != 0 && !craftingUI.activeSelf && damagePotionUI.activeSelf)
        {
            StartThrowing();
        }
        if (isCharging && GameManager.instance.damagePotionItemCount != 0 && !craftingUI.activeSelf && damagePotionUI.activeSelf)
        {
            ChargeThrow();
        }
        if (Input.GetKeyUp(throwKey) && GameManager.instance.damagePotionItemCount != 0 && !craftingUI.activeSelf && damagePotionUI.activeSelf)
        {
            ReleaseThrow();
            GameManager.instance.damagePotionItemCount = GameManager.instance.damagePotionItemCount - 1;
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

            GameObject potion = Instantiate(potionPrefab, spawnPos, mainCam.transform.rotation);

            Rigidbody rb = potion.GetComponent<Rigidbody>();

            AudioManager.instance.PlayOneShot(damagePotionThrow, this.transform.position);

            Vector3 finalThrowDirection = (mainCam.transform.forward + throwDirection).normalized;
            rb.AddForce(finalThrowDirection * force, ForceMode.VelocityChange);
            AudioManager.instance.PlayOneShot(damagePotionThrow, this.transform.position);
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
