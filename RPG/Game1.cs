using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RPG.Screens;
using RPG.Managers;

namespace RPG
{
	public class Game1 : Game
	{
		private GraphicsDeviceManager _graphics;
		private SpriteBatch _spriteBatch;

		private ManagerInput _managerInput;
		private ManagerScreen _managerScreen;

		public Game1()
		{
			_graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = true;

			_managerInput = new ManagerInput();
		}

		protected override void Initialize()
		{
			_graphics.PreferredBackBufferWidth = 1280;
			_graphics.PreferredBackBufferHeight = 720;
			_graphics.ApplyChanges();

			base.Initialize();
		}

		protected override void LoadContent()
		{
			ManagerContent.Initialize(Content);
			_spriteBatch = new SpriteBatch(GraphicsDevice);
			_managerScreen = new ManagerScreen(Content);
			_managerScreen.LoadNewScreen(new ScreenSplash(_managerScreen), true);
		}

		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			_managerInput.Update(gameTime.ElapsedGameTime.Milliseconds);
			_managerScreen.Update(gameTime.ElapsedGameTime.Milliseconds);

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.Black);

			_spriteBatch.Begin();
			_managerScreen.Draw(_spriteBatch);
			_spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}