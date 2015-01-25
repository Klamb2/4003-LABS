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

namespace Bezier_curves
{
    class ControlPoint
    {
        Texture2D tex;
        Vector2 pos;
        Rectangle rect;
         MouseState preMouse;
        bool moving = false;
     Vector2 mouseOffset;
        public ControlPoint(Game1 g,Texture2D t,Vector2 p)
        {
            tex = t;
            pos = p;
            rect = new Rectangle((int)p.X, (int)p.Y, t.Width, t.Height);
       
            
        }
        public void Update( MouseState mouse)
        {
            MouseInput(mouse);
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, rect, Color.White);
        }
        public void MouseInput(MouseState mouse)
        {
            if (rect.Contains(mouse.X, mouse.Y) && 
       
        mouse.LeftButton == ButtonState.Pressed && 
       
        preMouse.LeftButton == ButtonState.Released)
    {
        moving = true;

       
        mouseOffset = new Vector2(pos.X - mouse.X, pos.Y - mouse.Y);
    }

    if (moving)
    {
       
        if (mouse.LeftButton == ButtonState.Released)  
            moving = false;

      
        pos.X = mouse.X + mouseOffset.X;
        pos.Y = mouse.Y + mouseOffset.Y;

     
       rect = new Rectangle((int)pos.X, (int)pos.Y,(int) tex.Width,(int) tex.Height);
    }

    preMouse = mouse; 
}
        public Vector2 Position
        {
            get { return pos; }
            set { Position = pos; }
        }
        }

      
    }

