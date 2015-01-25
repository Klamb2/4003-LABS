using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using Prim2D;
// kenneth lamb
namespace flocking
{
    
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player player;
  
        public List<Boid> boidList;
        Texture2D playerTex;
        Texture2D enemyTex;
        Texture2D midpointTex;
       public Vector2 boidsMidpoint;
       public float screenWidth;
       public float screenHeight;

        public Game1(): base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

       
        protected override void Initialize()
        {
            screenWidth = GraphicsDevice.Viewport.Width;
            screenHeight = GraphicsDevice.Viewport.Height;

            base.Initialize();
        }

      
        protected override void LoadContent()
        {
           
            boidList = new List<Boid>();
            spriteBatch = new SpriteBatch(GraphicsDevice);

          playerTex = Content.Load<Texture2D>("hero");
      

         enemyTex = Content.Load<Texture2D>("boid");
     
        
            player = new Player(playerTex,new Vector2(screenWidth/2,screenHeight/2) ,new Vector2(2.0f,2.0f),this);


            midpointTex = Content.Load<Texture2D>("midpoint");
            Random generator = new Random();
            boidsMidpoint = new Vector2(0, 0);

           
         
         
            for (int i = 0; i < 15; i++)
            {
                Vector2 tempPos = new Vector2((float)generator.NextDouble() * screenWidth,
                                             (float)generator.NextDouble() * screenHeight);
                Boid tempBoid = new Boid(this,enemyTex, tempPos,player);
                boidList.Add(tempBoid);
            }
             
        }


        
        
        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            player.Update();
           
            foreach (Boid e in boidList)
            {
                e.Update();
               
            }

            boidsMidpoint.X = boidsMidpoint.Y = 0.0f;
            foreach (Boid e in boidList)
            {
                boidsMidpoint += e.pos;
            }
            boidsMidpoint /= boidList.Count;
            base.Update(gameTime);
        }

        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            player.Draw(spriteBatch);

            foreach (Boid e in boidList){
            
                e.Draw(spriteBatch);
            }

            spriteBatch.Draw(midpointTex, boidsMidpoint, Color.White);
            /*
            foreach(Boid b in boidList){
              //  Vector2 bVel = new Vector2(0, 0);
                
               
            Prim2D.Primitives2D.DrawLine(spriteBatch,b.pos,b.drawPos+b.drawVel*25.0f,Color.Red);

            }
            */
            spriteBatch.End();

          
            base.Draw(gameTime);
        }
     
}
        
    }

