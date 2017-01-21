using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrbMixer
{
    public class OrbRow
    {
        private Vector2 _position;
        private Color _color;
        private List<Orb> _row;
        private List<List<Orb>> grid;
        private bool rowCompleted = false;

        List<Orb> newOrbs = new List<Orb>();
        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public OrbRow(Vector2 position, Color color, List<Orb> row)
        {
            _position = position;
            _color = color;
            _row = row;
            grid = new List<List<Orb>>();


            for (int i = 0; i < _row.Count; i++)
            {
                _row[i].Position = new Vector2((_row[i].Position.X + 150 * i) + 50, _row[i].Position.Y);
            }
        }
        public void Update(GameTime gametime)
        {
            Random random = new Random();
            int originalLength = _row.Count;
            for (int i = 0; i < originalLength; i++)
            {
                Orb temp = _row[random.Next(0, _row.Count)];
                newOrbs.Add(temp);
                _row.Remove(temp);
            }
            grid.Add(_row);
            _row = newOrbs;
            for (int i = 0; i < grid.Count; i++)
            {
                if (rowCompleted)
                {
                    foreach (Orb orb in grid[i])
                    {
                        orb.Position += new Vector2(0, 125);
                        
                    }
                }
            }
        }
        public void Draw(SpriteBatch spritebatch)
        {
            for (int j = 0; j < grid.Count; j++)
            {
                for (int i = 0; i < grid[j].Count; i++)
                {
                    grid[j][i].Draw(spritebatch);
                }
            }

        }




    }
}
