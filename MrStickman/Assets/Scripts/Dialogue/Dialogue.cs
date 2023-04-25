using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(menuName = "New Dialogue", fileName = "New Dialogue Item")]
public class Dialogue : SerializedScriptableObject
{
    [HideIf("isChoice")] public Dialogue nextDialogue;
    public string dialogueName;
    public Sprite icon;
    [TextArea, HideIf("isChoice")] public string dialogueText;
    [PropertySpace]
    public bool isChoice;
    [ShowInInspector, ShowIf("isChoice")] public Dictionary<string, Dialogue> choices;
}