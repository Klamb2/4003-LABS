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
// kenneth lamb
    class Floor
    {
        Texture2D sprite;
        Body floor;
        Rectangle floorRect;
        public Floor(Texture2D graphics,World world)
        {
            sprite = graphics;
            floor = BodyFactory.CreateRectangle(world, ConvertUnits.ToSimUnits(490), ConvertUnits.ToSimUnits(60), 10.0f);
            floor.Position = ConvertUnits.ToSimUnits(400, 450);
            floor.IsStatic = true;
            floor.Restitution = 0.5f;
            floor.Friction = 0.2f;
            floorRect = new Rectangle(170, 425, 480, 50);
           
        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(sprite,floorRect, Color.White);
        }
    }
}
