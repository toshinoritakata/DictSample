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
        public int Classification { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public Animal2(int id, int classification, string name, string url)
        {
            Id = id;
            Name = name;
            Classification = classification;
            Url = url;
        }
    }
}