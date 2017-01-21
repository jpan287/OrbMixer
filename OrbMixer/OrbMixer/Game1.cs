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
        OrbRow testRow;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1800;
            graphics.PreferredBackBufferHeight = 900;
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

            blueOrb = new Orb(Content.Load<Texture2D>("BlueOrb"), new Vector2(0, 0), Color.White);
            greenOrb = new Orb(Content.Load<Texture2D>("GreenOrb"), new Vector2(0, 0), Color.White);
            purpleOrb = new Orb(Content.Load<Texture2D>("PurpleOrb"), new Vector2(0, 0), Color.White);
            redOrb = new Orb(Content.Load<Texture2D>("RedOrb"), new Vector2(0, 0), Color.White);
            yellowOrb = new Orb(Content.Load<Texture2D>("YellowOrb"), new Vector2(0, 0), Color.White);
            row.Add(blueOrb);
            row.Add(greenOrb);
            row.Add(purpleOrb);
            row.Add(redOrb);
            row.Add(yellowOrb);

            testRow = new OrbRow(new Vector2(0, 0), Color.White, row);

            // TODO: use this.Content to load your game content here
        }


        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            testRow.Draw(spriteBatch);


            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
