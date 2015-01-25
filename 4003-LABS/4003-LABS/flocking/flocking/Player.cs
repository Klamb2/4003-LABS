using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace flocking
{
   public class Player
    {
       public Vector2 pos;
       public Vector2 center;
        Vector2 vel;
        Texture2D tex;
        Game1 parent;
       public Rectangle rect;
       float angle;
        public Player(Texture2D t,Vector2 p,Vector2 v, Game1 g){
            pos = p;
            vel = v;
            tex = t;
            parent = g;
            rect = new Rectangle((int)p.X, (int)p.Y, t.Width/2 , t.Height/2);
            center = new Vector2( tex.Width / 2,tex.Height / 2);
         
            
        }

        public void Update()
        {
           
            bool aKeyDown = Keyboard.GetState().IsKeyDown(Keys.A);
            bool dKeyDown = Keyboard.GetState().IsKeyDown(Keys.D);
            bool wKeyDown = Keyboard.GetState().IsKeyDown(Keys.W);
            bool sKeyDown = Keyboard.GetState().IsKeyDown(Keys.S);

            if (aKeyDown)
            {
                pos.X -= vel.X;
            }
            if (dKeyDown)
            {
                pos.X += vel.X;
            }

            if (wKeyDown)
            {
                pos.Y -= vel.Y;
            }
            if (sKeyDown)
            {
                pos.Y+= vel.Y;
            }
         
        }

        public void Draw(SpriteBatch sb)
        {
          //  sb.Draw(tex, pos, Color.White);
           // sb.Draw(tex, pos, null, Color.White,angle center, SpriteEffects.None, 0.0f);
            sb.Draw(tex,pos,null,Color.White,angle,center,1.0f,SpriteEffects.None,0.0f);
        }
        public Vector2 Pos
        {
            get { return pos; }
            set { Pos = value; }
        }
    }
}
