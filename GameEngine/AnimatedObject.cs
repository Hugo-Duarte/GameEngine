using Microsoft.Xna.Framework.Graphics;

namespace GameEngine
{
    class AnimatedObject : GameObject
    {
        protected int currentAnimationFrame;
        protected float actionTimer;
        protected int currentAnimationX, currentAnimationY;
        protected AnimationSet animationSet;
        protected Animation currentAnimation;

        protected bool flipRightFrames = true;
        protected bool flipLeftFrames = false;

        protected SpriteEffects spriteEffects = SpriteEffects.None;

        protected enum Animations
        {
            RunLeft, RunRight, IdleLeft, IdleRight
        }

        public AnimatedObject()
        {
            
        }
    }
}
