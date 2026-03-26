using System.Reflection;

[TestFixture]
public class FormatTests
{
    static readonly MethodInfo convertToText = typeof(PandocInstance)
        .GetMethods()
        .First(m =>
            m.Name == "ConvertToText" &&
            m.GetParameters()[0].ParameterType == typeof(string));

    static IEnumerable<Type> OutputFormats() =>
        typeof(OutOptions).Assembly
            .GetTypes()
            .Where(t => t is { IsAbstract: false, IsClass: true } &&
                        t.IsSubclassOf(typeof(OutOptions)))
            .OrderBy(t => t.Name);

    static IEnumerable<Type> InputFormats() =>
        typeof(InOptions).Assembly
            .GetTypes()
            .Where(t => t is { IsAbstract: false, IsClass: true } &&
                        t.IsSubclassOf(typeof(InOptions)))
            .OrderBy(t => t.Name);

    [TestCaseSource(nameof(OutputFormats))]
    public async Task ConvertToOutput(Type outputType)
    {
        if (outputType == typeof(PdfOut))
        {
            Assert.Ignore("Requires PDF engine");
            return;
        }

        var method = convertToText.MakeGenericMethod(typeof(CommonMarkIn), outputType);
        var task = (Task<StringResult>) method.Invoke(null, ["*text*", null, null, null, default(CancellationToken)])!;
        await task;
    }

    [TestCaseSource(nameof(InputFormats))]
    public async Task ConvertFromInput(Type inputType)
    {
        if (inputType == typeof(DocxIn) ||
            inputType == typeof(PptxIn) ||
            inputType == typeof(EpubIn) ||
            inputType == typeof(OdtIn) ||
            inputType == typeof(XlsxIn))
        {
            Assert.Ignore("Requires binary file input");
            return;
        }

        if (inputType == typeof(CslJsonIn) ||
            inputType == typeof(EndNoteXmlIn) ||
            inputType == typeof(Fib2In) ||
            inputType == typeof(HaskellIn) ||
            inputType == typeof(JsonIn) ||
            inputType == typeof(JupyterIn) ||
            inputType == typeof(RisIn) ||
            inputType == typeof(XmlIn))
        {
            Assert.Ignore("Requires structured input");
            return;
        }

        var method = convertToText.MakeGenericMethod(inputType, typeof(TxtOut));
        var task = (Task<StringResult>) method.Invoke(null, ["text", null, null, null, default(CancellationToken)])!;
        await task;
    }
}
