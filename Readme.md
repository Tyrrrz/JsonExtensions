# JsonExtensions

[![Build](https://github.com/Tyrrrz/JsonExtensions/workflows/CI/badge.svg?branch=master)](https://github.com/Tyrrrz/JsonExtensions/actions)
[![Coverage](https://codecov.io/gh/Tyrrrz/JsonExtensions/branch/master/graph/badge.svg)](https://codecov.io/gh/Tyrrrz/JsonExtensions)
[![Version](https://img.shields.io/nuget/v/JsonExtensions.svg)](https://nuget.org/packages/JsonExtensions)
[![Downloads](https://img.shields.io/nuget/dt/JsonExtensions.svg)](https://nuget.org/packages/JsonExtensions)
[![Donate](https://img.shields.io/badge/donate-$$$-purple.svg)](https://tyrrrz.me/donate)

**Project status: active**.

Extensions for working with [System.Text.Json](https://docs.microsoft.com/en-us/dotnet/api/system.text.json).

## Download

- [NuGet](https://nuget.org/packages/JsonExtensions): `dotnet add package JsonExtensions`

## Usage

### Shorthand for parsing `JsonElement`

You can use the static methods on `Json` class to parse JSON directly into a stateless `JsonElement`, bypassing `JsonDocument`:

```csharp
using JsonExtensions;

var jsonRaw = "{ \"foo\": \"bar\" }";

var jsonElement = Json.Parse(jsonRaw); // returns JsonElement
var jsonElement = Json.TryParse(jsonRaw); // returns null in case of invalid JSON
```

### Optional reading

You can use the extension methods on `JsonElement` to parse content in a more fault-tolerant way:

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

Some of these methods can be chained together as well:

```csharp
// Returns null if:
// - property doesn't exist
// - property is null
// - property's value cannot be coerced into the specified type
var maybeInt32 = jsonElement.GetPropertyOrNull("prop")?.GetInt32OrNull();
```

### Get a child by path

Using `jsonElement.GetPropertyByPathOrNull(...)` or `jsonElement.GetPropertyByPath(...)`, you can get an inner child by specifying its path:

```csharp
var json = Json.Parse("{\"foo\":{\"bar\":{\"baz\":13}}}");

var child = json.GetPropertyByPath("foo.bar.baz");

var value = child.GetInt32(); // 13
```

Note: currently only very basic paths are supported.

### Optional writing

The library provides extensions that allow you to write `Nullable<T>` instances directly with `Utf8JsonWriter`:

```csharp
using JsonExtensions.Writing;

var writer = new Utf8JsonWriter(...);

// Writes "prop":true
writer.WriteBoolean("prop", new bool?(true));

// Writes "prop":null
writer.WriteBoolean("prop", new bool?());
```

### Reading JSON from HTTP

There are also extensions to read `HttpContent` by parsing it as a `JsonElement`:

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
