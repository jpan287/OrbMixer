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

        private Orb[,] _orbMatrix;
        private List<Orb> _orbList = new List<Orb>();
        Orb blueOrb;
        Orb greenOrb;
        Orb purpleOrb;
        Orb redOrb;
        Orb yellowOrb;
        KeyboardState ks;
        Orb selectedOrb;

        Random random = new Random();

        List<Orb> newOrbs = new List<Orb>();
        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }




        public OrbGraph(ContentManager Content)
        {
            
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
            for (int i = 0; i < _orbMatrix.GetUpperBound(0); i++)
            {
                for (int j = 0; j < _orbMatrix.GetUpperBound(1); j++)
                {
                    int tempRand = random.Next(0, 5);
                    selectedOrb = _orbList[tempRand];
                    _orbMatrix[i, j] = new Orb(selectedOrb);
                    _orbMatrix[i, j].Position = new Vector2(i, j) * 110;
                    _orbMatrix[i, j].colors = (OrbColor)tempRand;
                }
            }
        }
        public void Update(GameTime gametime, KeyboardState keyboard)
        {
            ks = keyboard;
            for (int i = 0; i < _orbMatrix.GetUpperBound(0); i++)
            {
                for (int j = 0; j < _orbMatrix.GetUpperBound(1); j++)
                {
                    int tempRand = random.Next(0, 5);
                    _orbMatrix[i, j].OrbPos = new Vector2(i,j);
                    if (_orbMatrix[i, j].colors == _orbMatrix[i, j].colors)
                    {
                        _orbMatrix[i, j] = selectedOrb;
                    }
                }
            }
            
        }
        public void Draw(SpriteBatch spritebatch)
        {
            for (int i = 0; i < _orbMatrix.GetUpperBound(0); i++)
            {
                for (int j = 0; j < _orbMatrix.GetUpperBound(1); j++)
                    spritebatch.Draw(_orbMatrix[i, j].Texture, _orbMatrix[i, j].Position, Color.White);
            }
        }

    }
}
