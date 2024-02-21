using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class BossDoor : MonoBehaviour
{
    public GameObject bossDoor;
    public Canvas interactionUI;
    public TextMeshProUGUI text;

    public bool canOpen;

    public void Start()
    {
        interactionUI.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        interactionUI.gameObject.SetActive(true);

        if (other.gameObject.tag == "Player" && GameManager.instance.keyItemCount <= 1)
        {
            text.color = Color.red;
            canOpen = false;
        }

        if (other.gameObject.tag == "Player" && GameManager.instance.keyItemCount >= 1)
        {
            text.color = Color.green;
            canOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        interactionUI.gameObject.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && canOpen && Input.GetKeyDown(KeyCode.E))
        {
            bossDoor.SetActive(false);
        }
    }
}
