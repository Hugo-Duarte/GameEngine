﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class GameHUD
    {
        SpriteFont font;

        public GameHUD()
        {

        }

        public void Load(ContentManager content)
        {
            font = content.Load<SpriteFont>("Fonts\\Arial");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.Default, RasterizerState.CullNone, null, Resolution.getTransformationMatrix());

            spriteBatch.DrawString(font, "Score: " + Player.score.ToString(), Vector2.Zero, Color.White);

            spriteBatch.End();
        }
    }
}
