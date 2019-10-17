using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace GameEngine
{
    public class Map
    {
        public List<Decor> decors = new List<Decor>();
        public List<Wall> walls = new List<Wall>();
        Texture2D wallImage;

        public int mapWidth = 15;
        public int mapHeight = 9;
        public int tileSize = 128;

        public void LoadMap(ContentManager content)
        {
            foreach (Decor decor in decors)
            {
                decor.Load(content, decor.imagePath);
            }
        }

        public void Load(ContentManager content)
        {
            wallImage = TextureLoader.Load("pixel", content);
        }

        public Rectangle CheckCollision(Rectangle input)
        {
            foreach (Wall item in walls)
            {
                if (item != null && item.wall.Intersects(input) == true)
                    return item.wall;
            }

            return Rectangle.Empty;
        }

        public void Update(List<GameObject> objects)
        {
            foreach (Decor decor in decors)
            {
                decor.Update(objects, this);
            }
        }

        public void DrawWalls(SpriteBatch spriteBatch)
        {
            foreach(Wall item in walls)
            {
                if (item != null && item.active == true)
                    spriteBatch.Draw(wallImage, new Vector2(item.wall.X, item.wall.Y), item.wall, Color.Black, 0f, Vector2.Zero, 1f, SpriteEffects.None, .7f);
            }
        }
    }

    public class Wall
    {
        public Rectangle wall;
        public bool active = true;

        public Wall()
        {

        }

        public Wall(Rectangle inputRectangle)
        {
            wall = inputRectangle;
        }
    }

    public class Decor : GameObject
    {
        public string imagePath;
        public Rectangle sourceRectangle;

        public string Name { get { return imagePath; } }

        public Decor()
        {
            collidable = false;
        }

        public Decor(Vector2 inputPosition, string inputImagePath, float inputDepth)
        {
            position = inputPosition;
            imagePath = inputImagePath;
            layerDepth = inputDepth;
            active = true;
            collidable = false;
        }

        public virtual void Load(ContentManager content, string asset)
        {
            image = TextureLoader.Load(asset, content);
            image.Name = asset;

            boundingBoxWidth = image.Width;
            boundingBoxHeight = image.Height;

            if (sourceRectangle == Rectangle.Empty)
                sourceRectangle = new Rectangle(0, 0, image.Width, image.Height);
        }

        public void SetImage(Texture2D input, string newPath)
        {
            image = input;
            imagePath = newPath;
            boundingBoxWidth = sourceRectangle.Width = input.Width;
            boundingBoxHeight = sourceRectangle.Height = input.Height;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (image != null && active == true)
                spriteBatch.Draw(image, position, sourceRectangle, drawColor, rotation, Vector2.Zero, scale, SpriteEffects.None, layerDepth);
        }
    }
}
