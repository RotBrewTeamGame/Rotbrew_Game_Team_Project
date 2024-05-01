using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowKey : MonoBehaviour
{
    public GameObject keyItem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.keyItemCount == 1)
        {
            keyItem.SetActive(true);
        }
        if (GameManager.instance.keyItemCount == 0)
        {
            keyItem.SetActive(false);
        }
    }
}
