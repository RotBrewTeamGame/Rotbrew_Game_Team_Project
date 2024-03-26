using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowControls : MonoBehaviour
{
    public GameObject controlMap;
    public bool pressed = false;

    // Update is called once per frame
    void Update()
    {
        controlMap.SetActive(pressed);

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            pressed = !pressed;
        }
    }
}
