// <auto-generated />
using CGWORLD;
using MasterMemory;
using MessagePack;
using System.Collections.Generic;
using System;

namespace CGWORLD.Tables
{
   public sealed partial class Animal2Table : TableBase<Animal2>
   {
        readonly Func<Animal2, int> primaryIndexSelector;

        readonly Animal2[] secondaryIndex0;
        readonly Func<Animal2, int> secondaryIndex0Selector;

        public Animal2Table(Animal2[] sortedData)
            : base(sortedData)
        {
            this.primaryIndexSelector = x => x.Id;
            this.secondaryIndex0Selector = x => x.Classification;
            this.secondaryIndex0 = CloneAndSortBy(this.secondaryIndex0Selector, System.Collections.Generic.Comparer<int>.Default);
        }

        public RangeView<Animal2> SortByClassification => new RangeView<Animal2>(secondaryIndex0, 0, secondaryIndex0.Length - 1, true);

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public Animal2 FindById(int key)
        {
            var lo = 0;
            var hi = data.Length - 1;
            while (lo <= hi)
            {
                var mid = (int)(((uint)hi + (uint)lo) >> 1);
                var selected = data[mid].Id;
                var found = (selected < key) ? -1 : (selected > key) ? 1 : 0;
                if (found == 0) { return data[mid]; }
                if (found < 0) { lo = mid + 1; }
                else { hi = mid - 1; }
            }
            return default;
        }

        public Animal2 FindClosestById(int key, bool selectLower = true)
        {
            return FindUniqueClosestCore(data, primaryIndexSelector, System.Collections.Generic.Comparer<int>.Default, key, selectLower);
        }

        public RangeView<Animal2> FindRangeById(int min, int max, bool ascendant = true)
        {
            return FindUniqueRangeCore(data, primaryIndexSelector, System.Collections.Generic.Comparer<int>.Default, min, max, ascendant);
        }

        public RangeView<Animal2> FindByClassification(int key)
        {
            return FindManyCore(secondaryIndex0, secondaryIndex0Selector, System.Collections.Generic.Comparer<int>.Default, key);
        }

        public RangeView<Animal2> FindClosestByClassification(int key, bool selectLower = true)
        {
            return FindManyClosestCore(secondaryIndex0, secondaryIndex0Selector, System.Collections.Generic.Comparer<int>.Default, key, selectLower);
        }

        public RangeView<Animal2> FindRangeByClassification(int min, int max, bool ascendant = true)
        {
            return FindManyRangeCore(secondaryIndex0, secondaryIndex0Selector, System.Collections.Generic.Comparer<int>.Default, min, max, ascendant);
        }

    }
}