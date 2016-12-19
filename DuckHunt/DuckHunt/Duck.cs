using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;


namespace DuckHunt
{
    class Duck
    {

        Random r = new Random();
        public Vector2 position = new Vector2();
        public Vector2 velocity = new Vector2();
        public Rectangle Hitbox = new Rectangle();
        Texture2D eend;
        int timeAlive;

        public Duck(Texture2D tex)
        {
            this.eend = tex;
            Hitbox = new Rectangle((int)position.X, (int)position.Y, tex.Width, tex.Height);
            Reset();
        }


        public void Update(GameTime gametime)
        {
            position += velocity;
            //TEMP HITBOX
            Hitbox.X = (int)position.X;
            Hitbox.Y = (int)position.Y;
     
            if (timeAlive == 120)
            { Reset(); }
            timeAlive++;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(eend, position, Color.White);

        }

        public void Reset()
        {
            position.X = r.Next(0, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height);
            position.Y = r.Next(0, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width);
            velocity.X = (float)r.NextDouble() * 4 - 2;
            velocity.Y = (float)r.NextDouble() * 4 - 2;
            timeAlive = 0;

        }
    }
}
