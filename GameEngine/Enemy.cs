using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Enemy : Character
    {
        int respawnTimer;
        const int maxRespawnTimer = 60;

        Random random = new Random();

        SoundEffect explosion;

        public Enemy()
        {

        }

        public Enemy(Vector2 inputPosition)
        {
            position = inputPosition;
        }

        public override void Initialize()
        {
            active = true;
            collidable = false;

            position.X = random.Next(0, 1100);

            base.Initialize();
        }

        public override void Load(ContentManager content)
        {

            image = TextureLoader.Load("enemy", content);
            explosion = content.Load<SoundEffect>("Audio\\explosion");
            base.Load(content);
        }

        public override void Update(List<GameObject> objects, Map map)
        {
            if (respawnTimer > 0)
            {
                respawnTimer--;
                if (respawnTimer <= 0)
                    Initialize();
            }

            base.Update(objects, map);
        }

        public override void BulletResponse()
        {
            active = false;
            respawnTimer = maxRespawnTimer;

            explosion.Play();

            base.BulletResponse();
        }
    }
}
