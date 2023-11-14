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
		private Vector2 position = new Vector2(500, 300);
		private int speed = 1;
		private Direction direction = Direction.Down;
		private bool isMoving = false;
		private KeyboardState kStateOld = Keyboard.GetState();
		public bool dead = false;

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
				direction = Direction.Right;
				isMoving = true;
			}

			if (kState.IsKeyDown(Keys.Left))
			{
				direction = Direction.Left;
				isMoving = true;
			}

			if (kState.IsKeyDown(Keys.Up))
			{
				direction = Direction.Up;
				isMoving = true;
			}

			if (kState.IsKeyDown(Keys.Down))
			{
				direction = Direction.Down;
				isMoving = true;
			}

			if (kState.IsKeyDown(Keys.Space))
				isMoving = false;

			if (dead)
				isMoving = false;

			if (isMoving)
			{
				switch (direction)
				{
					case Direction.Right:
						if (position.X < 1275)
							position.X += speed * dt;
						break;
					case Direction.Left:
						if (position.X > 225)
							position.X -= speed * dt;
						break;
					case Direction.Down:
						if (position.Y < 1250)
							position.Y += speed * dt;
						break;
					case Direction.Up:
						if (position.Y > 200)
							position.Y -= speed * dt;
						break;
				}
			}

			anim = animations[(int)direction];

			anim.Position = new Vector2(position.X - 48, position.Y - 48);

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