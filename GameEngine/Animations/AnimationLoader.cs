using System.IO;
using System.Xml.Serialization;

namespace GameEngine
{
    public static class AnimationLoader
    {
        /// <summary>
        /// Populates an AnimationData object with data requerired for the animation.
        /// </summary>
        public static AnimationData Load(string name)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(AnimationData));
            TextReader reader = new StreamReader("Content\\Animations\\" + name);
            AnimationData obj = (AnimationData)serializer.Deserialize(reader);
            reader.Close();
            return obj;
        }
    }
}
