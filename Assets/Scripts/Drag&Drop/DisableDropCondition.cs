using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Condition used to disable the drop action. Check method will always return false, regardless of the draggable
public class DisableDropCondition : DropCondition
{
	public override bool Check(DraggableComponent draggable)
	{
		return false;
	}
}
