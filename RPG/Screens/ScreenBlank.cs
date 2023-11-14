using RPG.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

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
			spriteBatch.GraphicsDevice.Clear(Color.Blue);
		}
	}
}
