# HtmlBuilderPack

You can use this package insted of TagBuilder class in c# for building your html tags faster and esier.

## This is an example of how you can use this package

First of all you need to create new instanse of object named ```HtmlBuilder``` to go forward
and for printing or getting tags as string you simply use name of instanse.

for adding chile to your current tag use can use method named ```AddChild```

```c#
using HtmlBuilderPack;

HtmlBuilder builder = new(new("html", null, null, new string[0], null, null, null));

builder.AddChild(new HtmlElement("body", null, null, new string[0], null, null, null));
// or you can use this way

builder.AddChild(new HtmlElement("body", null, null, new string[0], null, null, null))
.AddChild(new HtmlElement("Tag", "Text", "Value", new string[1] { $@"CustomAttribute=""text""" }, "class", "id", "name", true));


// the AddChild method has overload that getting "HtmlBuilder" too

// for example

HtmlBuilder hb = new(new("test", null, null, new string[0], null, null, null));

builder.AddChild(hb);
Console.WriteLine(builder);

```
------------

### List of Arguments
rcord class named ```HtmlElement``` takes 8 argument in his constructor.

1. "**Tag name**" For example "p" or "select" or any tag u want to add even your custom tag you build using ViewComponents. `string`
2. "**Text**" The text you want to be inside of your tag. `string`
3. "**Value**" Value of tag; for example in input tages you can use this. `string`
4. "**Attributes**" Custom attributes you want to add to tag. `string[]`
5. "**Class**" The class you want to add to tag. `string`
6. "**Id**" The id of element in document. `string`
7. "**Name**" name of tag. `string`
8. "**SelfCloseTag**" is tag is self closed ? `bool` default value is 'false'
