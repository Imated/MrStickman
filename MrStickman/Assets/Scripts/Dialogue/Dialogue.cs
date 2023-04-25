using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Dialogue", fileName = "New Dialogue Item")]
public class Dialogue : ScriptableObject
{
    public Dialogue nextDialogue;
    public string dialogueName;
    public Sprite icon;
    [TextArea] public string dialogueText;
    [Space]
    public bool isChoice;
    public List<string> choices;
    public List<Dialogue> choiceDialogues;
}