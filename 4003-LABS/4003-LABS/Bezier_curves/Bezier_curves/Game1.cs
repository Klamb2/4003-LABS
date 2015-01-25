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

namespace Bezier_curves
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;
      //  Vector2 FontPos;
        Texture2D control;
        Texture2D dot;


        Vector2 position;
        Vector2 position2, position3, position4;
        
        public Rectangle collisionRectangle;
       
        CurveGenerator gen;

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
            font = Content.Load<SpriteFont>("myFont");
            control = Content.Load<Texture2D>("control");
            dot = Content.Load<Texture2D>("dot");
            this.IsMouseVisible = true;
          
            position = new Vector2(40,400);
            position2= new Vector2(200,100);
            position3 = new Vector2(400,400);
            position4 = new Vector2(576, 60);
          
         gen = new CurveGenerator(this, control,dot,position,position2,position3,position4);

        }


        protected override void UnloadContent()
        {


        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

           
            int mouseX = Mouse.GetState().X;
            int mouseY = Mouse.GetState().Y;
          
            gen.Update(Mouse.GetState());

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();


            spriteBatch.DrawString(font, "Score", new Vector2(100, 100), Color.White);
          
            gen.Draw(spriteBatch);
           

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
       
}

