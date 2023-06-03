using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item", order = 0)] 
public class Tool : ScriptableObject
{
    public float damage;
    public float cooldown;
}