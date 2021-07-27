using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FabioChess
{
	public class ChessBoard : DrawableGameComponent
	{
		private int width, height, x, y;
		private Texture2D whiteRectangle;
		private SpriteBatch spriteBatch;

		public ChessBoard(Game game) : base(game)
		{
			this.UpdateSize();
		}

		public override void Initialize()
		{
			spriteBatch = new SpriteBatch(GraphicsDevice);

			// Make rectangles
			whiteRectangle = new Texture2D(GraphicsDevice, 1, 1);
			Color[] data = new Color[1];
			for (int i = 0; i < data.Length; ++i)
				data[i] = Color.White;
			whiteRectangle.SetData(data);

			base.Initialize();
		}

		public override void Update(GameTime gameTime)
		{

		}

		public override void Draw(GameTime gameTime)
		{
			spriteBatch.Begin();

			spriteBatch.Draw(whiteRectangle, new Vector2(x, y), null, Color.White, 0, new Vector2(0, 0), new Vector2(width, height), SpriteEffects.None, 0);

			spriteBatch.End();
		}

		public void UpdateSize()
		{
			int screenWidth = Game.Window.ClientBounds.Width;
			int screenHeight = Game.Window.ClientBounds.Height;

			width = screenHeight < screenWidth ? screenHeight : screenWidth;

			height = width;
			width -= 20;
			height -= 20;

			x = (screenWidth - width) / 2;
			y = (screenHeight - height) / 2;
		}
	}
}