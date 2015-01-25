#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion
//kenneth_Lamb
namespace sprite_assignment
{
   
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
      
        SpriteBatch spriteBatch;
        Texture2D sprite_sheet;

        public int screen_Width, screen_Height;
        Player player;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

       
        protected override void Initialize()
        {
         
            base.Initialize();
        }

        
        protected override void LoadContent()
        {
           
            spriteBatch = new SpriteBatch(GraphicsDevice);

            spriteBatch = new SpriteBatch(GraphicsDevice);
            sprite_sheet = Content.Load<Texture2D>("spritesheet_small");


            screen_Width = graphics.GraphicsDevice.Viewport.Width;
            screen_Height = graphics.GraphicsDevice.Viewport.Height;


            Vector2 initialPlayerPos = new Vector2(screen_Width / 2, screen_Height - 50);
            player = new Player(sprite_sheet, initialPlayerPos, this);
        }


        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            player.Update(gameTime);

            base.Update(gameTime);
        }

      
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            player.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
