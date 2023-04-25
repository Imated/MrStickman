using System.Collections.Generic;
using System.Linq;
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
    [SerializeField] private GameObject choicesBox;
    [Space]
    [SerializeField] private GameObject choicePrefab;

    private Dialogue _currentDialogue;
    
    protected override void Awake()
    {
        base.Awake();
        StartDialogue(dialogues[0].name);
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
        var dialogue = dialogues.Find((d) => d.name == id);
        if (!dialogue.isChoice)
        {
            choicesBox.SetActive(false);
            dialogueText.text = dialogue.dialogueText;
        }
        else
        {
            choicesBox.SetActive(true);
            for (var i = 0; i < dialogue.choices.Count; i++)
            {
                var choiceText = dialogue.choices.ElementAt(i).Key;
                var choiceDialogue = dialogue.choices.ElementAt(i).Value;
                
                var choiceObject = Instantiate(choicePrefab, Vector3.zero, Quaternion.identity, choicesBox.transform);
                choiceObject.GetComponentInChildren<TMP_Text>().text = choiceText;
                choiceObject.GetComponent<Button>().onClick.AddListener(() =>
                {
                    StartDialogue(choiceDialogue.name);
                    foreach (var c in choicesBox.transform)
                        Destroy(c as GameObject);
                });
            }
        }
        
        dialogueName.text = dialogue.dialogueName;
        dialogueIcon.sprite = dialogue.icon;
        _currentDialogue = dialogue;
        ShowDialogue();
    }

    private void Update()
    {
        if (_currentDialogue != null && !_currentDialogue.isChoice && Mouse.current.leftButton.wasPressedThisFrame)
        {
            if(_currentDialogue.nextDialogue != null)
                StartDialogue(_currentDialogue.nextDialogue.name);
            else
                HideDialogue();
        }
    }
}
