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
        MouseState ms;
        Orb randOrb;
        Orb selected;
        bool toggle;
        bool use;

        Random random = new Random();

        List<Orb> newOrbs = new List<Orb>();
        List<Orb> destroyedOrbs = new List<Orb>();
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
            for (int i = 0; i < _orbMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < _orbMatrix.GetLength(1); j++)
                {
                    int tempRand = random.Next(0, 5);
                    randOrb = _orbList[tempRand];
                    _orbMatrix[i, j] = new Orb(randOrb);
                    _orbMatrix[i, j].colors = (OrbColor)tempRand;
                }
            }
        }
        public void Update(GameTime gametime, KeyboardState keyboard, MouseState mouseState)
        {
            ks = keyboard;
            ms = mouseState;
            Vector2 mousePos = new Vector2(ms.X, ms.Y);
            for (int x = 0; x < _orbMatrix.GetLength(0); x++)
            {
                for (int y = 0; y < _orbMatrix.GetLength(1); y++)
                {
                    int tempRand = random.Next(0, 5);
                    Orb temp = randOrb;
                    setPosition(_orbMatrix);
                    if (_orbMatrix[x, y].HitBox.Contains(new Point((int)mousePos.X, (int)mousePos.Y)) && ms.LeftButton == ButtonState.Pressed)
                    {
                        ToggleSelection(_orbMatrix[x, y]);
                        if (toggle == true && _orbMatrix[x, y].HitBox.Contains(new Point((int)mousePos.X, (int)mousePos.Y)) && ms.LeftButton == ButtonState.Pressed)
                        {
                            if (x - 1 > 0 && _orbMatrix[x, y].colors == _orbMatrix[x - 1, y].colors)
                            {
                                randOrb = _orbList[tempRand];
                                _orbMatrix[x - 1, y] = new Orb(temp);
                                _orbMatrix[x - 1, y].colors = (OrbColor)tempRand;
                            }
                            if (x + 1 < 10 && _orbMatrix[x, y].colors == _orbMatrix[x + 1, y].colors)
                            {
                                randOrb = _orbList[tempRand];
                                _orbMatrix[x + 1, y] = new Orb(temp);
                                _orbMatrix[x + 1, y].colors = (OrbColor)tempRand;
                            }
                            if (y - 1 > 0 && _orbMatrix[x, y].colors == _orbMatrix[x, y - 1].colors)
                            {
                                randOrb = _orbList[tempRand];
                                _orbMatrix[x, y - 1] = new Orb(temp);
                                _orbMatrix[x, y - 1].colors = (OrbColor)tempRand;
                            }
                            if (y + 1 < 10 && _orbMatrix[x, y].colors == _orbMatrix[x, y + 1].colors)
                            {
                                randOrb = _orbList[tempRand];
                                _orbMatrix[x, y + 1] = new Orb(temp);
                                _orbMatrix[x, y + 1].colors = (OrbColor)tempRand;
                            }
                        }
                    }
                }
            }

        }
        public void Draw(SpriteBatch spritebatch)
        {
            for (int i = 0; i < _orbMatrix.GetUpperBound(0); i++)
            {
                for (int j = 0; j < _orbMatrix.GetUpperBound(1); j++)
                {
                    spritebatch.Draw(_orbMatrix[i, j].Texture, _orbMatrix[i, j].Position, Color.White);
                }
            }
        }


        public void ToggleSelection(Orb selectedOrb)
        {
            if (selected != null && selected == selectedOrb)
            {
                selected.Color = Color.White;
                selected = null;
                toggle = false;
            }
            else
            {
                selected = selectedOrb;
                selected.Color = Color.Black;
                toggle = true;
            }
            if (toggle == true)
            {
                use = true;
            }
            else
            {
                use = false;
            }
            //highlight the selected orb somehow with a different texture or something,
            //make this toggleable
        }

        public void setPosition(Orb[,] orbMatrix)//accepts a grid value
        {
            Vector2[,] orbPosition;
            orbPosition = new Vector2[10, 10];
            for (int i = 0; i < orbPosition.GetLength(0); i++)
            {
                for (int j = 0; j < orbPosition.GetLength(1); j++)
                {
                    var swag = orbMatrix[i, j];
                    orbPosition[i, j] = new Vector2(i, j) * 110;
                    swag.Position = orbPosition[i, j];
                    swag.HitBox = new Rectangle((int)swag.Position.X, (int)swag.Position.Y, swag.Texture.Width, swag.Texture.Height);
                }
            }

            //sets position on the screen based on grid value
            //swag
        }



    }
}
