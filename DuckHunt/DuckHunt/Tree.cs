using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuckHunt
{
    class Tree : SpriteGameObject
    {
        Texture2D TreeSpr;
        Vector2 scaling;

        public Tree(int posX, int posY, int posZ, Texture2D tex)
        {
            TreeSpr = tex;
            drawOffset.X = -TreeSpr.Width / 2;
            drawOffset.Y = -TreeSpr.Height;
            position.X = posX;
            position.Y = posY;


            

            Depth();
            scaling.X = depth / 100;
            scaling.Y = depth / 100;

        }

        public override void LoadContent()
        {

        }

        public override void Update()
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
            spriteBatch.Draw(TreeSpr, position + drawOffset, null, null, null, 0, scaling, Color.White, SpriteEffects.None, 0);
        }
    }
}
