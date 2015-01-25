using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace IK
{
    class IKChain
    {
        public List<Bone> boneList; 
        Bone rootBone;             
        Bone lastBone;               
       
        Vector2 mousePos;     
        Vector2 jointToMouse;       

        Vector2 jointToEffector;   
        float jointToMouseRot, jointToEffectorRot;
        const int total_ITERATIONS = 20;

        public IKChain()
        {
            boneList = new List<Bone>();
        }
        public void AddBone(Bone bone)
        {
          
            if (rootBone == null)
            {
                rootBone = bone;
                bone.parent = null;     
            }
           
            boneList.Add(bone);
       
            lastBone = boneList[boneList.Count - 1];
    
            if (boneList.Count > 1)
            {
               
                Bone parentBone = boneList[boneList.Count - 2];
              
                lastBone.parent = parentBone;
                parentBone.child = bone;
                lastBone.jointPos = parentBone.effectorPos;
            }
            foreach (Bone b in boneList)
            {
                b.Update();
            }
        }

      
      

        public void Update()
        {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                mousePos.X = Mouse.GetState().X;
                mousePos.Y = Mouse.GetState().Y;
                int iteration = 0;

                while (Vector2.Distance(mousePos, lastBone.effectorPos) > 4)
                {
                    iteration++;
                    if (iteration > total_ITERATIONS) break;
                  
                    for (int i = boneList.Count - 1; i >= 0; i--)
                    {
                        
                        jointToMouse = (boneList[i].jointPos - mousePos);
                        jointToMouseRot = (float)Math.Atan2(jointToMouse.Y, jointToMouse.X);
                        jointToEffector = (boneList[i].jointPos - boneList[boneList.Count-1].effectorPos);
                        jointToEffectorRot = (float)Math.Atan2(jointToEffector.Y, jointToEffector.X);

                      
                        boneList[i].rot += (jointToMouseRot - jointToEffectorRot);

                       
                        foreach (Bone b in boneList)
                        {
                            b.Update();
                        }
                        
                    }
                }
            }
        }

        public void Draw(SpriteBatch sb)
        {
            // Tell each bone to draw itself
            foreach (Bone b in boneList)
            {
                b.Draw(sb);
            }
        }
    }
}

