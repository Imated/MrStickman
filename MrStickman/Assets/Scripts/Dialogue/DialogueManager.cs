using System;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
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

    private Dialogue _currentDialogue;
    
    protected override void Awake()
    {
        base.Awake();
        HideDialogue();
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
        dialogueName.text = dialogue.dialogueName;
        dialogueText.text = dialogue.dialogueText;
        dialogueIcon.sprite = dialogue.icon;
        _currentDialogue = dialogue;
        ShowDialogue();
    }

    private void Update()
    {
        if (_currentDialogue != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            if(_currentDialogue.nextDialogue != null)
                StartDialogue(_currentDialogue.nextDialogue.id);
            else
                HideDialogue();
        }
    }
}
