using System.Text;

namespace HtmlBuilderPack;

public record HtmlTableBuilder<T> where T : class
{
    private List<T> _objects;
    private HtmlTable<T> _rootTable;
    public HtmlTableBuilder(HtmlTable<T> htmlTable)
    {
        _rootTable = htmlTable;
    }

    public HtmlTableBuilder() : this(new HtmlTable<T>(new List<T>()))
    {

    }

    public HtmlTableBuilder(List<T> objects)
    {
        _objects = objects;
        _rootTable = new HtmlTable<T>(objects);
    }

    public static HtmlTableBuilder<T> Init(List<T> objects) => new HtmlTableBuilder<T>(new HtmlTable<T>(objects));
    public static HtmlTableBuilder<T> Init(List<T> objects, string @class, string id, string value, string name, string[] attributes) =>
        new(new HtmlTable<T>(objects, @class, id, name, value, attributes));

    public override string ToString() => _rootTable.ToString();


}
