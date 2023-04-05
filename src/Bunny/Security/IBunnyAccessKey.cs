namespace Bunny;

public interface IBunnyAccessKey
{
    bool ShouldRenew { get; }

    ValueTask RenewAsync();

    string Value { get; }
}

// This contract may be implemented to allow keys to be rotated in production