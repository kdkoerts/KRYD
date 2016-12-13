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
            Reset();
        }


        public void Update(GameTime gametime)
        {
            position += velocity;
            //TEMP HITBOX
            Hitbox = new Rectangle((int)position.X, (int)position.Y,48,48);
     
            if (timeAlive == 1200)
            { Reset(); }
            timeAlive++;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(eend, position, Color.White);

        }

        public void Reset()
        {
            //position.X = r.Next(0, 640);
            // position.Y = r.Next(0, 480);
            // velocity.X = (float)r.NextDouble() * 4 - 2;
            // velocity.Y = (float)r.NextDouble() * 4 - 2;
            position.X = 200;
            position.Y = 200;
            velocity.X = 0;
            velocity.Y = 0;
            timeAlive = 0;
        }
    }
}
