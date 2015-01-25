using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;
using Prim2D;

namespace flocking
{
   public class Boid
    {
        public Vector2 pos, vel;
        public float rotation;
        public static Texture2D tex;
        Rectangle rect;
        Vector2 origin;
        Game1 parent;
        Player _player;
        Vector2 avoidanceVector;
         public  Vector2 drawAvoidVect;
       public Vector2 drawPos;
       public Vector2 drawVel;
        float radius;
       
        // Basic constructor
        public Boid(Game1 g, Texture2D t, Vector2 p,Player player)
        {
            vel = new Vector2(0, 0);
            origin = new Vector2(t.Width / 2, t.Height / 2);
            parent = g;
            tex = t;
            pos = p;
            _player =player;
            radius = 25.0f;
           
          
        }

      
        public void avoidNeighbors()
        {
         avoidanceVector = new Vector2(0, 0);
            int nearNeighborCount = 0;
            foreach (Boid b in parent.boidList)
            {
               
                if (Vector2.Distance(pos, b.pos) < 50)
                {
                    nearNeighborCount++;
                    avoidanceVector += Vector2.Subtract(pos, b.pos);

                //   avoidanceVector += Vector2.Subtract(pos, b.pos) / Vector2.Distance(pos, b.pos);
                    
                    drawAvoidVect = avoidanceVector;
                }
            }
            if (nearNeighborCount > 0)
            {
               
                vel += avoidanceVector / 400;
            }
        }
         public void Update()
        {
            avoidNeighbors();
            vel += Vector2.Normalize(Vector2.Subtract(_player.pos, pos))/60.0f;


          
        
         

             
         
       
            if (vel.Length() > 2.0f){
                vel.Normalize();
                vel *= 2.0f;
            }

            drawVel = vel;
           
            if ((vel.X != 0) || (vel.Y != 0))
            {
                rotation = (float)Math.Atan2(vel.Y, vel.X);
            }
            pos += vel;
            drawPos = pos;
            
            rect.X = (int)pos.X;
            rect.Y = (int)pos.Y;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, pos, null, Color.White, rotation, origin, .5f, SpriteEffects.None, 0.0f);
            
            Prim2D.Primitives2D.DrawCircle(sb, this.pos, radius,4, Color.Green);
            foreach (Boid b in parent.boidList)
            {
                Prim2D.Primitives2D.DrawLine(sb,b.pos,b.pos-this.drawAvoidVect/2.0f,Color.PowderBlue);
               // Prim2D.Primitives2D.DrawLine(sb, pos, drawVel, Color.Red);

            }
             
        }
       
    }
}
   
