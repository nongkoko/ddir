// See https://aka.ms/new-console-template for more information
using jomiunsExtensions;

var satuCommandPanjang = string.Join(" ", args);
var leItems = satuCommandPanjang.Split("--").Select(oo=>oo.Trim()).ToArray();
var thePath = leItems[0];
int? toLimit = null;
var thePattern = "";
var thePrefix = "";
var theSuffix = "";
var header = "";

foreach (var aCommand in leItems)
{
    if (aCommand.StartsWith("limit"))
    {
        var infos = aCommand.Split(' ', 2);
        toLimit = int.Parse(infos[1]);
    }

    if (aCommand.StartsWith("header"))
    {
        var infos = aCommand.Split(' ', 2);
        header = infos[1];
    }

    if (aCommand.StartsWith("pattern"))
    {
        var infos = aCommand.Split(' ', 2);
        thePattern = infos[1].Trim();
    }

    if (aCommand.StartsWith("prefix"))
    {
        var infos = aCommand.Split(' ', 2);
        thePrefix = infos[1];
    }

    if (aCommand.StartsWith("suffix"))
    {
        var infos = aCommand.Split(' ', 2);
        theSuffix = infos[1];
    }
}

string? curDir = Environment.CurrentDirectory;
if (thePath.isNullOrEmpty())
    curDir = Environment.CurrentDirectory;

if (thePath.isNotNullOrEmpty())
    curDir = thePath;

var theDir = new DirectoryInfo(curDir);
IEnumerable<FileInfo>? theAll = null;

if (thePattern.isNullOrEmpty())
    theAll = theDir.EnumerateFiles();

if (thePattern.isNotNullOrEmpty())
    theAll = theDir.GetFiles(thePattern);

if (toLimit != null && theAll != null)
    theAll = theAll.Take(toLimit.Value);

var finale = new List<string>();
if (header.isNotNullOrEmpty())
    finale.Add(header);

if (theAll != null)
{
    finale.AddRange(theAll.Select(oo => (thePrefix + oo + theSuffix).Replace("''",@"""")));
}

if (finale != null)
{
    var yeah = string.Join(Environment.NewLine, finale);
    Console.WriteLine(yeah);
}
