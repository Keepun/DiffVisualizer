using System;
using System.Xml.Serialization;

namespace DiffVisualizer
{
    [Serializable]
    public class Config
    {
        public string Program;
        public string Arguments;
        public uint Update;
        public string Font;
        public string WorkDir;

        public int posX = -1;
        public int posY = -1;

        public int Width = 500;
        public int Height = 500;
    }
}
