using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCraft : MonoBehaviour
{
    public GameObject keyUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClick()
    {
        if (GameManager.instance.keyPieceItemCount >= 3)
        {
            GameManager.instance.keyPieceItemCount = GameManager.instance.keyPieceItemCount - 3;
            keyUI.SetActive(true);
            GameManager.instance.IncreaseKeyAmount(1);
        }
    }
}
