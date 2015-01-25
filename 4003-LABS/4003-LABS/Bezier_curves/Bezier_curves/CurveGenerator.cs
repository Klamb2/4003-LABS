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

   
    class CurveGenerator
    {
        List<ControlPoint> controlPoints;
        List<Vector2> dotPoints;

        private const int SEGMENT_COUNT = 100;
        private const int SEGMENTS_PER_CURVE = 10;
        private const float MINIMUM_SQR_DISTANCE = 0.01f;
        private const float DIVISION_THRESHOLD = -0.99f;
        float t;
        Vector2 p0, p1, p2, p3;
        private int curveCount;
        Texture2D pointTex;
        Texture2D dotTex;
        Game1 g;
        public CurveGenerator(Game1 game,Texture2D pTex,Texture2D dTex,Vector2 pos1,Vector2 pos2,Vector2 pos3,Vector2 pos4)
        {
            pointTex = pTex;
            dotTex = dTex;
            g = game;
             controlPoints  = new List<ControlPoint>();
             dotPoints = new List<Vector2>();
             p0 = pos1;
             p1 = pos2;
             p2 = pos3;
             p3 = pos4;

            controlPoints.Add(new ControlPoint(game, pointTex, p0));
            controlPoints.Add(new ControlPoint(game, pointTex, p1));
            controlPoints.Add(new ControlPoint(game, pointTex, p2));
            controlPoints.Add(new ControlPoint(game, pointTex, p3));

         
        

        }
     
     private Vector2 CalculateBezierPoint(float t, Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3)
    {
         float u = (1-t);
         float tt = t*t;
        float uu = u*u;
        float uuu = uu * u;
        float ttt = tt * t;
 
        Vector2 p = uuu * p0; //first term
        p += 3 * uu * t * p1; //second term
        p += 3 * u * tt * p2; //third term
        p += ttt * p3; //fourth term
 
      return p;
    }
     public void Update(MouseState mouse)
     {
         foreach (ControlPoint p in controlPoints)
         {
             p.Update(mouse);
             
         }
         p0 = controlPoints[0].Position;
         p1 = controlPoints[1].Position;
         p2 = controlPoints[2].Position;
         p3 = controlPoints[3].Position;
        
         
         if (dotPoints.Count() > 100)
         {
             dotPoints.Clear();
         }
         

     }

     public void Draw(SpriteBatch sb)
     {
         foreach (ControlPoint p in controlPoints)
         {
             p.Draw(sb);
         }
        
         for (int i = 0; i <= SEGMENT_COUNT; i++)
         {
            
             t = i / (float)SEGMENT_COUNT;
             Vector2 pixel = CalculateBezierPoint(t, p0, p1, p2, p3);
             dotPoints.Add(new Vector2(pixel.X,pixel.Y));
            

        

         }
         
         foreach (Vector2 v in dotPoints)
         {
             sb.Draw(dotTex, new Rectangle((int)v.X, (int)v.Y, (int)dotTex.Width, (int)dotTex.Height), Color.White);
         }
     
     }
   
    
 



   
     
} 
      
    }

