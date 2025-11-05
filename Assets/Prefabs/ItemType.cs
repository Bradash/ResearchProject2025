using UnityEngine;

[CreateAssetMenu(fileName = "ItemType", menuName = "Scriptable Objects/ItemType")]
public class ItemType : ScriptableObject
{
    public string name;
    public itemTypeEnum itemType;
    public float itemAmount;
public enum itemTypeEnum
{
    None,
    Melee,
    Guns,
    Ammo,
}
}
