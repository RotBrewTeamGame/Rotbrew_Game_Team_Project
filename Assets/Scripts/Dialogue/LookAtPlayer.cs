using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 directionToPlayer = player.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
        lookRotation.x = transform.rotation.x;
        lookRotation.z = transform.rotation.z;
        transform.rotation = lookRotation;
    }
}
