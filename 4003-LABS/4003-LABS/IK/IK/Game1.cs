using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace IK
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
   //kenneth lamb
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D boneTex;
        Texture2D effectorTex;
        Bone bone1, bone2;
        private IKChain ikChain, ikChain2, ikChain3;
        float screenWidth;
        float screenHeight;
        private Vector2 startPos;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
           // graphics.IsFullScreen = true;
         

        }

       
        protected override void Initialize()
        {
            screenWidth = GraphicsDevice.Viewport.Width;
            screenHeight = GraphicsDevice.Viewport.Height;
          
            base.Initialize();
        }


        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);

            boneTex = Content.Load<Texture2D>("arm");
            this.IsMouseVisible = true;
            effectorTex = Content.Load<Texture2D>("effector");
          
            ikChain = new IKChain();
            ikChain2 = new IKChain();
            ikChain3 = new IKChain();
            
            

            #region IKChain1
                
            startPos = new Vector2(screenWidth/2, 400);
           // bone1 = new Bone(this,boneTex,startPos,effectorTex);
           // bone2  = new Bone(this, boneTex, startPos, effectorTex);

            ikChain.AddBone(new Bone(this,boneTex,startPos,effectorTex));
            ikChain.AddBone(new Bone(this, boneTex, startPos, effectorTex));
            ikChain.AddBone(new Bone(this, boneTex, startPos, effectorTex)); 
            ikChain.AddBone(new Bone(this, boneTex, startPos, effectorTex));
          
          
          
           
#endregion

            #region IkChain2
            startPos = new Vector2(screenWidth/2,50);
            
            ikChain2.AddBone(new Bone(this, boneTex, startPos, effectorTex));
            ikChain2.AddBone(new Bone(this, boneTex, startPos, effectorTex));
          
            #endregion

            #region IkChain3
            startPos =  new Vector2(50,screenHeight/2);

            ikChain3.AddBone(new Bone(this, boneTex, startPos, effectorTex));

            ikChain3.AddBone(new Bone(this, boneTex, startPos, effectorTex));

            ikChain3.AddBone(new Bone(this, boneTex, startPos, effectorTex));

            #endregion

        }
      

     
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

        
           // ikChain.Update(Mouse.GetState());
            ikChain.Update();
            ikChain2.Update();
            ikChain3.Update();
           // bone1.Update(Mouse.GetState());

            base.Update(gameTime);
        }

       
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

           // spriteBatch.Begin();
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
           // bone1.Draw(spriteBatch);
            ikChain.Draw(spriteBatch);
            ikChain2.Draw(spriteBatch);
            ikChain3.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
