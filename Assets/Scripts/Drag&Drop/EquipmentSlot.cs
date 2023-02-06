using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class EquipmentSlot : MonoBehaviour
{
	protected DropArea DropArea;
	protected DraggableComponent CurrentItem = null;

	private DisableDropCondition disableDropCondition;

	public bool HasItem { get; private set; } = false;
	
	protected virtual void Awake()
	{
		DropArea = GetComponent<DropArea>() ?? gameObject.AddComponent<DropArea>();
		DropArea.OnDropHandler += OnItemDropped;
		disableDropCondition = new DisableDropCondition();
	}

	public void Initialize(DraggableComponent currentItem)
	{
		if (currentItem == null)
		{
			Debug.LogError("Tried to initialize the slot with an null item!");
			return;
		}

		OnItemDropped(currentItem);
	}

	private void OnItemDropped(DraggableComponent draggable)
	{
		var draggableTransform = draggable.transform;
		draggableTransform.parent = transform;
		draggableTransform.localPosition = Vector3.zero;
		CurrentItem = draggable;
		DropArea.DropConditions.Add(disableDropCondition);
		draggable.OnBeginDragHandler += CurrentItemOnBeginDrag;
		HasItem = true;
	}

	//Current item is being dragged so we listen for the EndDrag event
	private void CurrentItemOnBeginDrag(PointerEventData eventData)
	{
		CurrentItem.OnEndDragHandler += CurrentItemEndDragHandler;
	}

	private void CurrentItemEndDragHandler(PointerEventData eventData, bool dropped)
	{
		CurrentItem.OnEndDragHandler -= CurrentItemEndDragHandler;

		if (!dropped)
		{
			return;
		}

		DropArea.DropConditions.Remove(disableDropCondition); //We dropped the component in another slot so we can remove the DisableDropCondition
		CurrentItem.OnBeginDragHandler -= CurrentItemOnBeginDrag; //We make sure to remove this listener as the item is no longer in this slot
		CurrentItem = null; //We no longer have an item in this slot, so we remove the refference
		HasItem = false;
	}
}
