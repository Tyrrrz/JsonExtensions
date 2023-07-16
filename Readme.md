# JsonExtensions

[![Status](https://img.shields.io/badge/status-maintenance-ffd700.svg)](https://github.com/Tyrrrz/.github/blob/master/docs/project-status.md)
[![Made in Ukraine](https://img.shields.io/badge/made_in-ukraine-ffd700.svg?labelColor=0057b7)](https://tyrrrz.me/ukraine)
[![Build](https://img.shields.io/github/actions/workflow/status/Tyrrrz/JsonExtensions/main.yml?branch=master)](https://github.com/Tyrrrz/JsonExtensions/actions)
[![Coverage](https://img.shields.io/codecov/c/github/Tyrrrz/JsonExtensions/master)](https://codecov.io/gh/Tyrrrz/JsonExtensions)
[![Version](https://img.shields.io/nuget/v/JsonExtensions.svg)](https://nuget.org/packages/JsonExtensions)
[![Downloads](https://img.shields.io/nuget/dt/JsonExtensions.svg)](https://nuget.org/packages/JsonExtensions)
[![Discord](https://img.shields.io/discord/869237470565392384?label=discord)](https://discord.gg/2SUWKFnHSm)
[![Fuck Russia](https://img.shields.io/badge/fuck-russia-e4181c.svg?labelColor=000000)](https://twitter.com/tyrrrz/status/1495972128977571848)

<table>
    <tr>
        <td width="99999" align="center">Development of this project is entirely funded by the community. <b><a href="https://tyrrrz.me/donate">Consider donating to support!</a></b></td>
    </tr>
</table>

**JsonExtensions** is a library that provides a set of helpful utilities for types defined in the [`System.Text.Json`](https://docs.microsoft.com/en-us/dotnet/api/system.text.json) namespace.

## Terms of use<sup>[[?]](https://github.com/Tyrrrz/.github/blob/master/docs/why-so-political.md)</sup>

By using this project or its source code, for any purpose and in any shape or form, you grant your **implicit agreement** to all the following statements:

- You **condemn Russia and its military aggression against Ukraine**
- You **recognize that Russia is an occupant that unlawfully invaded a sovereign state**
- You **support Ukraine's territorial integrity, including its claims over temporarily occupied territories of Crimea and Donbas**
- You **reject false narratives perpetuated by Russian state propaganda**

To learn more about the war and how you can help, [click here](https://tyrrrz.me/ukraine). Glory to Ukraine! 🇺🇦

## Install

- 📦 [NuGet](https://nuget.org/packages/JsonExtensions): `dotnet add package JsonExtensions`

## Usage

### Parsing JsonElement

You can use the static methods on the `Json` class to parse JSON directly into a stateless `JsonElement` instance, without having to deal with `JsonDocument` in the process:

```csharp
using JsonExtensions;

var jsonRaw = "{ \"foo\": \"bar\" }";

var jsonElement = Json.Parse(jsonRaw); // returns JsonElement
var jsonElement = Json.TryParse(jsonRaw); // returns null in case of invalid JSON
```

### Null-safe reading

This library offers many extension methods for `JsonElement` that allow you to read its content in a more fault-tolerant way:

```csharp
using JsonExtensions.Reading;

var jsonElement = ...;

// Gets a property or returns null if:
// - element is not an object
// - property does not exist
// - property value is null
var maybeProperty = jsonElement.GetPropertyOrNull("prop");

// Gets an array child or returns null if:
// - element is not an array
// - index is out of bounds
// - child is null
var maybeChild = jsonElement.GetByIndexOrNull(3);

// Gets the value converted into the specified type or returns null if:
// - element is null
// - element kind does not match the specified type
// - the value cannot be parsed into the specified type
var maybeString = jsonElement.GetStringOrNull();
var maybeInt32 = jsonElement.GetInt32OrNull();
var maybeGuid = jsonElement.GetGuidOrNull();

// Gets the value coerced into the specified type or returns null if:
// - element is null
// - element kind does not match the specified type or a string
// - the value cannot be parsed into the specified type
var maybeInt32Coerced = jsonElement.GetInt32CoercedOrNull();
var maybeDoubleCoerced = jsonElement.GetDoubleCoercedOrNull();

// Enumerates an array or returns null if:
// - element is not an array
var arrayEnumerator = jsonElement.EnumerateArrayOrNull();

// Enumerates an object or returns null if:
// - element is not an object
var objectEnumerator = jsonElement.EnumerateObjectOrNull();

// Enumerates an array or returns an empty enumerator if:
// - element is not an array
foreach (var child in jsonElement.EnumerateArrayOrEmpty())
{
    // ...
}

// Enumerates an object or returns an empty enumerator if:
// - element is not an object
foreach (var (name, child) in jsonElement.EnumerateObjectOrEmpty())
{
    // ...
}
```

Most of these methods can also be chained together using the null-conditional operator:

```csharp
// Returns null if:
// - element is not an object
// - property does not exist
// - property value is null
// - property value cannot be converted into the specified type
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

To make it easier to read JSON that comes from HTTP responses, this library also provides a few extension methods for `HttpContent` and `HttpClient`:

```csharp
using JsonExtensions.Http;

var http = new HttpClient();

// Send a GET request and retrieve JSON directly
var json = await http.GetJsonAsync("..."); // returns JsonElement

// Read JSON from content
using var request = new HttpRequestMessage(HttpMethod.Post, "...");
using var response = await http.SendAsync(request);
var json = await response.Content.ReadAsJsonAsync(); // returns JsonElement
```

### Accessing children by path

Using `jsonElement.GetPropertyByPathOrNull(...)` or `jsonElement.GetPropertyByPath(...)`, you can get an inner child by its path:

```csharp
var json = Json.Parse("{\"foo\":{\"bar\":{\"baz\":13}}}");

var child = json.GetPropertyByPath("foo.bar.baz");

var value = child.GetInt32(); // 13
```

> **Warning**:
> Note this only supports basic paths involving child access operators.
> It doesn't (yet) have full support for JPath.