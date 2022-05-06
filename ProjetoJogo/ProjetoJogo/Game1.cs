using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ProjetoJogo
{
    public class JogoProjeto : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private SpriteFont textFont;
        private Vector2 textPos;
        private const string TextMsg = "Welcome To My Game";
        private const int ScreenW = 1600, ScreenH = 900;
        private Texture2D bg;
        private Rectangle bgRect;

        private Texture2D playerText;
        private Rectangle playerRect;
        private KeyboardState kb;
        private const int speed = 5;
        public JogoProjeto()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferWidth = ScreenW;
            graphics.PreferredBackBufferHeight = ScreenH;
            graphics.ApplyChanges();

            Window.AllowUserResizing = false;
            Window.AllowAltF4 = true;
            Window.Title = "Jogo Projeto";
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

                bg = Content.Load<Texture2D>("Textures/Map");
            bgRect = new Rectangle(0, 0, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height);
            
            textFont = Content.Load<SpriteFont>("Fonts/TextFont");
            textPos = new Vector2(0,10);

            playerText = Content.Load<Texture2D>("Sprites/Player");
            playerRect = new Rectangle(500, 500, playerText.Width / 2, playerText.Height / 2);
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            kb = Keyboard.GetState();
            if (kb.IsKeyDown(Keys.W))
                playerRect.Y -= speed;
            else if (kb.IsKeyDown(Keys.S))
                playerRect.Y += speed;

            if (kb.IsKeyDown(Keys.D))
                playerRect.X += speed;
            else if (kb.IsKeyDown(Keys.A))
                playerRect.X -= speed;

            textPos.X += speed;
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DeepPink);
            spriteBatch.Begin();
            spriteBatch.Draw(bg, bgRect, Color.White);
            spriteBatch.DrawString(textFont, TextMsg, textPos, Color.Black);


            spriteBatch.Draw(playerText, playerRect, Color.White);
            spriteBatch.End();
   

            base.Draw(gameTime);
        }
    }
}
