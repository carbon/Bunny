﻿namespace Bunny.Cdn;

public sealed class GeotrafficDistribution : Dictionary<string, long>
{
    public GeotrafficDistribution() { }

    public GeotrafficDistribution(int capacity)
        : base(capacity) { }
}