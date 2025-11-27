using UnityEngine;

public class PickupManager : MonoBehaviour
{
    public GameObject[] pickups;
    public Inventory inventory;
    public void checkInv()
    {
        //for every pickup
        for (int s = 0; s < pickups.Length; s++)
        {
            //search the scriptableObject in the gameObject
            var pickupItem = pickups[s].GetComponent<InventoryItem>();
            //for every item in inventory
            for (int i = 0; i < inventory.inventoryItems.Length; i++)
            {
                //if a pickup is the same as an item in the inventory, destroy it.
                if (inventory.inventoryItems[i] == pickupItem)
                {
                    Destroy(pickups[s]);
                }
            }
        }
    }
}
