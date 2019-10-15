using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace GameEngine
{
    public class FireCharacter : Character
    {
        List<Bullet> bullets = new List<Bullet>();

        const int numberOfBullets = 20;

        public FireCharacter()
        {

        }

        public override void Initialize()
        {
            if (bullets.Count == 0)
            {
                for (int i = 0; i < numberOfBullets; i++)
                    bullets.Add(new Bullet());
            }

            base.Initialize();
        }

        public override void Load(ContentManager content)
        {
            foreach (Bullet bullet in bullets)
                bullet.Load(content);

            base.Load(content);
        }

        public override void Update(List<GameObject> objects, Map map)
        {
            foreach (Bullet bullet in bullets)
                bullet.Update(objects, map);

            base.Update(objects, map);
        }

        public void Fire()
        {
            foreach (Bullet bullet in bullets)
            {
                if (bullet.active == false)
                {
                    bullet.Fire(this, position, direction);
                    break;
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (Bullet bullet in bullets)
                bullet.Draw(spriteBatch);

            base.Draw(spriteBatch);
        }
    }
}
