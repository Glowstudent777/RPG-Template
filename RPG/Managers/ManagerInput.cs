using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace RPG.Managers
{
	public class ManagerInput
	{
		private KeyboardState currentKeyState, prevKeyState;
		private double _counter;
		private static double _cooldown;
		private static double _pauseCounter;
		private static bool _pause;
		private static double _pauseTime;

		public static bool ThrottleInput { get; set; }
		public static bool LockMovement { get; set; }

		public ManagerInput()
		{
			ThrottleInput = false;
			LockMovement = false;
			_counter = 0;
		}

		public void Update(double gameTime)
		{
			if (_pause)
			{
				_pauseCounter += gameTime;
				if (_pauseCounter > _pauseTime)
				{
					_pause = false;
				}
				else
				{
					return;
				}
			}

			if (_cooldown > 0)
			{
				_counter += gameTime;
				if (_counter > gameTime)
				{
					_cooldown = 0;
					_counter = 0;
				}
				else
					return;
			}

			prevKeyState = currentKeyState;
			currentKeyState = Keyboard.GetState();
		}

		public bool KeyPressed(params Keys[] keys)
		{
			foreach (Keys key in keys)
			{
				if (currentKeyState.IsKeyDown(key) && prevKeyState.IsKeyUp(key))
					return true;
			}
			return false;
		}

		public bool KeyReleased(params Keys[] keys)
		{
			foreach (Keys key in keys)
			{
				if (currentKeyState.IsKeyUp(key) && prevKeyState.IsKeyDown(key))
					return true;
			}
			return false;
		}

		public bool KeyDown(params Keys[] keys)
		{
			foreach (Keys key in keys)
			{
				if (currentKeyState.IsKeyDown(key))
					return true;
			}
			return false;
		}

		public static void PauseInput(double milisecond)
		{
			_pauseCounter = 0;
			_pauseTime = milisecond;
			_pause = true;
		}
	}
}