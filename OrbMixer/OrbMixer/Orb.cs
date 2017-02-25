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
        //DONT USE PARTNER ENUM, MAKE A LIST OF ORBS TO DESTROY INSIDE OF THE ORBGRAPH CLASS
        private Rectangle hitBox;
        private Vector2 orbPos;
        private bool isSelected;
        public OrbColor colors;
        public bool IsSelected
        {
            get { return isSelected; }
            set { isSelected = value; }
        }

        public Vector2 OrbPos
        {
            get { return orbPos; }
            set { orbPos = value; }
        }
        public Rectangle HitBox
        {
            get { return hitBox; }
            set { hitBox = value; }
        }


        public Orb(Orb toCopy) : base(toCopy._texture, toCopy._position, toCopy._color)
        {
            hitBox = new Rectangle((int)toCopy._position.X, (int)toCopy._position.Y, toCopy._texture.Width, toCopy._texture.Height);
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
