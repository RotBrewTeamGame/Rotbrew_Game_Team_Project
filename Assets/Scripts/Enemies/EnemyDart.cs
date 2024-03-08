using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDart : MonoBehaviour
{
    public Transform player;
    public GameObject dart;
    public Transform dartSpawn;
    public bool isShooting = false;

    public IEnumerator ShootDart()
    {
        yield return new WaitForSeconds(1);

        if (isShooting)
        {
            GameObject clone;
            clone = Instantiate(dart, dartSpawn.transform.position, Quaternion.identity);
            clone.GetComponent<Rigidbody>().velocity = dartSpawn.TransformDirection(Vector3.forward * 8000 * Time.deltaTime);

            Destroy(clone, 1);
        }

        StartCoroutine(ShootDart());
    }
}
