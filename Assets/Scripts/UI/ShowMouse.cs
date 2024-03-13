using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMouse : MonoBehaviour
{
    public GameObject craftingUI;
    public DialogueManager dialogueManager;
    public GameObject deathScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (craftingUI != null && craftingUI.activeInHierarchy || dialogueManager.dialogueON || deathScreen != null && deathScreen.activeInHierarchy)
        {
            // Show the mouse cursor
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            // Hide the mouse cursor
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
