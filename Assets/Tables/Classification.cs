using MasterMemory;
using MessagePack;

namespace CGWORLD
{
    [MemoryTable("classification"), MessagePackObject(true)]
    public class Classification
    {
        [PrimaryKey]
        public int Id { get; set; }
        [SecondaryKey(0), NonUnique]
        public string Name { get; set; }

        public Classification(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}