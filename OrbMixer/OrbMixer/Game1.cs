using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace OrbMixer
{
    
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        List<Orb> row;
        Orb blueOrb;
        Orb greenOrb;
        Orb purpleOrb;
        Orb redOrb;
        Orb yellowOrb;
        OrbGraph testRow;
        KeyboardState ks;
        MouseState ms;
        SpriteFont font;
        Vector2 mousePos;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1200;
            graphics.PreferredBackBufferHeight = 1000;
            IsMouseVisible = true;
        }

        
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            row = new List<Orb>();
            ks = new KeyboardState();
            ms = new MouseState();

            font = Content.Load<SpriteFont>("spritefont");
            blueOrb = new Orb(Content.Load<Texture2D>("BlueOrb"), new Vector2(0, 0), Color.White);
            greenOrb = new Orb(Content.Load<Texture2D>("GreenOrb"), new Vector2(0, 0), Color.White);
            purpleOrb = new Orb(Content.Load<Texture2D>("PurpleOrb"), new Vector2(0, 0), Color.White);
            redOrb = new Orb(Content.Load<Texture2D>("RedOrb"), new Vector2(0, 0), Color.White);
            yellowOrb = new Orb(Content.Load<Texture2D>("YellowOrb"), new Vector2(0, 0), Color.White);
            testRow = new OrbGraph(Content);
            row.Add(blueOrb);
            row.Add(greenOrb);
            row.Add(purpleOrb);
            row.Add(redOrb);
            row.Add(yellowOrb);

            
            

            // TODO: use this.Content to load your game content here
        }


        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            ms = Mouse.GetState();
            ks = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            mousePos = new Vector2(ms.X, ms.Y);
            testRow.Update(gameTime, ks, ms);

            base.Update(gameTime);
        }

        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            testRow.Draw(spriteBatch);
            spriteBatch.DrawString(font, string.Format("mouse position:{0, 1} ", mousePos), new Vector2(0, 0), Color.White);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
