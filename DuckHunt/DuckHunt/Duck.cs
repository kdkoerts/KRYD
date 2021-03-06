﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;


namespace DuckHunt
{
    class Duck
    {

        Random r = new Random();
        Vector2 position = new Vector2();
        Vector2 velocity = new Vector2();
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
            if (timeAlive == 120)
            { Reset(); }
            timeAlive++;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(eend, position, Color.White);

        }

        private void Reset()
        {
            position.X = r.Next(0, 640);
            position.Y = r.Next(0, 480);
            velocity.X = (float)r.NextDouble() * 4 - 2;
            velocity.Y = (float)r.NextDouble() * 4 - 2;
            timeAlive = 0;
        }
    }
}
