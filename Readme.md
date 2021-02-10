# JsonExtensions

[![Build](https://github.com/Tyrrrz/JsonExtensions/workflows/CI/badge.svg?branch=master)](https://github.com/Tyrrrz/JsonExtensions/actions)
[![Coverage](https://codecov.io/gh/Tyrrrz/JsonExtensions/branch/master/graph/badge.svg)](https://codecov.io/gh/Tyrrrz/JsonExtensions)
[![Version](https://img.shields.io/nuget/v/JsonExtensions.svg)](https://nuget.org/packages/JsonExtensions)
[![Downloads](https://img.shields.io/nuget/dt/JsonExtensions.svg)](https://nuget.org/packages/JsonExtensions)
[![Donate](https://img.shields.io/badge/donate-$$$-purple.svg)](https://tyrrrz.me/donate)

✅ **Project status: active**.

This library provides a set of helpful utilities for types defined in the [System.Text.Json](https://docs.microsoft.com/en-us/dotnet/api/system.text.json) namespace.

## Download

📦 [NuGet](https://nuget.org/packages/JsonExtensions): `dotnet add package JsonExtensions`

## Usage

### Parsing JsonElement

You can use the static methods on `Json` class to parse JSON directly into a stateless `JsonElement` instance, without having to deal with `JsonDocument` in the process:

```csharp
using JsonExtensions;

var jsonRaw = "{ \"foo\": \"bar\" }";

var jsonElement = Json.Parse(jsonRaw); // returns JsonElement
var jsonElement = Json.TryParse(jsonRaw); // returns null in case of invalid JSON
```

### Null-safe reading

This library offers many extension methods for `JsonElement` that allow you to read content in a more fault-tolerant way:

```csharp
using JsonExtensions.Reading;

var jsonElement = ...

// Gets a property or returns null if:
// - element is not an object
// - property doesn't exist
// - property is null
var maybeProperty = jsonElement.GetPropertyOrNull("prop");

// Gets an array child or returns null if:
// - element is not an array
// - index is out of bounds
// - child is null
var maybeChild = jsonElement.GetByIndexOrNull(3);

// Gets the value coerced into specified type or returns null if:
// - element is null
// - element's kind doesn't match the specified type
// - the value cannot be parsed into the specified type
var maybeString = jsonElement.GetStringOrNull();
var maybeInt32 = jsonElement.GetInt32OrNull();
var maybeGuid = jsonElement.GetGuidOrNull();

// Enumerates the array/object
// or returns null if the element is not an array/object
var arrayEnumerator = jsonElement.EnumerateArrayOrNull();
var objectEnumreator = jsonElement.EnumerateObjectOrNull();

// Enumerates the array/object
// or returns an empty enumerator if the element is not an array/object
foreach (var child in jsonElement.EnumerateArrayOrEmpty())
{
    // ...
}

foreach (var (name, child) in jsonElement.EnumerateObjectOrEmpty())
{
    // ...
}
```

Some of these methods can be also chained together using the null-conditional operator:

```csharp
// Returns null if:
// - property doesn't exist
// - property is null
// - property's value cannot be coerced into the specified type
var maybeInt32 = jsonElement.GetPropertyOrNull("prop")?.GetInt32OrNull();
```

### Null-safe writing

Similarly, there are also extension methods for `Utf8JsonWriter` that allow writing nullable versions of common value types:

```csharp
using JsonExtensions.Writing;

var writer = new Utf8JsonWriter(...);

// Writes "prop":true
writer.WriteBoolean("prop", new bool?(true));

// Writes "prop":null
writer.WriteBoolean("prop", new bool?());
```

### Parsing JSON from HTTP

To make it easier to read JSON that comes from HTTP, this library provides extension methods on `HttpContent` and `HttpClient`:

```csharp
using JsonExtensions.Http;

var httpClient = new HttpClient();

// Send GET request and retrieve JSON directly
var json = await httpClient.GetJsonAsync("...");

// Read JSON from content
using var request = new HttpRequestMessage(HttpMethod.Post, "...");
using var response = await httpClient.SendAsync(request); 
var json = await response.Content.ReadAsJsonAsync();
```

### Accessing children by path

Using `jsonElement.GetPropertyByPathOrNull(...)` or `jsonElement.GetPropertyByPath(...)`, you can get an inner child by specifying its path:

```csharp
var json = Json.Parse("{\"foo\":{\"bar\":{\"baz\":13}}}");

var child = json.GetPropertyByPath("foo.bar.baz");

var value = child.GetInt32(); // 13
```

> Note this only supports basic paths involving child access operators.
It doesn't (yet) have full support for JPath.
