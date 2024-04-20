using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SewerShortcut : MonoBehaviour
{
    public EnemyHealth boss1Health;
    public EnemyHealth boss2Health;
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
        if (boss1Health.dead && boss2Health.dead)
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
        if (other.gameObject.tag == "Player" && sewerBossDead && Input.GetKeyDown(KeyCode.E))
        {
            SceneNavigator.instance.LoadCityCentre();
        }
    }
}
