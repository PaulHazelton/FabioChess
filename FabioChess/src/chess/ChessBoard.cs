using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FabioChess
{
	public class ChessBoard : DrawableGameComponent
	{
		private int width, height, x, y;
		private Texture2D lightRectangle;
		private Texture2D darkRectangle;
		private SpriteBatch spriteBatch;
		private Color lightcolor = new Color(240, 217, 166);
		private Color darkcolor = new Color(181, 136, 99);

		private Texture2D pawn;

		public ChessBoard(Game game) : base(game)
		{
			this.UpdateSize();
		}

		public override void Initialize()
		{
			spriteBatch = new SpriteBatch(GraphicsDevice);

			// Make rectangles
			lightRectangle = new Texture2D(GraphicsDevice, 1, 1);
			Color[] data = new Color[1];
			for (int i = 0; i < data.Length; ++i)
				data[i] = lightcolor;
			lightRectangle.SetData(data);
			darkRectangle = new Texture2D(GraphicsDevice, 1, 1);
			for (int i = 0; i < data.Length; ++i)
				data[i] = darkcolor;
			darkRectangle.SetData(data);

			// Load pieces
			pawn = this.Game.Content.Load<Texture2D>("pd");

			base.Initialize();
		}

		public override void Update(GameTime gameTime)
		{

		}

		public override void Draw(GameTime gameTime)
		{
			spriteBatch.Begin();
			for (int j = 0; j < 8; j++)
			{
				for (int i = 0; i < 4; i++)
				{
					if (j % 2 == 0)
					{
						evenrow(i, j);
					}
					else
					{
						oddrow(i, j);
					}
				}
			}

			Draw2(pawn, new Vector2(x, y), new Vector2((float)width/(64*8),(float)height/(64*8)));

			spriteBatch.End();
		}
		private void evenrow(int i, int j)
		{
			// spriteBatch.Draw(lightRectangle, new Vector2(i * (width / 8) * 2 + x, y + (height / 8) * j), null, Color.White, 0, new Vector2(0, 0), new Vector2(width / 8, height / 8), SpriteEffects.None, 0);
			Draw2(lightRectangle,new Vector2(i * (width / 8) * 2 + x, y + (height / 8) * j), new Vector2(width / 8, height / 8));
			// spriteBatch.Draw(darkRectangle, new Vector2(i * (width / 8) * 2 + x + (width / 8), y + (height / 8) * j), null, Color.White, 0, new Vector2(0, 0), new Vector2(width / 8, height / 8), SpriteEffects.None, 0);
			Draw2(darkRectangle, new Vector2(i * (width / 8) * 2 + x + (width / 8), y + (height / 8) * j), new Vector2(width / 8, height / 8));
		}
		private void oddrow(int i, int j)
		{
			spriteBatch.Draw(lightRectangle, new Vector2(i * (width / 8) * 2 + x + (width / 8), y + (height / 8) * j), null, Color.White, 0, new Vector2(0, 0), new Vector2(width / 8, height / 8), SpriteEffects.None, 0);
			spriteBatch.Draw(darkRectangle, new Vector2(i * (width / 8) * 2 + x, y + (height / 8) * j), null, Color.White, 0, new Vector2(0, 0), new Vector2(width / 8, height / 8), SpriteEffects.None, 0);
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
		private void Draw2 (Texture2D texture, Vector2 position, Vector2 scale)
		{
			spriteBatch.Draw (texture, position, null, Color.White, 0, new Vector2(0, 0), scale, SpriteEffects.None, 0);	
		}
	}
}