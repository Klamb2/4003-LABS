using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace IK
{
    class Bone
    {   
        Game1 g;
        Texture2D boneTex, effectTex;
       
       public Bone parent;
       public Bone child;

       public Rectangle rect;
       public Vector2 effectorPos;
       public Vector2 jointPos;
       public  Vector2 offset, endPos;
       public float rot, length;

       
        
        public Bone(Game1 game,Texture2D bTex,Vector2 p,Texture2D eTex)
        {
            parent = null;
            child = null;
            jointPos = p;
            boneTex = bTex;
            effectTex = eTex;
            g = game;      

            rect = new Rectangle((int)p.X, (int)p.Y,boneTex.Width,boneTex.Height);
            offset = new Vector2(( boneTex.Width/6), (boneTex.Height/2) );
            endPos = new Vector2(boneTex.Width,boneTex.Height/2);

            effectorPos = new Vector2(0,0);
            length = Vector2.Distance(offset, endPos);
           
        
           

        }

        public void Update()
        {



            if (parent != null)
            {
                jointPos = parent.effectorPos;
            }
            
         
           effectorPos.X = jointPos.X + (float)Math.Cos(rot) * length;
           effectorPos.Y = jointPos.Y + (float)Math.Sin(rot) * length;

           
        }

        public void Draw(SpriteBatch sb)
        {

          sb.Draw(boneTex, jointPos, null,Color.White, rot, offset,1.0f, SpriteEffects.None, 1.0f);
    
          sb.Draw(effectTex,effectorPos,Color.White);

           //sb.Draw(effectTex, jointPos, null, Color.RoyalBlue);

        }
    
     
       
    
    }
}
