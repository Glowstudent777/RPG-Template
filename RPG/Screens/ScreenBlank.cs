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
	class ScreenBlank : Screen
	{
		public ScreenBlank(ManagerScreen managerScreen) : base(managerScreen)
		{

		}

		public override void LoadContent(ContentManager content)
		{
		}

		public override void Initialize()
		{
		}

		public override void Uninitialize()
		{
		}

		public override void Update(double gameTime)
		{

		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.GraphicsDevice.Clear(Color.White);
		}
	}
}
