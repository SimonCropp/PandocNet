# <img src="/src/icon.png" height="30px"> PandocNet

[![Build status](https://ci.appveyor.com/api/projects/status/naxouwk164twkgn3?svg=true)](https://ci.appveyor.com/project/SimonCropp/PandocNet)
[![NuGet Status](https://img.shields.io/nuget/v/Pandoc.svg)](https://www.nuget.org/packages/Pandoc/)

Conversion of documents via [Pandoc](https://pandoc.org/). Wraps the pandoc.exe using [CliWrap](https://github.com/Tyrrrz/CliWrap) and provides storng type options for document formats.


## NuGet package

https://nuget.org/packages/Pandoc/


## Usage


### Pandoc Path

By default `pandoc.exe` is expected to be accessible in the current environmenst `Path`.

[Installing Pandoc](https://pandoc.org/installing.html).

This can be changed:

<!-- snippet: PandocPath -->
<a id='snippet-pandocpath'></a>
```cs
var engine = new PandocEngine(@"D:\Tools\pandoc.exe");
```
<sup><a href='/src/Tests/Samples.cs#L33-L37' title='Snippet source file'>snippet source</a> | <a href='#snippet-pandocpath' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### Text

<!-- snippet: text -->
<a id='snippet-text'></a>
```cs
var engine = new PandocEngine();
var result = await engine.ConvertText<CommonMarkIn, HtmlOut>("*text*");
```
<sup><a href='/src/Tests/Samples.cs#L75-L80' title='Snippet source file'>snippet source</a> | <a href='#snippet-text' title='Start of snippet'>anchor</a></sup>
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
<sup><a href='/src/Tests/Samples.cs#L57-L66' title='Snippet source file'>snippet source</a> | <a href='#snippet-streams' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### Files

<!-- snippet: files -->
<a id='snippet-files'></a>
```cs
var engine = new PandocEngine();
await engine.ConvertFile<CommonMarkIn, HtmlOut>("sample.md", "output.html");
```
<sup><a href='/src/Tests/Samples.cs#L43-L48' title='Snippet source file'>snippet source</a> | <a href='#snippet-files' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### Raw Files

Passing in files with no options will result in defering to Pandoc both the file formats and default options.

<!-- snippet: RawFiles -->
<a id='snippet-rawfiles'></a>
```cs
var engine = new PandocEngine();
await engine.ConvertFile("sample.md", "output.html");
```
<sup><a href='/src/Tests/Samples.cs#L20-L25' title='Snippet source file'>snippet source</a> | <a href='#snippet-rawfiles' title='Start of snippet'>anchor</a></sup>
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
<sup><a href='/src/Tests/Samples.cs#L88-L109' title='Snippet source file'>snippet source</a> | <a href='#snippet-custom-options' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


## Icon

[Pan Flute](https://thenounproject.com/term/pan+flute/1526666/) designed by [Creaticca Creative Agency](https://thenounproject.com/creaticca/) from [The Noun Project](https://thenounproject.com/).
