using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Respawn : MonoBehaviour
{
    public Transform respawnPoint;
    public GameObject player;
    public PlayerHealth playerHealth;
    public FirstPersonMovement movement;
    public Image healthBar;
    public GameObject deathScreen;
    public Rigidbody rB;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = player.GetComponent<PlayerHealth>();
        movement = player.GetComponent <FirstPersonMovement>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Awake()
    {

    }

    public void OnButtonClick()
    {
        player.transform.position = respawnPoint.position;
        player.transform.rotation = respawnPoint.rotation;
        playerHealth.health = playerHealth.maxHealth;
        healthBar.fillAmount = 1;
        movement.enabled = true;
        deathScreen.SetActive(false);
        rB.isKinematic = false;
    }
}
