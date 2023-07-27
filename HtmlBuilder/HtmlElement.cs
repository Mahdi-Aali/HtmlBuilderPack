using System.Text;

namespace HtmlBuilderPack;

public record HtmlElement(string TagName, string Text, string Value, string[] Attributes, string Class, string Id, string Name, bool SelfCloseTag = false)
{
    public string TagName = TagName;
    public string Text = Text;
    public string Value = Value;
    public string Class = Class;
    public string Id = Id;
    public string Name = Name;
    public bool SelfCloseTag = SelfCloseTag;

    private Lazy<List<HtmlElement>> elements = new();
    public List<HtmlElement> Elements => elements.Value;

    private const int indentSize = 2;

    public override string ToString() => ToStringImplimantation(0);

    private string ToStringImplimantation(int indent)
    {
        StringBuilder sb = new();
        string indentString = new string(' ', indent * indentSize);

        sb.Append($"{indentString}<{TagName}{(!string.IsNullOrWhiteSpace(Value) ? $@" value=""{Value}"" " : null)}");
        sb.Append($"{(!string.IsNullOrWhiteSpace(Class) ? $@" class=""{Class}"" " : "")}");
        sb.Append($"{(!string.IsNullOrWhiteSpace(Id) ? $@" id=""{Id}"" " : "")}");
        sb.Append($"{(!string.IsNullOrWhiteSpace(Name) ? $@" name=""{Name}"" " : "")}");
        sb.Append($"{(Attributes.Length > 0 ? $" {string.Join(' ', Attributes)}" : "")}");
        sb.Append($"{(SelfCloseTag ? "/" : "")}>\n");
        if (!string.IsNullOrWhiteSpace(Text))
        {
            sb.Append(new string(' ', indentSize * (indent + 1)));
            sb.Append(Text);
            sb.Append("\n");
        }
        foreach(var e in Elements)
        {
            sb.Append(e.ToStringImplimantation(indent + 1));
        }
        if (!SelfCloseTag)
        {
            sb.Append($"{indentString}</{TagName}>\n");
        }
        return sb.ToString();
    }

}