using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrbMixer
{
    public class OrbGraph
    {
        private Vector2 _position;
        private Color _color;

        private Orb[,] _orbMatrix;
        private bool rowCompleted = false;
        private List<Orb> _orbList = new List<Orb>();
        Orb blueOrb;
        Orb greenOrb;
        Orb purpleOrb;
        Orb redOrb;
        Orb yellowOrb;
        KeyboardState ks;

        List<Orb> newOrbs = new List<Orb>();
        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }




        public OrbGraph(ContentManager Content)
        {
            Random random = new Random();
            //MAKE THIS NOT ACCEPT ANY PARAMETERS, YOU HAVE EVERYTHING YOU WILL NEED IN YOUR ORBGRAPH CLASS
            blueOrb = new Orb(Content.Load<Texture2D>("BlueOrb"), new Vector2(0, 0), Color.White);
            greenOrb = new Orb(Content.Load<Texture2D>("GreenOrb"), new Vector2(0, 0), Color.White);
            purpleOrb = new Orb(Content.Load<Texture2D>("PurpleOrb"), new Vector2(0, 0), Color.White);
            redOrb = new Orb(Content.Load<Texture2D>("RedOrb"), new Vector2(0, 0), Color.White);
            yellowOrb = new Orb(Content.Load<Texture2D>("YellowOrb"), new Vector2(0, 0), Color.White);
            _orbList.Add(blueOrb);
            _orbList.Add(greenOrb);
            _orbList.Add(purpleOrb);
            _orbList.Add(redOrb);
            _orbList.Add(yellowOrb);
            _orbMatrix = new Orb[10, 10];
            _orbMatrix[0, 1] = _orbList[random.Next(0,4)];
            
        }
        public void Update(GameTime gametime, KeyboardState keyboard)
        {
            ks = keyboard;
            
        }
        public void Draw(SpriteBatch spritebatch)
        {
            

        }




    }
}
