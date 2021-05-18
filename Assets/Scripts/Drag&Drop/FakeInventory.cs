using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class purpose is only to initialize the EquipmentSlot objects from the inventory (in a very ugly way :)) ) Do not use this class as a template for your inventory
public class FakeInventory : MonoBehaviour
{
	[SerializeField] private Transform inventoryItemsContainer;

	private void Start()
	{
		InitializeItems();
	}

	private void InitializeItems()
	{
		var slots = inventoryItemsContainer.GetComponentsInChildren<EquipmentSlot>();
		foreach (var slot in slots)
		{
			var item = slot.GetComponentInChildren<DraggableComponent>();
			if (item != null)
			{
				slot.Initialize(item);
			}
		}
	}
}
