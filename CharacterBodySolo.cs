using Godot;
using System;

public partial class CharacterBodySolo : CharacterBody2D
{
	[Export]
	public int Speed { get; set; } = 400;

	private int _currentSpeed = 0;
	
	[Export]
	public float RotationSpeed { get; set; } = 1.5f;

	private float _rotationDirection;

	public void GetInput()
	{
		_rotationDirection = Input.GetAxis("left", "right");
		if (Input.IsActionPressed("accelerate"))
		{
			_currentSpeed = Math.Min(Speed, _currentSpeed + 5);
		}
		else
		{
			_currentSpeed = Math.Max(0, _currentSpeed - 20);
		}
		Velocity = Transform.X * _currentSpeed;
	}


	public override void _PhysicsProcess(double delta)
	{
		GetInput();
		Rotation += _rotationDirection * RotationSpeed * (float)delta;
		MoveAndSlide();
	}
}
