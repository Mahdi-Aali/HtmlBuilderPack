# HtmlBuilderPack

You can use this package insted of TagBuilder class in c# for building your html tags faster and esier.

## This is an example of how you can use this package

First of all you need to create new instanse of object named ```HtmlBuilder``` to go forward
and for printing or getting tags as string you simply use name of instanse.

for adding chile to your current tag use can use method named ```AddChild```

# `HtmlBuilder` and `HtmlElement`
## Version 1.0.0 & 2.0.0
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

---------------

# `HtmlTableBuilder<T>` and `HtmlTable<T>`
## Version 2.0.0

for Creating html table fast and easy with you object list you can use `HtmlTableBuilder` class to do that here is an example

```c#
using HtmlBuilderPack.Attributes;

// example class
internal class Book
{

  // you need to use this attribute to determine name of property in table header
  // if you don't want a property to be in table just remove this attribute and it will be ignored.
  [TableDisplayName("Id of book")]
  public int BookId { get; set; }

  [TableDisplayName("subject")]
  public string Subject { get; set; }

  [TableDisplayName("price")]
  public decimal Price { get; set; }

  public Book(int id, string subject, decimal price)
  {
    BookId = id;
    Subject = subject;
    Price = price;
  }
}
```
## as I said in comment of above code if you want to show your property in table you need to add attribute named `TableDisplayName("Name")` for using it. else it will be ignored in generating time.

for creating table whenever you want you can use this way:

```c#
using HtmlBuilderPack;

List<Book> books = new()
{
  new(1, "Test1", 10),
  new(2, "Test1", 10),
  new(3, "Test1", 10),
};

HtmlTableBuilder<Book> htb = HtmlTableBuilder<Book>.Init(books);

Console.WriteLine(htb);
```

here is an example of what we get as string to view: 

```html
<table >
  <thead>
    <tr>
      <th>
        Id of book
      </th>
      <th>
        subject
      </th>
      <th>
        price
      </th>
    </tr>
  </thead>
  <tbody>
      <tr>
        <td>
          1
        </td>
        <td>
          Test1
        </td>
        <td>
          10
        </td>
      <tr>
      <tr>
        <td>
          2
        </td>
        <td>
          Test1
        </td>
        <td>
          10
        </td>
      <tr>
      <tr>
        <td>
          3
        </td>
        <td>
          Test1
        </td>
        <td>
          10
        </td>
      <tr>
  </tbody>
</table>
```

if you want to add class or some attribute to your table you can use this waies:

```c#
HtmlTableBuilder<Book> htb = HtmlTableBuilder<Book>.Init(books, "class", "id", "value", "name",
 new string[1]{ $@"CustomAttribute=""test""" });

```
so if we run this command we will get this result: 

```html
<table class="class" id="id" value="value" name="name" CustomAttribute="test">
  <thead>
    <tr>
      <th>
        Id of book
      </th>
      <th>
        subject
      </th>
      <th>
        price
      </th>
    </tr>
  </thead>
  <tbody>
      <tr>
        <td>
          1
        </td>
        <td>
          Test1
        </td>
        <td>
          10
        </td>
      <tr>
      <tr>
        <td>
          2
        </td>
        <td>
          Test1
        </td>
        <td>
          10
        </td>
      <tr>
      <tr>
        <td>
          3
        </td>
        <td>
          Test1
        </td>
        <td>
          10
        </td>
      <tr>
  </tbody>
</table>
```

you can even use constructor to create new instance of `HtmlTableBuilder<T>` class; witch is has two constructor
1. Takes just list of object you want to create table of it
2. Takes class named `HtmlTable<T>`

note that `HtmlTable<T>` class has two constructor too.

1. Takes only list of object you want to create table of it.
2. Takes list of object you want to create table of it and five other arguments that I named below.

   
   2.1. `List<T> objects` list of objects.
   
   2.2. `string cssClass` css classes.
   
   2.3. `string id` id of element in page.
   
   2.4. `string name` name of element in page.
   
   2.5. `string value` value of element in page.
   
   2.6. `string[] attributes` custom attributes you want to add to table.
   
