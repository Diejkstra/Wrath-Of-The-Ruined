using System;

namespace Engine
{
    [Serializable]
    public class Item
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public int Price { get; set; }
    }
}
