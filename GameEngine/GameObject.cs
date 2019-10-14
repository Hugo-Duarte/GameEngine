using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace GameEngine
{
    public class GameObject
    {
        protected Texture2D image;
        public Vector2 position;
        public Color drawColor = Color.White;
        public float scale = 1f, rotation = 0f;
        public float layerDepth = .5f;
        public bool active = true;
        protected Vector2 center;

        public GameObject()
        {

        }

        public virtual void Initialize()
        {

        }

        public virtual void Load(ContentManager content)
        {
            CalculateCenter();

        }

        public virtual void Update(List<GameObject> objects)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if(image != null && active == true)
                spriteBatch.Draw(image, position, null, drawColor, rotation, Vector2.Zero, scale, SpriteEffects.None, layerDepth);
        }

        private void CalculateCenter()
        {
            if (image == null)
                return;

            center.X = image.Width / 2;
            center.Y = image.Height / 2;
        }
    }
}