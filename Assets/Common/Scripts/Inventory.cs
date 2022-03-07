using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //everything we can have
    [SerializeField] Item[] items;
    //what we currently have
    List<Item> inventory = new List<Item>();
    public Item activeItem { get; set; }

    void Start()
    {
        inventory.AddRange(items);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) ActivateItem(null);
        if (Input.GetKeyDown(KeyCode.Alpha2)) ActivateItem(inventory[0]);
        if (Input.GetKeyDown(KeyCode.Alpha3)) ActivateItem(inventory[1]);

        activeItem?.UpdateItem();
    }

    void ActivateItem(Item item)
    {
        //deactivate original item
        activeItem?.Deactivate();
        //set the new item
        activeItem = item;
        //activate the new item
        activeItem?.Activate();
    }

    public void StartItem()
    {
        if (activeItem is Weapon weapon)
        {
            weapon.Fire();
        }
    }
}
