using System.Data;
using System.Json;

namespace VstupStats.Builder;

public abstract class BuilderBase
{
    public IList<BuilderItem> Items { get; protected set; }
    public virtual JsonValue RetrieveValue(DataRow row, BuilderItem item)
    {
        var index = Items.IndexOf(item);
        return item.JsonValue(row[index].ToString());
    }
}
