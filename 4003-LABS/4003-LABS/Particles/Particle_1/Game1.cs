#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;

using MonoGameContentProcessors.Content;
using MonoGameContentProcessors.Processors;
using Microsoft.Xna.Framework.Content.Pipeline;









#endregion

namespace Particle_1
{
   
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D partTex;

        Vector2 textPos;
        Vector2 partPos;                   
        Vector2 partVel;                  
        Particle tempParticle;             

        List<Particle> partiList;           
        Random generator;
        SpriteFont font;  
                       
      
        public int screenWidth, screenHeight;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = true;     
            Content.RootDirectory = "Content";
        }

      
        protected override void LoadContent()
        {
           
            spriteBatch = new SpriteBatch(GraphicsDevice);

            textPos = new Vector2(10, 10);
            // Load the font from the Content folder
         //   font = Content.Load<SpriteFont>("SpriteFont1");
        
            partTex = Content.Load<Texture2D>("fire_particle");
         
            partiList = new List<Particle>();
            
            generator = new Random();
         
            this.IsMouseVisible = true;
          
            screenWidth = graphics.GraphicsDevice.Viewport.Width;
            screenHeight = graphics.GraphicsDevice.Viewport.Height;

        }

        protected override void Update(GameTime gameTime)
        {
           if ((GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed) ||
                (Keyboard.GetState().IsKeyDown(Keys.Escape)))
                this.Exit();

            
            int mouseX = Mouse.GetState().X;
            int mouseY = Mouse.GetState().Y;

           
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                for (int i = 0; i < 10; i++)
                {
                   
                    double rot = generator.NextDouble() * Math.PI * 2.0;
                 
                    partPos = new Vector2(mouseX, mouseY);
                 
                    partVel = new Vector2((float)(Math.Cos(rot) * 6.0), (float)(Math.Sin(rot) * 4.0 - 2.0));
                  
                    tempParticle = new Particle(this, partTex, partPos, partVel);
                 
                    partiList.Add(tempParticle);
                }
            }

           
            foreach (Particle p in partiList)
            {
                p.Update();
            }

           
            for (int i = partiList.Count - 1; i >= 0; i--)
            {
                Particle temp = partiList[i];
                if (!temp.isAlive)
                {
                    partiList.Remove(temp);
                }
            }
            base.Update(gameTime);
        }

      
        protected override void Draw(GameTime gameTime)
        {
          
            GraphicsDevice.Clear(Color.Black);
         
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.Additive);
            //spriteBatch.DrawString(font, "R:" + partiList.Count, textPos, Color.White);
            foreach (Particle p in partiList)
            {
                p.Draw(spriteBatch);
            }
        
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
