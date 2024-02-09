using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RPG.Components
{
	class Player
	{
		private Vector2 position = Vector2.Zero;
		private Vector2 direction = Vector2.Zero;
		private Direction LookDirection = Direction.Down;
		private int speed = 15;
		private bool isMoving = false;
		private KeyboardState kStateOld = Keyboard.GetState();
		public bool dead = false;
		private bool EnableDiagonalMovement = false;

		public SpriteAnimation anim;

		public SpriteAnimation[] animations = new SpriteAnimation[4];

		public Vector2 Position
		{
			get
			{
				return position;
			}
		}

		public void setX(float newX)
		{
			position.X = newX;
		}

		public void setY(float newY)
		{
			position.Y = newY;
		}

		public void Update(double gameTime)
		{
			KeyboardState kState = Keyboard.GetState();
			float dt = (float)gameTime;

			isMoving = false;

			if (kState.IsKeyDown(Keys.Right))
			{
				LookDirection = Direction.Right;
				if (EnableDiagonalMovement) direction += new Vector2(speed * dt, 0);
				else direction = new Vector2(speed * dt, 0);
				isMoving = true;
			}

			if (kState.IsKeyDown(Keys.Left))
			{
				LookDirection = Direction.Left;
				if (EnableDiagonalMovement) direction -= new Vector2((speed * dt), 0);
				else direction = new Vector2(-(speed * dt), 0);
				isMoving = true;
			}

			if (kState.IsKeyDown(Keys.Up))
			{
				LookDirection = Direction.Up;
				if (EnableDiagonalMovement) direction -= new Vector2(0, (speed * dt));
				else direction = new Vector2(0, -(speed * dt));
				isMoving = true;
			}

			if (kState.IsKeyDown(Keys.Down))
			{
				LookDirection = Direction.Down;
				if (EnableDiagonalMovement) direction += new Vector2(0, (speed * dt));
				else direction = new Vector2(0, (speed * dt));
				isMoving = true;
			}

			if (kState.IsKeyDown(Keys.Space))
				isMoving = false;
			if (dead)
				isMoving = false;

			if (isMoving)
			{
				direction.Normalize();
				position += direction;

				anim = animations[(int)LookDirection];
				anim.Position = position;
			}

			if (kState.IsKeyDown(Keys.Space))
				anim.setFrame(0);
			else if (isMoving)
				anim.Update(gameTime);
			else
				anim.setFrame(1);

			kStateOld = kState;
		}
	}
}