using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DialogueManager : Singleton<DialogueManager>
{
    [SerializeField] private List<Dialogue> dialogues;
    [SerializeField] private float fadeDuration = 0.25f;
    [Space]
    [SerializeField] private CanvasGroup dialogueBox;
    [SerializeField] private TMP_Text dialogueName;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private Image dialogueIcon;
    [SerializeField] private GameObject choicesBox;
    [Space]
    [SerializeField] private GameObject choicePrefab;

    private Dialogue _currentDialogue;
    
    protected override void Awake()
    {
        base.Awake();
        StartDialogue(dialogues[0].id);
    }

    private void ShowDialogue()
    {
        transform.DOKill();
        dialogueBox.gameObject.SetActive(true);
        dialogueBox.DOFade(1f, fadeDuration);
    }
    
    private void HideDialogue()
    {
        transform.DOKill();
        dialogueBox.DOFade(0f, fadeDuration).OnComplete(() =>
        {
            dialogueBox.gameObject.SetActive(false);
        });
    }

    public void StartDialogue(string id)
    {
        var dialogue = dialogues.Find((d) => d.id == id);
        if (!dialogue.isChoice)
        {
            choicesBox.SetActive(false);
            dialogueName.text = dialogue.dialogueName;
            dialogueText.text = dialogue.dialogueText;
            dialogueIcon.sprite = dialogue.icon;
        }
        else
        {
            choicesBox.SetActive(true);
            for (var i = 0; i < dialogue.choices.Count; i++)
            {
                var choice = dialogue.choices[i];
                var nextDialogue = dialogue.choiceDialogues[i];
                var choiceObject = Instantiate(choicePrefab, Vector3.zero, Quaternion.identity, choicesBox.transform);
                choiceObject.GetComponentInChildren<TMP_Text>().text = choice;
                choiceObject.GetComponent<Button>().onClick.AddListener(() =>
                {
                    StartDialogue(nextDialogue.id);
                    foreach (var c in choicesBox.transform)
                        Destroy(c as GameObject);
                });
            }
        }
        _currentDialogue = dialogue;
        ShowDialogue();
    }

    private void Update()
    {
        if (_currentDialogue != null && !_currentDialogue.isChoice && Mouse.current.leftButton.wasPressedThisFrame)
        {
            if(_currentDialogue.nextDialogue != null)
                StartDialogue(_currentDialogue.nextDialogue.id);
            else
                HideDialogue();
        }
    }
}
