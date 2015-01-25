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
    class Peg
    {
        Texture2D sprite;
        Vector2 position;
        Body square;
        Vector2 boxoffset;
        public Peg(Texture2D graphics, float x, float y, World world, Vector2 bxoff)
        {
            sprite = graphics;
            position = new Vector2(x, y);
            square = BodyFactory.CreateCircle(world, ConvertUnits.ToSimUnits(11.5), 1.0f); 
          //  square = BodyFactory.CreateRectangle(world, ConvertUnits.ToSimUnits(sprite.Width), ConvertUnits.ToSimUnits(sprite.Height), 1.0f);
            square.BodyType = BodyType.Static;
            square.Restitution = 0.5f;
            square.Friction = 0.3f;
            square.Position = ConvertUnits.ToSimUnits(x, y);
            boxoffset = bxoff;

        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(sprite, ConvertUnits.ToDisplayUnits(square.Position), null, Color.White, square.Rotation, boxoffset, 1.0f, SpriteEffects.None, 1.0f);


        }
    }
}
