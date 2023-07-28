using HtmlBuilderPack.Attributes;
using System.Reflection;
using System.Text;

namespace HtmlBuilderPack;

public record HtmlTable<T>
{
    private List<T> _objects;
    private string _class;
    private string _id;
    private string _name;
    private string _value;
    private string[] _attributes;
    public HtmlTable(List<T> objects, string cssClass, string id, string name, string value, string[] attributes)
    {
        _objects = objects;
        _class = cssClass;
        _id = id;
        _name = name;
        _value = value;
        _attributes = attributes;
    }

    public HtmlTable(List<T> objects) : this(objects, null!, null!, null!, null!, new string[0])
    {

    }

    private const int IndentSize = 2;

    public override string ToString() => ToStringImplimantation(0);
    private string ToStringImplimantation(int indent)
    {
        StringBuilder sb = new();
        string indentString = new string(' ', indent * IndentSize);

        sb.Append($"{indentString}<table {(!string.IsNullOrEmpty(_class) ? $@"class=""{_class}"" " : "")}{(!string.IsNullOrEmpty(_id) ? $@"id=""{_id}"" " : "")}{(!string.IsNullOrEmpty(_value) ? $@"value=""{_value}"" " : "")}{(!string.IsNullOrEmpty(_name) ? $@"name=""{_name}"" " : "")}{(_attributes.Length > 0 ? string.Join(' ', _attributes) : "")}>\n");
        sb.Append($"{new string(' ', (indent + 1) * IndentSize)}<thead>\n");
        sb.Append($"{new string(' ', (indent + 2) * IndentSize)}<tr>\n");

        foreach (var item in typeof(T).GetProperties()
            .Where(p => p.GetCustomAttribute(typeof(TableDisplayNameAttribute)) != null))
        {
            sb.Append($"{new string(' ', (indent + 3) * IndentSize)}<th>\n");
            sb.Append($"{new string(' ', (indent + 4) * IndentSize)}{((TableDisplayNameAttribute)item.GetCustomAttribute(typeof(TableDisplayNameAttribute))).DisplayName}\n");
            sb.Append($"{new string(' ', (indent + 3) * IndentSize)}</th>\n");
        }
        sb.Append($"{new string(' ', (indent + 2) * IndentSize)}</tr>\n");
        sb.Append($"{new string(' ', (indent + 1) * IndentSize)}</thead>\n");

        sb.Append($"{new string(' ', (indent + 1) * IndentSize)}<tbody>\n");
        foreach (T row in _objects)
        {
            sb.Append($"{new string(' ', (indent + 3) * IndentSize)}<tr>\n");
            foreach (var item in row.GetType().GetProperties()
                .Where(p => p.GetCustomAttribute(typeof(TableDisplayNameAttribute)) != null))
            {
                sb.Append($"{new string(' ', (indent + 4) * IndentSize)}<td>\n");
                sb.Append($"{new string(' ', (indent + 5) * IndentSize)}{item.GetValue(row)}\n");
                sb.Append($"{new string(' ', (indent + 4) * IndentSize)}</td>\n");
            }
            sb.Append($"{new string(' ', (indent + 3) * IndentSize)}<tr>\n");
        }
        sb.Append($"{new string(' ', (indent + 1) * IndentSize)}</tbody>\n");


        sb.Append($"{indentString}</table>\n");

        return sb.ToString();
    }
}