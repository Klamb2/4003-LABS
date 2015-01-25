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
using FarseerPhysics;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Collision.Shapes;
using FarseerPhysics.Factories;

namespace GameName1
{
 //kenneth lamb
    class Circle
    {
        Texture2D sprite;
        Vector2 position;
        Body circle;
        Vector2 boxoffset;
        public Circle(Texture2D graphics, float x, float y, World world)
        {
            sprite = graphics;
            position = new Vector2(x, y);
            circle = BodyFactory.CreateCircle(world, ConvertUnits.ToSimUnits(15), 1.0f);
            circle.BodyType = BodyType.Dynamic;
            circle.Restitution = 1.0f;
            circle.Friction = 0.3f;
            circle.Position = ConvertUnits.ToSimUnits(x,y);
            boxoffset = new Vector2(sprite.Width / 2, sprite.Height / 2);
        
             
        }
          public void Draw(SpriteBatch spritebatch,Vector2 pos,float rot)

        {
              
           spritebatch.Draw(sprite, ConvertUnits.ToDisplayUnits(pos), null,Color.White,rot, boxoffset, 1.0f, SpriteEffects.None, 1.0f);

             
        }
    }
    }

