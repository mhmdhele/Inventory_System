using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameNamespace;

public class Pickup : MonoBehaviour
{
    [SerializeField]
    private InventoryController inventory;
    public GameObject itemButton;
    public string itemName;

    public GameManager manager;

        void Start()
    {
        inventory = FindObjectOfType<InventoryController>();
    }

   // If the player entered the zone, this code iterates through inventory slots to stack matching items if conditions are met.
    private void OnTriggerEnter(Collider other)
    {
     
        if(other.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if(inventory.isFull[i] == true && inventory.slots[i].transform.GetComponent<Slot>().amount < 5)
                {
                    if(itemName == inventory.slots[i].transform.GetComponentInChildren<Spawn>().itemName)
                    {
                        Destroy(gameObject);
                        inventory.slots[i].GetComponent<Slot>().amount += 1;
                        break;
                    }
                }

                // If the slot is not full, this code marks the slot as full, instantiates an itemButton, 
                // increases the item count in the inventory slot, destroys the current object, and exits the loop.
                else if(inventory.isFull[i] == false)
                {
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    inventory.slots[i].GetComponent<Slot>().amount += 1;
                    Destroy(gameObject);
                    break;
                }
            }

        }
    }
}
