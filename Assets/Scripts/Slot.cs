using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MyGameNamespace;

public class Slot : MonoBehaviour
{
    [SerializeField]
    private InventoryController inventory;
    public int i;
    public TextMeshProUGUI amountText;
    public int amount;

    void Start()
    {
        inventory = FindObjectOfType<InventoryController>();
    }

    // if the item quantity is greater than 1, show the amountText
    void Update()
    {
        if(amount > 1)
        {
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
            
        }

        // if the item quantity less than 1, hide the amountText
        else{
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        }

        // update the item quantity in the UI
        amountText.text = amount.ToString();


        // check if the slot has exactly two child objects then mark the slot as not full in the inventory controller
        if(transform.childCount == 2)
        {
            inventory.isFull[i] = false;
        }
    }

    // If the item is stacked, reduce its quantity, create a new dropped item instance, and decrease the stack count.
    public void DropItem()
    {
        if (amount > 1)
        {
            amount -= 1;
            transform.GetComponentInChildren<Spawn>().SpawnDroppedItem();
        }

        // if the item is not stacked, decrease the quantity and destory the item's representation.
        else
        {
            amount -= 1;
            GameObject.Destroy(transform.GetComponentInChildren<Spawn>().gameObject);
            transform.GetComponentInChildren<Spawn>().SpawnDroppedItem();
            // gameObject.SetActive(false);
        }
    }
}
