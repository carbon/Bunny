namespace Bunny.Cdn;

public sealed class BunnyAccessKey : IBunnyAccessKey
{
    public BunnyAccessKey(string value)
    {
        ArgumentNullException.ThrowIfNull(value);

        Value = value;
    }

    public bool ShouldRenew => false;

    public ValueTask RenewAsync()
    {
        return ValueTask.CompletedTask;
    }

    public string Value { get; }
}
