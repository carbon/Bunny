namespace BunnyCdn;

public sealed class BunnyCdnAccessKey : IBunnyCdnAccessKey
{
    public BunnyCdnAccessKey(string value)
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
