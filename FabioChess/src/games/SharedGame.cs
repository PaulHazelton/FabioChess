﻿using Microsoft.Xna.Framework;
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

			graphics.PreparingDeviceSettings += Graphics_PreparingDeviceSettings;

			Content.RootDirectory = "Content";
			IsMouseVisible = true;
		}

		private void Graphics_PreparingDeviceSettings(object sender, PreparingDeviceSettingsEventArgs e)
		{
			graphics.PreferMultiSampling = true;
			e.GraphicsDeviceInformation.PresentationParameters.MultiSampleCount = 8;
		}

		protected override void Initialize()
		{
			// TODO: Add your initialization logic here
			Window.AllowUserResizing = true;

			ChessBoard chessBoard = new ChessBoard(this);

			this.Components.Add(chessBoard);

			Window.ClientSizeChanged += (sender, e) => chessBoard.UpdateSize();

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

			// spriteBatch.DrawString(font, "Yay!", new Vector2(200, 200), Color.Red);

			spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
