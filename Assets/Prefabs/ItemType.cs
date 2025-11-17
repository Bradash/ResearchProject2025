using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ItemType", menuName = "Scriptable Objects/ItemType")]
public class ItemType : ScriptableObject
{
    public int itemID;
    public string name;
    public GameObject prefab;
    public Sprite image;
}
