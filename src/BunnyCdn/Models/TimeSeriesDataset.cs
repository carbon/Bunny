using System;
using System.Collections.Generic;

namespace BunnyCdn.Models
{
    public sealed class TimeSeriesDataset<T> : Dictionary<DateTime, T>
    {
        public TimeSeriesDataset() { }

        public TimeSeriesDataset(int capacity)
            : base(capacity) { }
    }
}
