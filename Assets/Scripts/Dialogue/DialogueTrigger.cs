using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private List<dialogueString> dialogueStrings = new List<dialogueString>();
    [SerializeField] private Transform NPCTransform;
    [SerializeField] private GameObject interactionUI;
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private bool canTalk;
    [SerializeField] private bool isTalking;

    private void Start()
    {
        interactionUI.SetActive(false);
        dialogueManager.dialogueON = false;
        isTalking = false;
    }

    private void Update()
    {
        if (canTalk && Input.GetKeyDown(KeyCode.E))
        {
            dialogueManager.DialogueStart(dialogueStrings, NPCTransform);
            dialogueManager.dialogueON = true;
            isTalking = true;
            canTalk = false;
        }

        if (isTalking && Input.GetKeyDown(KeyCode.R))
        {
            dialogueManager.DialogueStop();
            dialogueManager.dialogueON = false;
            isTalking = false;
            canTalk = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            interactionUI.SetActive(true);
            canTalk = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        interactionUI.SetActive(false);
        canTalk = false;
    }
}
    [System.Serializable]
    public class dialogueString
    {
        public string text; // Represent the text that the NPC says
        public bool isEnd; // Represent if the line is the final line for the conversation

        [Header("Branch")]
        public bool isQuestion;
        public string answerOption1;
        public string answerOption2;
        public int option1IndexJump;
        public int option2IndexJump;

        [Header("Triggered Events")]
        public UnityEvent startDialogueEvent;
        public UnityEvent endDialogueEvent;
    }
