using UnityEngine;

public class EquipmentSlot : MonoBehaviour
{
	protected DropArea DropArea;

	protected virtual void Awake()
	{
		DropArea = GetComponent<DropArea>() ?? gameObject.AddComponent<DropArea>();
		DropArea.OnDropHandler += OnItemDropped;
	}

	private void OnItemDropped(DraggableComponent draggable)
	{
		draggable.transform.position = transform.position;
	}
}
