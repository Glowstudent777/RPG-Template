namespace RPG
{
	public enum ComponentType
	{
		Sprite,
		PlayerInput,
		Animation,
		Collision,
		AIMovement,
		EnemyOctorok,
		Camera,
		Equipment,
		GUI,
		Damage,
		Stats,
		DeathAnimation,
		Script,
		StatusEffects,
		EventTriggerDistance,
		BlockPush
	}
	public enum Input
	{
		Left,
		Right,
		Up,
		Down,
		None,
		Enter,
		A,
		S,
		Select,
		Start
	}
	public enum State
	{
		Standing,
		Walking,
		Special,
		Pushing
	}
	public enum Direction
	{
		Left,
		Right,
		Up,
		Down
	}
	public enum GameEventType
	{
		Message,
		EventSwitch
	}
}