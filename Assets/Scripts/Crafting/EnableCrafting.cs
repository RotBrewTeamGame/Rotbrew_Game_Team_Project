using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableCrafting : MonoBehaviour
{
    public GameObject craftingSystem;
    public GameObject uI;
    public bool triggered;
    public bool interacted;
    public FirstPersonMovement firstPersonMovement;
    public FirstPersonLook firstPersonLook;
    public Rigidbody rb;

    void Start()
    {
        craftingSystem.SetActive(false);
        uI.SetActive(false);
        firstPersonMovement = GetComponent<FirstPersonMovement>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (triggered)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                interacted = !interacted;
                craftingSystem.SetActive(interacted);
                firstPersonMovement.enabled = !interacted;
                firstPersonLook.enabled = !interacted;
            }
        }

        if (interacted)
        {
            rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        }
        else
        {
            rb.constraints &= ~RigidbodyConstraints.FreezePosition;

        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "CraftingStation")
        {
            uI.SetActive(true);
            triggered = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "CraftingStation")
        {
            uI.SetActive(false);
            triggered = false;
            craftingSystem?.SetActive(false);
        }
    }
}
