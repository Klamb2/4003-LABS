#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using FarseerPhysics;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Collision.Shapes;
using FarseerPhysics.Factories;

#endregion

namespace GameName1

//kenneth lamb
{
   
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        World world;
        Vector2 boxOffset;
        Floor fl;
        Circle cl;
      //  List<Sqaure> sqaures = new List<Sqaure>();
      //  List<Circle> circles = new List<Circle>();
        Peg[] peg_arr;
        Texture2D boxTex, circleTex, floorTex, background;
        float timer = 0.0f;
        float limit = 1.0f;
        Random generator;
       

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
           

        }

       
        protected override void Initialize()
        {
            base.Initialize();
            world = new World(new Vector2(0.0f, 9.82f));
            fl = new Floor(floorTex, world);
            generator = new Random();
            peg_arr = new Peg[21];
            CreateSqaure();

        }

       
        protected override void LoadContent()
        {
            // all art besides "red_circle" from http://www.opengameart.org/users/kenney
            spriteBatch = new SpriteBatch(GraphicsDevice);
            boxTex = Content.Load<Texture2D>("red_circle");
            boxOffset = new Vector2(boxTex.Width / 2, boxTex.Height / 2);
            circleTex = Content.Load<Texture2D>("alienPink_badge1.png");
            floorTex = Content.Load<Texture2D>("slice03_03.png");
            background = Content.Load<Texture2D>("blue_grass.png");
        
            
        }

        public void CreateCircle()
        {
            float ran = (float)generator.NextDouble()*800;
            cl = new Circle(circleTex, ran, 0, world);
          
        }
        public void CreateSqaure()
        {
           // float sq_x;

           // float sq_y;
           
            peg_arr[0] = new Peg(boxTex, 350.0f, 100.0f, world, boxOffset);
            peg_arr[1] = new Peg(boxTex, 350.0f, 200.0f, world, boxOffset);
            peg_arr[2] = new Peg(boxTex, 350.0f, 300.0f, world, boxOffset);

            peg_arr[3] = new Peg(boxTex, 250.0f, 100.0f, world, boxOffset);
            peg_arr[4] = new Peg(boxTex, 250.0f, 200.0f, world, boxOffset);   
            peg_arr[5] = new Peg(boxTex, 250.0f, 300.0f, world, boxOffset);

            peg_arr[6] = new Peg(boxTex, 450.0f, 100.0f, world, boxOffset);
            peg_arr[7] = new Peg(boxTex, 450.0f, 200.0f, world, boxOffset);
            peg_arr[8] = new Peg(boxTex, 450.0f, 300.0f, world, boxOffset);

            peg_arr[9] = new Peg(boxTex, 300.0f, 150.0f, world, boxOffset);
            peg_arr[10] = new Peg(boxTex,300.0f, 250.0f, world, boxOffset);

            peg_arr[11] = new Peg(boxTex, 400f, 250f, world, boxOffset);
            peg_arr[12] = new Peg(boxTex, 400f, 150f, world, boxOffset);

            peg_arr[13] = new Peg(boxTex, 550f, 100f, world, boxOffset);
            peg_arr[14] = new Peg(boxTex, 550f, 200f, world, boxOffset);
            peg_arr[15] = new Peg(boxTex, 550f, 300f, world, boxOffset);
            peg_arr[16] = new Peg(boxTex, 500f, 250f, world, boxOffset);

            peg_arr[17] = new Peg(boxTex, 500f, 250f, world, boxOffset);
            peg_arr[18] = new Peg(boxTex,500f,150f,world,boxOffset);

            peg_arr[19] = new Peg(boxTex, 200, 250f, world, boxOffset);
            peg_arr[20] = new Peg(boxTex, 200, 150f, world, boxOffset);
          
      

          
          

        }
        public void DrawSqaure(SpriteBatch sb)
        {
            for (int i = 0; i<peg_arr.Length; i++)
            {
                peg_arr[i].Draw(sb);
            }
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            world.Step((float)gameTime.ElapsedGameTime.TotalMilliseconds * 0.001f);

            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds * 0.001f;
            if (timer > limit)
            {
                timer -= limit;
                if (limit > 0.05f)
                {
                    limit -= 0.05f;
                }
                CreateCircle();

            
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            spriteBatch.Draw(background, new Vector2(-225,-225), Color.White);
            fl.Draw(spriteBatch);
   
            DrawSqaure(spriteBatch);
            foreach (Body b in world.BodyList)
            {
             
                if (!b.IsStatic)
                {
                    
                  
                   cl.Draw(spriteBatch,b.Position,b.Rotation);
                }
                if (ConvertUnits.ToDisplayUnits(b.Position).Y > 500)
                {
                    world.RemoveBody(b);
                }
            }
            
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
