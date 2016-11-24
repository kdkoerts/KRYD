using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
        Duck duck3;
        Duck duck;

        public Game1()
        {
            
            graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
        }

        static void Main()
        {
            Game1 game = new Game1();
            game.Run();
        }


       
        protected override void Initialize()
        {
            
            base.Initialize();
            duck = new Duck(eendSprite);
        }

        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            eendSprite = Content.Load<Texture2D>("ZwarteEend");
        }

        
        protected override void UnloadContent()
        {


        }

       
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            duck.Update(gameTime);

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            duck.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
