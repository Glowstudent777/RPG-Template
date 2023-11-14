using RPG.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace RPG.Screens
{
	class ScreenSplash : Screen
	{
		private Texture2D _image;
		private ManagerInput _managerInput;
		private double splashDuration = 3000;
		private double elapsedSplashTime = 0;

		public ScreenSplash(ManagerScreen managerScreen) : base(managerScreen)
		{
			_managerInput = new ManagerInput();
		}

		public override void LoadContent(ContentManager content)
		{
			_image = ManagerContent.LoadTexture("splash_screen");
		}

		public override void Initialize()
		{
		}

		public override void Uninitialize()
		{
		}

		public override void Update(double gameTime)
		{
			elapsedSplashTime += gameTime;
			_managerInput.Update(gameTime);

			if (_managerInput.KeyPressed(Keys.Space, Keys.Enter) || elapsedSplashTime >= splashDuration)
			{
				ManagerScreen.LoadNewScreen(new ScreenBlank(ManagerScreen), true);
			}
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(_image, new Rectangle(0, 0, 1280, 720), Color.White);
		}
	}
}
