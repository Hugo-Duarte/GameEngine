using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Player : GameObject
    {
        public Player()
        {

        }

        public Player(Vector2 inputPosition)
        {
            position = inputPosition;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Load(ContentManager content)
        {
            image = TextureLoader.Load("sprite", content);
            base.Load(content);
        }

        public override void Update(List<GameObject> objects)
        {
            CheckInput();
            base.Update(objects);
        }

        private void CheckInput()
        {
            if (Input.IsKeyDown(Keys.D) == true)
                position.X += 5;
            else if (Input.IsKeyDown(Keys.A) == true)
                position.X -= 5;

            if (Input.IsKeyDown(Keys.S) == true)
                position.Y += 5;
            else if (Input.IsKeyDown(Keys.W) == true)
                position.Y -= 5;
        }

    }
}
