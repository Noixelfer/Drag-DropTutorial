public class IsWeaponCondition : DropCondition
{
	public override bool Check(DraggableComponent draggable)
	{
		return draggable.GetComponent<Weapon>() != null;
	}
}
