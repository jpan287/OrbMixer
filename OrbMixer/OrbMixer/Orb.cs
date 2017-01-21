using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrbMixer
{
    public class Orb : Sprite
    {
        public Texture2D Texture
        {
            get { return _texture; }
        }
        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public Orb(Texture2D texture, Vector2 position, Color color)
            :base(texture, position, color)
        {

        }
        public Orb(Texture2D texture, Vector2 position, Color color, Rectangle sourceRectangle)
            :base(texture, position, color)
        {

        }
        public override void Draw(SpriteBatch spritebatch)
        {
            base.Draw(spritebatch);
        }
    }
}
