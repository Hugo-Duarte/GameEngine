using System.Collections.Generic;

namespace GameEngine
{
    public class Animation
    {
        public string name;
        public List<int> animationOrder = new List<int>();
        public int speed;

        public Animation()
        {

        }

        public Animation(string inputName, int inputSpeed, List<int> inputAnimationOrder)
        {
            name = inputName;
            speed = inputSpeed;
            animationOrder = inputAnimationOrder;
        }

    }

    public class AnimationSet
    {
        //info for each frame
        public int width;
        public int height;

        //How many frames per direction X or Y
        public int gridX;
        public int gridY;

        public AnimationSet()
        {

        }

        public AnimationSet(int inputWidth, int inputHeight, int inputGridX, int inputGridY)
        {
            width = inputWidth;
            height = inputHeight;
            gridX = inputGridX;
            gridY = inputGridY;
        }
    }

    public class AnimationData
    {
        public AnimationSet animation { get; set; }
        public string texturePath { get; set; }
    }
}
