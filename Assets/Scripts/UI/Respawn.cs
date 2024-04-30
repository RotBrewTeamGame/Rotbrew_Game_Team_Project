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
    public PotionThrower potionThrower;
    public LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = player.GetComponent<PlayerHealth>();
        movement = player.GetComponent <FirstPersonMovement>();
        lineRenderer = player.GetComponent<LineRenderer>();
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
        StartCoroutine(EnablePotionThrowerAfterDelay());
    }

    private IEnumerator EnablePotionThrowerAfterDelay()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        player.transform.position = respawnPoint.position;
        player.transform.rotation = respawnPoint.rotation;
        playerHealth.health = playerHealth.maxHealth;
        healthBar.fillAmount = 1;
        movement.enabled = true;
        rB.isKinematic = false;
        lineRenderer.enabled = false;
        potionThrower.canThrowPotion = true;
        Time.timeScale = 1f;
        deathScreen.SetActive(false);
    }
}