// <auto-generated />
using CGWORLD;
using MasterMemory;
using MessagePack;
using System.Collections.Generic;
using System;

namespace CGWORLD.Tables
{
   public sealed partial class ClassificationTable : TableBase<Classification>
   {
        readonly Func<Classification, int> primaryIndexSelector;

        readonly Classification[] secondaryIndex0;
        readonly Func<Classification, string> secondaryIndex0Selector;

        public ClassificationTable(Classification[] sortedData)
            : base(sortedData)
        {
            this.primaryIndexSelector = x => x.Id;
            this.secondaryIndex0Selector = x => x.Name;
            this.secondaryIndex0 = CloneAndSortBy(this.secondaryIndex0Selector, System.StringComparer.Ordinal);
        }

        public RangeView<Classification> SortByName => new RangeView<Classification>(secondaryIndex0, 0, secondaryIndex0.Length - 1, true);

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public Classification FindById(int key)
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

        public Classification FindClosestById(int key, bool selectLower = true)
        {
            return FindUniqueClosestCore(data, primaryIndexSelector, System.Collections.Generic.Comparer<int>.Default, key, selectLower);
        }

        public RangeView<Classification> FindRangeById(int min, int max, bool ascendant = true)
        {
            return FindUniqueRangeCore(data, primaryIndexSelector, System.Collections.Generic.Comparer<int>.Default, min, max, ascendant);
        }

        public RangeView<Classification> FindByName(string key)
        {
            return FindManyCore(secondaryIndex0, secondaryIndex0Selector, System.StringComparer.Ordinal, key);
        }

        public RangeView<Classification> FindClosestByName(string key, bool selectLower = true)
        {
            return FindManyClosestCore(secondaryIndex0, secondaryIndex0Selector, System.StringComparer.Ordinal, key, selectLower);
        }

        public RangeView<Classification> FindRangeByName(string min, string max, bool ascendant = true)
        {
            return FindManyRangeCore(secondaryIndex0, secondaryIndex0Selector, System.StringComparer.Ordinal, min, max, ascendant);
        }

    }
}