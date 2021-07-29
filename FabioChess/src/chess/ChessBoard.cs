using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FabioChess
{
	public class ChessBoard
	{
		public Game Game { get; }
		private int width, height, x, y, pieceWidth, pieceHeight;
		public SpriteBatch SpriteBatch { private get; set; }
		private Texture2D lightRectangle;
		private Texture2D darkRectangle;
		private Color lightcolor = new Color(240, 217, 166);
		private Color darkcolor = new Color(181, 136, 99);

		private const int pieceSize = 800;
		private Texture2D pawn;

		public ChessBoard(Game game)
		{
			this.Game = game;
			this.UpdateSize();
		}

		public void LoadContent(GraphicsDevice graphicsDevice)
		{
			// Make rectangles
			lightRectangle = new Texture2D(graphicsDevice, 1, 1);
			Color[] data = new Color[1];
			for (int i = 0; i < data.Length; ++i)
				data[i] = lightcolor;
			lightRectangle.SetData(data);
			darkRectangle = new Texture2D(graphicsDevice, 1, 1);
			for (int i = 0; i < data.Length; ++i)
				data[i] = darkcolor;
			darkRectangle.SetData(data);

			// Load pieces
			pawn = this.Game.Content.Load<Texture2D>("nl");
		}

		public void Update(GameTime gameTime)
		{

		}

		public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			for (int j = 0; j < 8; j++)
			{
				for (int i = 0; i < 4; i++)
				{
					if (j % 2 == 0)
						evenrow(i, j);
					else
						oddrow(i, j);
				}
			}

			Draw2(pawn, new Vector2(x, y), new Vector2((float)width / (pieceSize * 8.0f), (float)height / (pieceSize * 8.0f)));
		}
		private void evenrow(int i, int j)
		{
			Draw2(lightRectangle,
				new Vector2(i * (pieceWidth) * 2 + x, y + (pieceHeight) * j),
				new Vector2(pieceWidth, pieceHeight));
			Draw2(darkRectangle,
				new Vector2(i * (pieceWidth) * 2 + x + (pieceWidth), y + (pieceHeight) * j),
				new Vector2(pieceWidth, pieceHeight));
		}
		private void oddrow(int i, int j)
		{
			Draw2(lightRectangle,
				new Vector2(i * (pieceWidth) * 2 + x + (pieceWidth), y + (pieceHeight) * j),
				new Vector2(pieceWidth, pieceHeight));
			Draw2(darkRectangle,
				new Vector2(i * (pieceWidth) * 2 + x, y + (pieceHeight) * j),
				new Vector2(pieceWidth, pieceHeight));
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

			pieceWidth = width / 8;
			pieceHeight = height / 8;
		}
		private void Draw2(Texture2D texture, Vector2 position, Vector2 scale)
		{
			SpriteBatch.Draw(texture, position, null, Color.White, 0, new Vector2(0, 0), scale, SpriteEffects.None, 0);
		}
	}
}