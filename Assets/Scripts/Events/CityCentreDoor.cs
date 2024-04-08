using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class CityCentreDoor : MonoBehaviour
{
    public Canvas interactionUI;

    public void Start()
    {
        interactionUI.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        interactionUI.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        interactionUI.gameObject.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            SceneNavigator.instance.LoadCityCentre();
        }
    }
}
