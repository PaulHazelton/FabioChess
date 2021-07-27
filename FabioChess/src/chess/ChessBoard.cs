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
		private Color lightcolor = new Color (240, 217, 166);
		private Color darkcolor = new Color (181,136,99); 
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
				spriteBatch.Draw(lightRectangle, new Vector2(i*(width/8)*2+x, y+(height/8)*j), null, Color.White, 0, new Vector2(0, 0), new Vector2(width/8, height/8), SpriteEffects.None, 0);
				spriteBatch.Draw(darkRectangle, new Vector2(i*(width/8)*2+x+(width/8), y+(height/8)*j), null, Color.White, 0, new Vector2(0, 0), new Vector2(width/8, height/8), SpriteEffects.None, 0);

			}}

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