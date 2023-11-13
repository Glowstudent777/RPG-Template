using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPG.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using RPG.Screens;
using RPG;

namespace RPG.Screens
{
	class ScreenSplash : Screen
	{

		private Texture2D _image;

		public ScreenSplash(ManagerScreen managerScreen) : base(managerScreen)
		{

		}

		public override void LoadContent(ContentManager content)
		{
			_image = ManagerContent.LoadTexture("splash_screen");
		}

		public override void Initialize()
		{
			ManagerInput.FireNewInput += ManagerInput_FireNewInput;
		}

		public override void Uninitialize()
		{
			ManagerInput.FireNewInput -= ManagerInput_FireNewInput;
		}

		void ManagerInput_FireNewInput(object sender, NewInputEventArgs e)
		{
			if (e.Input == Input.Enter)
			{
				ManagerScreen.LoadNewScreen(new ScreenBlank(ManagerScreen));
			}
		}

		public override void Update(double gameTime)
		{

		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(_image, new Rectangle(0, 0, 1280, 720), Color.White);
		}
	}
}
