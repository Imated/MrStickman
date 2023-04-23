using UnityEngine;

[CreateAssetMenu(menuName = "New Achievement", fileName = "New Achievement")]
public class Achievement : ScriptableObject
{
    public string title;
    [TextArea] public string description;
    public Sprite icon;
}
