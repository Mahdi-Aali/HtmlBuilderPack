
using HtmlBuilderPack;

HtmlBuilder hb = new(new("html", null, null, new string[0], null, null, null));

HtmlBuilder headTags = new(new("head", null, null, new string[0], null, null, null));
headTags.AddChild(new HtmlElement("Title", "Home", null, new string[0], null, null, null))
    .AddChild(new HtmlElement("link", null, null, new string[2] { $@"rel=""stylesheet""", $@"href=""https://example.com/test.css""" }
    , null, null, null, true))
    .AddChild(new HtmlElement("script", null, null, new string[1] { $@"src=""/Test.js""" }, null, null, null));

HtmlBuilder bodyTages = new(new("body", null, null, new string[0], null, null, null));
HtmlBuilder pTag = new(new("p", "Hello World!", "10", new string[0], "example", "p1", "test"));
pTag.AddChild(new HtmlElement("span", "Test message from span here!", null, new string[1] { $@"Test=""Hello""" }, null, null, null));
bodyTages.AddChild(pTag);

hb.AddChild(headTags);
hb.AddChild(bodyTages);


Console.WriteLine(hb);