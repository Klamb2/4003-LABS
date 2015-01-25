using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
// kenneth_Lamb
namespace sprite_assignment
{
  
       public class Player
        {
            #region variables
            Texture2D tex;          
            Rectangle srcRect;      
            Rectangle destRect;    
            Vector2 pos;            
            Vector2 origin;         
            Game1 parent;           
                         
            int facing;            
           
            const int LEFT = 0;
            const int RIGHT = 1;
           
            const float WALK_SPEED = 0.8f;
            const float RUN_SPEED = 4.0f;

            int frameCounter;      
            float frameRate;        
            float timeCounter;      
            #endregion
            enum anim_State { idle, walk, jump, run };
            anim_State current_state;
              
            public Player(Texture2D t, Vector2 p, Game1 g)
            {

                tex = t;
                pos = p;
                parent = g;
                current_state = anim_State.idle;
                frameCounter = 0;
                frameRate = 1.0f / 24.0f;


                origin = new Vector2(0, 0);
                srcRect = new Rectangle(0, 0, tex.Width / 24, tex.Height / 4);
                destRect = new Rectangle((int)pos.X, (int)pos.Y, 50, 50);





            }
            public void Update(GameTime gameTime)
            {
                #region keys
                bool shiftDown = Keyboard.GetState().IsKeyDown(Keys.LeftShift);
                bool aKeyDown = Keyboard.GetState().IsKeyDown(Keys.A);
                bool dKeyDown = Keyboard.GetState().IsKeyDown(Keys.D);
                bool spaceKeyDown = Keyboard.GetState().IsKeyDown(Keys.Space);
                #endregion

                #region animframe timing

                timeCounter += gameTime.ElapsedGameTime.Milliseconds / 1000.0f;

                if (timeCounter > frameRate)
                {
                    frameCounter++;
                    frameCounter = frameCounter % 24;
                    timeCounter -= frameRate;
                }
                #endregion

                #region keypressed logic
                if (aKeyDown)
                {
                    current_state = anim_State.walk;
                    facing = LEFT;
             
                    if (shiftDown) current_state = anim_State.run;
                   
                }


                if (dKeyDown)
                {
                    current_state = anim_State.walk;
                    facing = RIGHT;
                  
                    if (shiftDown) current_state = anim_State.run;
                    
                   
                }
             if (spaceKeyDown) current_state = anim_State.jump;
                
                #endregion

           
            switch(current_state)
            {
                case anim_State.idle:
                    anim_Idle();
                    break;

                case anim_State.jump :
                    anim_Jump();
                    break;

                case anim_State.run  :
                    anim_Run();
                    break;
                case anim_State.walk :
                    anim_Walk();
                    break;
                    
            }
                
                current_state = anim_State.idle;

                destRect.X = (int)pos.X;
                destRect.Y = (int)pos.Y;
            }


           public void anim_Idle()
            {
                srcRect.X = frameCounter * 50;
                srcRect.Y = 0;
            }
           public void anim_Walk()
           {
               
               srcRect.X = frameCounter * 50;
               srcRect.Y = 50;
               if(facing==LEFT)
               {
                   pos.X -= WALK_SPEED;
               }
               if(facing==RIGHT)
               {
                   pos.X += WALK_SPEED;
               }
           }
           public void anim_Jump()
           {
                   pos.Y -= .5f;
                       
                     srcRect.X = frameCounter * 50;
                     srcRect.Y = 100;
           }
           public void anim_Run()
           {
              
             

                srcRect.X = frameCounter * 50;
                srcRect.Y = 150;
                if (facing == LEFT)
                {
                    pos.X -=RUN_SPEED;
                }
                if (facing == RIGHT)
                {
                    pos.X += RUN_SPEED;
                }

           }
                  
            public void Draw(SpriteBatch sb)
            {

                if (facing == LEFT)
                    sb.Draw(tex, destRect, srcRect, Color.White, 0.0f, origin, SpriteEffects.FlipHorizontally, 1.0f);
                else
                    sb.Draw(tex, destRect, srcRect, Color.White, 0.0f, origin, SpriteEffects.None, 1.0f);
            }
        }
    }

