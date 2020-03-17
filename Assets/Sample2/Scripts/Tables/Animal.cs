using MasterMemory;
using MessagePack;

namespace CGWORLD
{
    [MemoryTable("animal"), MessagePackObject(true)]
    public class Animal
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Classification { get; set; }
        public string Name { get; set; }
        public float Size { get; set; }

        public Animal(int id, string classification, string name, float size)
        {
            Id = id;
            Name = name;
            Size = size;
            Classification = classification;
        }
    }
}