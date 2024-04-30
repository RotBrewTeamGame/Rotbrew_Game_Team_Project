using System.Collections;
using UnityEngine;

public class EnemyDart : MonoBehaviour
{
    public Transform player;
    public GameObject goblin; // Reference to the goblin GameObject
    public GameObject dartPrefab;
    public Transform dartSpawnPoint;
    public float force;
    public bool isShooting = false;

    private Quaternion enemyRotation;

    // Remove the field initializer for dartRotation

    void Start()
    {

        // Start shooting coroutine
        StartCoroutine(ShootDart());
    }

    void Update()
    {
        if (goblin != null)
        {
            enemyRotation = goblin.transform.rotation;
        }
        else
        {
            Debug.LogError("Goblin GameObject reference is missing!");
        }
    }

    public IEnumerator ShootDart()
    {
        yield return new WaitForSeconds(1);

        if (isShooting)
        {
            // Initialize dartRotation here
            Quaternion dartRotation = Quaternion.Euler(-66.016f, enemyRotation.eulerAngles.y - 90f, -90f);

            GameObject dart = Instantiate(dartPrefab, dartSpawnPoint.position, dartRotation);
            Rigidbody dartRigidbody = dart.GetComponent<Rigidbody>();

            // Apply force in the forward direction of the dartSpawnPoint
            dartRigidbody.velocity = dartSpawnPoint.forward * force;

            Destroy(dart, 2); // Destroy after 2 seconds
        }

        StartCoroutine(ShootDart());
    }
}
