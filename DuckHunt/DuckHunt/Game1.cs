using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace DuckHunt
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D eendSprite;
        Texture2D boomSprite;
        Duck duck;
        List<Tree> treeList = new List<Tree>();
        Random r = new Random();

        //Temp score var en spritefont
        Vector2 MousePos = new Vector2();
        int score = 0;
        SpriteFont font;

        public Game1()
        {
            
            graphics = new GraphicsDeviceManager(this);
            //graphics.IsFullScreen = true;
            graphics.PreferredBackBufferHeight = 1080;
            graphics.PreferredBackBufferWidth = 1920;
            Content.RootDirectory = "Content";

        }

        static void Main()
        {
            Game1 game = new Game1();
            game.Run();
        }

        protected void Mouseshooter()
        {
            MouseState mouse = Mouse.GetState();
         
            if(mouse.LeftButton == ButtonState.Pressed)
            {
                //WTF MUIS PLS?
                MousePos = new Vector2(mouse.X+60, mouse.Y+70);
                if(duck.Hitbox.Contains(MousePos))
                {
                    duck.Reset();
                    score += 100;
                }
            }
        }


       
        protected override void Initialize()
        {
            base.Initialize();

            //TEMP MUIS
            this.IsMouseVisible = true;

            for (int i = 0; i < 10; i++)
            {
                treeList.Add(new Tree(r.Next(20, 1900), r.Next(720, 1080), 0, boomSprite));
               
            }

            duck = new Duck(eendSprite);

        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            eendSprite = Content.Load<Texture2D>("ZwarteEend");
            boomSprite = Content.Load<Texture2D>("tree");
            //TEMP LOAD
            font = Content.Load<SpriteFont>("Spelfont");
        }

        
        protected override void UnloadContent()
        {


        }

       
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            Mouseshooter();
            duck.Update(gameTime);
            base.Update(gameTime);

        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            duck.Draw(spriteBatch);


            //TEMP draw voor score
            spriteBatch.DrawString(font, score.ToString(), new Vector2(40, 20), Color.Black);

            foreach (Tree t in treeList)
            {
                t.Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
