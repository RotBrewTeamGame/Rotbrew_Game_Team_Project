using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject dialogueParent;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private Button option1Button;
    [SerializeField] private Button option2Button;

    [SerializeField] private float typingSpeed = 0.05f;
    [SerializeField] private float turnSpeed = 2f;

    private List<dialogueString> dialogueList;

    [Header("Player")]
    [SerializeField] private FirstPersonMovement firstPersonMovements;
    [SerializeField] private FirstPersonLook firstPersonCam;
    [SerializeField] private PotionThrower potionController;
    public bool dialogueON;
    private Transform playerCamera;

    private int currentDialogueIndex = 0;

    public Rigidbody playerRB;

    private void Start()
    {
        dialogueParent.SetActive(false);
        playerCamera = Camera.main.transform;
        playerRB = GetComponent<Rigidbody>();
    }

    public void DialogueStart(List<dialogueString> textToPrint, Transform NPC)
    {
        dialogueParent.SetActive(true);
        firstPersonMovements.enabled = false;
        firstPersonCam.enabled = false;
        potionController.enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        StartCoroutine(TurnCameraTowardsNPC(NPC));

        dialogueList = textToPrint;
        currentDialogueIndex = 0;

        DisableButtons();

        StartCoroutine(PrintDialogue());
    }

    private void DisableButtons()
    {
        option1Button.interactable = false;
        option2Button.interactable = false;

        option1Button.GetComponentInChildren<TMP_Text>().text = "LMB to Continue";
        option2Button.GetComponentInChildren<TMP_Text>().text = "LMB to Continue";
    }

    private IEnumerator TurnCameraTowardsNPC(Transform NPC)
    {
        Quaternion startRotation = playerCamera.rotation;
        Quaternion targetRotation = Quaternion.LookRotation(NPC.position - playerCamera.position);

        playerRB.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;

        float elapsedTime = 0f;

        while (elapsedTime < 1f)
        {
            playerCamera.rotation = Quaternion.Slerp(startRotation, targetRotation, elapsedTime);
            elapsedTime += Time.deltaTime * turnSpeed;
            yield return null;
        }

        playerCamera.rotation = targetRotation;
        playerRB.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
    }

    private bool optionSelected = false;

    private IEnumerator PrintDialogue()
    {
        while (currentDialogueIndex < dialogueList.Count)
        {
            dialogueString line = dialogueList[currentDialogueIndex];

            line.startDialogueEvent.Invoke();

            if (line.isQuestion)
            {
                yield return StartCoroutine(TypeText(line.text));

                option1Button.interactable = true;
                option2Button.interactable = true;

                option1Button.GetComponentInChildren<TMP_Text>().text = line.answerOption1;
                option2Button.GetComponentInChildren<TMP_Text>().text = line.answerOption2;

                option1Button.onClick.AddListener(() => HandleOptionSelected(line.option1IndexJump));
                option2Button.onClick.AddListener(() => HandleOptionSelected(line.option2IndexJump));

                yield return new WaitUntil(() => optionSelected);
            }
            else
            {
                yield return StartCoroutine(TypeText(line.text));
            }

            line.endDialogueEvent.Invoke();

            optionSelected = false;
        }

        DialogueStop();
    }

    private void HandleOptionSelected(int indexJump)
    {
        optionSelected = true;
        DisableButtons();

        currentDialogueIndex = indexJump;
    }

    private IEnumerator TypeText(string text)
    {
        dialogueText.text = "";
        foreach (char letter in text.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        if (!dialogueList[currentDialogueIndex].isQuestion)
        {
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        }

        if (dialogueList[currentDialogueIndex].isEnd)
        {
            DialogueStop();
        }

        currentDialogueIndex++;
    }

    public void DialogueStop()
    {
        dialogueON = false;
        StopAllCoroutines();
        dialogueText.text = "";
        dialogueParent.SetActive(false);

        firstPersonMovements.enabled = true;
        firstPersonCam.enabled = true;
        potionController.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        playerRB.constraints &= ~RigidbodyConstraints.FreezeRotationY;
        playerRB.constraints &= ~RigidbodyConstraints.FreezePositionX | ~RigidbodyConstraints.FreezePositionY | ~RigidbodyConstraints.FreezePositionZ;
    }
}
