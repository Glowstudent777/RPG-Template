using RPG.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using RPG.Components;

namespace RPG.Screens
{
	class ScreenBlank : Screen
	{
		Texture2D walkDown;
		Texture2D walkUp;
		Texture2D walkRight;
		Texture2D walkLeft;

		Player player = new Player();

		public ScreenBlank(ManagerScreen managerScreen) : base(managerScreen)
		{

		}

		public override void LoadContent(ContentManager content)
		{
			walkDown = ManagerContent.LoadTexture("walkDown");
			walkRight = ManagerContent.LoadTexture("walkRight");
			walkLeft = ManagerContent.LoadTexture("walkLeft");
			walkUp = ManagerContent.LoadTexture("walkUp");

			player.animations[0] = new SpriteAnimation(walkDown, 4, 8);
			player.animations[1] = new SpriteAnimation(walkUp, 4, 8);
			player.animations[2] = new SpriteAnimation(walkLeft, 4, 8);
			player.animations[3] = new SpriteAnimation(walkRight, 4, 8);

			player.anim = player.animations[0];
		}

		public override void Initialize()
		{
		}

		public override void Uninitialize()
		{
		}

		public override void Update(double gameTime)
		{
			player.Update(gameTime);
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.GraphicsDevice.Clear(Color.Blue);
			if (!player.dead)
				player.anim.Draw(spriteBatch);
		}
	}
}
