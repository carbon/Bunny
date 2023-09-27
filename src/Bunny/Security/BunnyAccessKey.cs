namespace Bunny;

public sealed class BunnyAccessKey(string value) : IBunnyAccessKey
{
    public bool ShouldRenew => false;

    public string Value { get; } = value ?? throw new ArgumentNullException(nameof(value));

    public ValueTask RenewAsync()
    {
        return ValueTask.CompletedTask;
    }
}
