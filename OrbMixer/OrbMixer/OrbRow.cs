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

        public OrbRow(Vector2 position, Color color, List<Orb> row)
        {
            _position = position;
            _color = color;
            _row = row;
            for(int i = 0; i < _row.Count; i++)
            {
                _row[i].Position = new Vector2(_row[i].Position.X + 125, _row[i].Position.Y);
            }
        }
        public void Draw(SpriteBatch spritebatch)
        {
            for(int i = 0; i < _row.Count; i++)
            {
                _row[i].Draw(spritebatch);
            }
        }
    }
}
