using Godot;
using System;

public partial class AsteroidsBody : CharacterBody2D
{
	
	[Export]
	public int Speed { get; set; } = 400;

	[Export]
	public float RotationSpeed { get; set; } = 1.5f;

	private float _rotationDirection;

	public void GetInput()
	{
		_rotationDirection = Input.GetAxis("left", "right");
		Velocity = Transform.X * Input.GetAxis("up", "down") * Speed;
	}

	public override void _PhysicsProcess(double delta)
	{
		GetInput();
		Rotation += _rotationDirection * RotationSpeed * (float)delta;
		MoveAndSlide();
	}
}
