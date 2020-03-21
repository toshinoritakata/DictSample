using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using MasterMemory;
using MessagePack;

namespace CGWORLD
{
    public abstract class SingletonBase<T>
    where T : SingletonBase<T>, new()
    {
        private static readonly T _instance = new T();
        public static T Instance { get { return _instance; } }
    }

    class AnimalDB : SingletonBase<AnimalDB>
    {
        private MemoryDatabase _db;
        public MemoryDatabase DB => _db;

        public AnimalDB()
        {
            var databaseBuilder = new DatabaseBuilder();
            databaseBuilder.Append(new List<Animal> {
                    new Animal(0, "哺乳類", "アイアイ", 400),
                    new Animal(1, "鳥類", "アオサギ", 930),
                    new Animal(2, "爬虫類", "ムカシトカゲ", 600),
                    new Animal(3, "両生類", "ツチガエル", 40)});
            _db = new MemoryDatabase(databaseBuilder.Build());
        }
    }
}
