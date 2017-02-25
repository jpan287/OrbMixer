using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrbMixer
{
    public class Sprite
    {
        protected Texture2D _texture;
        protected Vector2 _position;
        protected Color _color;
        public Texture2D Texture
        {
            get { return _texture; }
        }
        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }
        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }


        public Sprite(Texture2D texture, Vector2 position, Color color)
        {
            _texture = texture;
            _position = position;
            _color = color;
        }
        public virtual void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(_texture, _position, _color);
        }
    }
}
