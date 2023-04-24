using UnityEngine;

[CreateAssetMenu(menuName = "New Dialogue", fileName = "New Dialogue Item")]
public class Dialogue : ScriptableObject
{
    public Dialogue nextDialogue;
    public string id;
    public string dialogueName;
    public Sprite icon;
    [TextArea] public string dialogueText;
}