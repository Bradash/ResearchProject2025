using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ItemType", menuName = "Scriptable Objects/ItemType")]
public class ItemType : ScriptableObject
{
    public string name;
    public GameObject prefab;
    public Sprite image;
}
