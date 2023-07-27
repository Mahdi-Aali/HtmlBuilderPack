namespace HtmlBuilderPack;

public class HtmlBuilder
{
    private HtmlElement _rootElement;

    public HtmlBuilder(HtmlElement rootElement) => _rootElement = rootElement;

    public HtmlBuilder AddChild(HtmlElement child)
    {
        _rootElement.Elements.Add(child);
        return this;
    }

    public HtmlBuilder AddChild(HtmlBuilder builder)
    {
        _rootElement.Elements.Add(builder._rootElement);
        return this;
    }

    private IEnumerable<HtmlElement> _htmlElements => _rootElement.Elements;

    public override string ToString() => _rootElement.ToString();
}
