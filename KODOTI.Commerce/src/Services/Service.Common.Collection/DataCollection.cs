using System;
using System.Collections.Generic;
using System.Linq;


namespace Service.Common.Collection
{
    public class DataCollection<T>
    {
        public bool hasItems
        {
            get
            {
                return Items != null && Items.Any();
            }
        }
        public IEnumerable<T> Items { get; set; }
        public int Total { get; set; }
        public int Page { get; set; }
        public int Pages { get; set; }
    }
}
