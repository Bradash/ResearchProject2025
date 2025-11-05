using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public item[] items;

    [System.Serializable]
    public class item
    {
        public string name;
        public ItemType itemType;
        public float itemAmount;
    }
    public enum ItemType
    {
        None,
        Melee,
        Guns,
        Ammo,
    }
}
