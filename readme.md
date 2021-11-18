# <img src="/src/icon.png" height="30px"> PandocNet

[![Build status](https://ci.appveyor.com/api/projects/status/naxouwk164twkgn3?svg=true)](https://ci.appveyor.com/project/SimonCropp/PandocNet)
[![NuGet Status](https://img.shields.io/nuget/v/PandocNet.svg)](https://www.nuget.org/packages/PandocNet/)

Conversion of document via [Pandoc](https://pandoc.org/). Wraps the pandoc.exe using [CliWrap](https://github.com/Tyrrrz/CliWrap) and provides storng type optiosn for document formats.

## NuGet package

https://nuget.org/packages/PandocNet/


## Usage


### Text

<!-- snippet: text -->
<a id='snippet-text'></a>
```cs
var engine = new PandocEngine();
var result = await engine.ConvertText<CommonMarkIn, HtmlOut>("*text*");
```
<sup><a href='/src/Tests/Samples.cs#L42-L45' title='Snippet source file'>snippet source</a> | <a href='#snippet-text' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### Streams

<!-- snippet: streams -->
<a id='snippet-streams'></a>
```cs
var engine = new PandocEngine();
await using var inStream = File.OpenRead("sample.md");
await using var outStream = File.OpenWrite("output.html");
await engine.Convert<CommonMarkIn, HtmlOut>(
    inStream,
    outStream);
```
<sup><a href='/src/Tests/Samples.cs#L24-L33' title='Snippet source file'>snippet source</a> | <a href='#snippet-streams' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### Custom Options

<!-- snippet: custom-options -->
<a id='snippet-custom-options'></a>
```cs
var engine = new PandocEngine();
var result = await engine.ConvertText(@"
# Heading1

text

## Heading2 

text
",
    new CommonMarkIn
    {
        ShiftHeadingLevelBy = 2
    },
    new HtmlOut
    {
        NumberOffsets = new List<int> {3}
    });
```
<sup><a href='/src/Tests/Samples.cs#L53-L72' title='Snippet source file'>snippet source</a> | <a href='#snippet-custom-options' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


## Icon

[Boxes](https://thenounproject.com/term/boxes/1526666/) designed by [Amelia](https://thenounproject.com/langonsivani/) from [The Noun Project](https://thenounproject.com/).
