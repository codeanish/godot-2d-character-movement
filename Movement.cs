using Godot;
using System;

public partial class Movement : CharacterBody2D
{
	[Export]
	public const float Speed = 300.0f;
	
	public void GetInput()
	{
		Vector2 inputDirection = Input.GetVector("left", "right", "up", "down");
		Console.WriteLine(inputDirection);
		Velocity = inputDirection * Speed;
	}

	public override void _PhysicsProcess(double delta)
	{
		GetInput();
		MoveAndSlide();
	}
}
