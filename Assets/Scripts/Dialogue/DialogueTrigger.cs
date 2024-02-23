using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private List<dialogueString> dialogueStrings = new List<dialogueString>();
    [SerializeField] private Transform NPCTransform;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<DialogueManager>().DialogueStart(dialogueStrings, NPCTransform);
        }
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
