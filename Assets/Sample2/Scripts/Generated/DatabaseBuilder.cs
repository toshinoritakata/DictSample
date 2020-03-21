// <auto-generated />
using CGWORLD;
using MasterMemory;
using MessagePack;
using System.Collections.Generic;
using System;
using CGWORLD.Tables;

namespace CGWORLD
{
   public sealed class DatabaseBuilder : DatabaseBuilderBase
   {
        public DatabaseBuilder() : this(null) { }
        public DatabaseBuilder(MessagePack.IFormatterResolver resolver) : base(resolver) { }

        public DatabaseBuilder Append(System.Collections.Generic.IEnumerable<Animal> dataSource)
        {
            AppendCore(dataSource, x => x.Id, System.Collections.Generic.Comparer<int>.Default);
            return this;
        }

        public DatabaseBuilder Append(System.Collections.Generic.IEnumerable<Animal2> dataSource)
        {
            AppendCore(dataSource, x => x.Id, System.Collections.Generic.Comparer<int>.Default);
            return this;
        }

        public DatabaseBuilder Append(System.Collections.Generic.IEnumerable<Classification> dataSource)
        {
            AppendCore(dataSource, x => x.Id, System.Collections.Generic.Comparer<int>.Default);
            return this;
        }

    }
}