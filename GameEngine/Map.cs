using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace GameEngine
{
    public class Map
    {
        public List<Wall> walls = new List<Wall>();
        Texture2D wallImage;

        public int mapWidth = 15;
        public int mapHeight = 9;
        public int tileSize = 128;

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
}
