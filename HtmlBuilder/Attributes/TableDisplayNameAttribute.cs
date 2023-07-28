namespace HtmlBuilderPack.Attributes;

public class TableDisplayNameAttribute : Attribute
{
    public string DisplayName { get; set; } = string.Empty;

    public TableDisplayNameAttribute(string displayName) => DisplayName = displayName;
}
