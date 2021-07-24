using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FabioChess
{
	public class SharedGame : Game
	{
		private GraphicsDeviceManager _graphics;
		private SpriteBatch _spriteBatch;

		private SpriteFont font;

		public SharedGame()
		{
			_graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
		}

		protected override void Initialize()
		{
			// TODO: Add your initialization logic here

			base.Initialize();
		}

		protected override void LoadContent()
		{
			_spriteBatch = new SpriteBatch(GraphicsDevice);

			font = Content.Load<SpriteFont>("Arial");

			// TODO: use this.Content to load your game content here
		}

		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			// TODO: Add your update logic here

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.Black);

			_spriteBatch.Begin();

			Texture2D rect = new Texture2D(GraphicsDevice, 80, 30);

			Color[] data = new Color[80 * 30];
			for (int i = 0; i < data.Length; ++i)
				data[i] = Color.White;
			rect.SetData(data);

			Vector2 coor = new Vector2(10, 20);
			// _spriteBatch.Draw(rect, coor, Color.White);

			_spriteBatch.Draw(rect, coor, null, Color.White, 1, new Vector2(0, 0), new Vector2(1, 1), SpriteEffects.None, 1);

			_spriteBatch.DrawString(font, "Yay!", new Vector2(200, 200), Color.White);

			_spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
