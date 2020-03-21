using MasterMemory;
using MessagePack;

namespace CGWORLD
{
    [MemoryTable("animal2"), MessagePackObject(true)]
    public class Animal2
    {
        [PrimaryKey]
        public int Id { get; set; }
        [SecondaryKey(0), NonUnique]
        public string Classification { get; set; }
        public string Name { get; set; }
        public float Size { get; set; }
        public string Url { get; set; }

        public Animal2(int id, string classification, string name, float size, string url)
        {
            Id = id;
            Name = name;
            Size = size;
            Classification = classification;
            Url = url;
        }
    }
}