using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Particle_1
{
   
    public class Particle
    {
        Texture2D tex;                      
        Rectangle rect;                    
        Vector2 pos, vel;                
        Vector2 midpoint;                                              
        Vector2 scale;                      
        public double rot;                 
        Game1 parent;                      
        public bool isAlive;                
        int age;                           
        Color part_color;                       

        public Particle(Game1 g, Texture2D t, Vector2 p, Vector2 v)
        {
           
            age = 255;          
            tex = t;
            pos = p;
            parent = g;
            vel = v;
            rect = new Rectangle((int)p.X, (int)p.Y, t.Width/4, t.Height/4);
            midpoint = new Vector2(rect.Width/2, rect.Height / 2);
            rot = 0;
            scale = new Vector2(0.1f, 0.1f);
            isAlive = true;
            part_color = new Color(age,age,age,age);
          
        }

       
        public void Update()
        {
            
            age-=2;
            
           
           if(age<=255)
           {
              part_color.A = (byte)(age);
             part_color.G = (byte)(age*2);
              part_color.B = (byte)(age/2);
               part_color.R = (byte)(age*age);
            


           }
         
            if (age <= 0)
            {
                isAlive = false;
            }
           
            if (pos.Y+vel.Y >= parent.screenHeight)
            {
                vel.Y = -vel.Y/2;
            }

            vel.Y += 0.1f;
           
       
            pos += vel;

            if (vel.X <= vel.Length())
            {
                scale.X += .01f;
            }
            
              rot=Math.Atan2(vel.Y,vel.X);
        }
        public void Draw(SpriteBatch sb)
        {

        

            sb.Draw(tex, pos, null, part_color, (float)rot, midpoint, scale, SpriteEffects.None, 1.0f);
            
        }
    }
}
