using System.Json;

namespace VstupStats.Builder;

public abstract class BuilderItem
{
    public string Key { get; set; }
    public string? ValuePrefix { get; set; }
    public abstract Func<string?, JsonValue> JsonValue { get; }
    public BuilderItem(string key, string? valuePrefix)
    {
        Key = key;
        ValuePrefix = valuePrefix;
    }
}

public class BuilderStringItem : BuilderItem
{
    public override Func<string?, JsonValue> JsonValue { get; }
    public BuilderStringItem(string key, string? valuePrefix = null)
        : base(key, valuePrefix)
    {
        JsonValue = (value) => new JsonPrimitive(value);
    }
}

public class BuilderIntItem : BuilderItem
{
    public override Func<string?, JsonValue> JsonValue { get; }
    public BuilderIntItem(string key, string? valuePrefix = null)
        : base(key, valuePrefix)
    {
        JsonValue = (value) => new JsonPrimitive(int.Parse(value ?? "0"));
    }
}

public class BuilderFloatItem : BuilderItem
{
    public override Func<string?, JsonValue> JsonValue { get; }
    public BuilderFloatItem(string key, string? valuePrefix = null)
        : base(key, valuePrefix)
    {
        JsonValue = (value) => new JsonPrimitive(float.Parse(value ?? "0"));
    }
}

public class BuilderBoolItem : BuilderItem
{
    public override Func<string?, JsonValue> JsonValue { get; }
    public BuilderBoolItem(string key, string? valuePrefix = null)
        : base(key, valuePrefix)
    {
        JsonValue = (value) => new JsonPrimitive(value?.ToLower() == "так" ? true : false);
    }
}

public class BuilderDateTimeItem : BuilderItem
{
    public override Func<string?, JsonValue> JsonValue { get; }
    public BuilderDateTimeItem(string key, string? valuePrefix = null)
        : base(key, valuePrefix)
    {
        JsonValue = (value) => new JsonPrimitive(DateTime.TryParse(value, out DateTime date) ? date.ToUniversalTime() : DateTime.MinValue);
    }
}

public class BuilderStringArrayItem : BuilderItem
{
    public override Func<string?, JsonValue> JsonValue { get; }
    public BuilderStringArrayItem(string key, string? valuePrefix = null)
        : base(key, valuePrefix)
    {
        JsonValue = (value) => new JsonArray(value?.Split(", ").Select(x => new JsonPrimitive(x)));
    }
}