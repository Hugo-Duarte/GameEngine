using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace GameEngine
{
    public class Bullet : GameObject
    {
        const float speed = 12f;
        Character owner;

        int destroyTimer;
        const int maxTimer = 180;

        public Bullet()
        {
            active = false;
        }

        public override void Load(ContentManager content)
        {
            image = TextureLoader.Load("bullet", content);
            base.Load(content);
        }

        public override void Update(List<GameObject> objects, Map map)
        {
            if (active == false)
                return;

            // Update movement
            position += direction * speed;

            CheckCollisions(objects, map);

            //Update death timer
            destroyTimer--;
            if (destroyTimer <= 0 && active == true)
                Destroy();

            base.Update(objects, map);
        }

        private void CheckCollisions(List<GameObject> objects, Map map)
        {
            foreach(GameObject gameObject in objects)
            {
                if (gameObject.active == true && gameObject != owner && gameObject.CheckCollision(BoundingBox) == true)
                {
                    Destroy();
                    gameObject.BulletResponse();
                    return;
                }
            }

            if (map.CheckCollision(BoundingBox) != Rectangle.Empty)
                Destroy();
        }

        private void Destroy()
        {
            active = false;
        }

        internal void Fire(Character inputOwner, Vector2 inputPosition, Vector2 inputDirection)
        {
            owner = inputOwner;
            position = inputPosition;
            direction = inputDirection;

            active = true;

            destroyTimer = maxTimer;
        }

    }
}
