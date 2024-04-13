using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SewerShortcut : MonoBehaviour
{
    public EnemyHealth bossHealth;
    public GameObject sewerShortcut;
    public Canvas interactionUI;
    public bool sewerBossDead;

    public void Start()
    {
        sewerBossDead = false;
        sewerShortcut.SetActive(false);
        interactionUI.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (bossHealth.enemyHealth == 0)
        {
            sewerBossDead = true;
        }

        if (sewerBossDead)
        {
            sewerShortcut.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (sewerBossDead)
        {
            interactionUI.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (sewerBossDead)
        {
            interactionUI.gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            SceneNavigator.instance.LoadCityCentre();
        }
    }
}
