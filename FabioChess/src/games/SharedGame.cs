using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FabioChess
{
	public class SharedGame : Game
	{
		private GraphicsDeviceManager graphics;
		private SpriteBatch spriteBatch;

		private SpriteFont font;

		public SharedGame()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
		}

		protected override void Initialize()
		{
			// TODO: Add your initialization logic here
			Window.AllowUserResizing = true;

			this.Components.Add(new ChessBoard(this));

			base.Initialize();
		}

		protected override void LoadContent()
		{
			spriteBatch = new SpriteBatch(GraphicsDevice);

			font = Content.Load<SpriteFont>("Arial");

			// TODO: use this.Content to load your game content here
		}

		protected override void Update(GameTime gameTime)
		{
			if (Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			// TODO: Add your update logic here

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.Black);

			spriteBatch.Begin();

			int w = GraphicsDevice.Viewport.Width / 2;
			int h = GraphicsDevice.Viewport.Height / 2;
			Texture2D rect = new Texture2D(GraphicsDevice, w, h);

			Color[] data = new Color[w * h];
			for (int i = 0; i < data.Length; ++i)
				data[i] = new Color((i * 255) / (w * h), 0, 0);
			rect.SetData(data);

			Vector2 position = new Vector2(10, 10);

			spriteBatch.Draw(rect, position, null, Color.White, 0, new Vector2(0, 0), new Vector2(1, 1), SpriteEffects.None, 1);

			spriteBatch.DrawString(font, "Yay!", new Vector2(200, 200), Color.Red);

			spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
