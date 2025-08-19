// See https://aka.ms/new-console-template for more information
using netCoreHelper;


var something = new Kobra(args);
var theLimit = null as int?;
var curDir = Environment.CurrentDirectory;
var parLimit = something.registerCommand("limit", "Set the limit of items to display", 50);
var parPattern = something.registerCommand<string?>("pattern", "Set the pattern to filter files and directories");
var parPrefix = something.registerCommand<string?>("prefix", "Set the prefix for each item", "");
var parSuffix = something.registerCommand<string?>("suffix", "Set the suffix for each item", "");
var parPath = something.registerCommand<string?>("path", "Set the path to search in", curDir);
var parFormat = something.registerCommand<string?>("format", "lakukan format untuk nanti outputnya", "$item");
var fileNameOnly = something.registerCommand<bool>("fileNameOnly", "Set to true to display only file names without paths");
var parIsDeep = something.registerCommand<bool>("deep", "Set to true to search recursively");
var parHeader = something.registerCommand<string?>("header", "Set the header for the output", null);

if (something.start() == false)
    return;

if (parLimit.isExists)
    theLimit = parLimit.theResult;

if (parPath.isExists)
    curDir = parPath.theResult ?? $"{parPath.defaultValue}";

var theDir = new DirectoryInfo(curDir);
var theAll = null as IEnumerable<string>;
var searchPattern = "*.*";
var searchOption = SearchOption.TopDirectoryOnly;

if (parPattern.isExists)
    searchPattern = parPattern.theResult;

if (parIsDeep.isExists)
    searchOption = SearchOption.AllDirectories;

var theFiles = theDir.EnumerateFiles(searchPattern, searchOption).Select(oo =>
{
    var itemString = fileNameOnly.isExists ? oo.Name : oo.FullName;
    if (parFormat.isExists == false)
        return itemString;

itemString = parFormat.theResult
    .Replace("$item", itemString)
    .Replace("$name", oo.Name)
    .Replace("$fullName", oo.FullName)
    .Replace("$extension", oo.Extension)
    .Replace("$directory", oo.DirectoryName ?? "")
    .Replace("$size", oo.Length.ToString())
    .Replace("$created", oo.CreationTime.ToString("o"))
    .Replace("$modified", oo.LastWriteTime.ToString("o"))
    .Replace("$accessed", oo.LastAccessTime.ToString("o"))
    .Replace(@"\n", Environment.NewLine);
    return itemString;
});

var theDirs = theDir.EnumerateDirectories(searchPattern, searchOption).Select(oo => fileNameOnly.isExists ? oo.Name : oo.FullName);
theAll = theFiles.Concat(theDirs);

if (theAll != null && theLimit != null)
    theAll = theAll.Take(theLimit.Value);


var finale = new List<string>();
if (parHeader.isExists)
    finale.Add(parHeader.theResult ?? $"{parHeader.defaultValue}");

if (theAll != null)
    finale.AddRange(theAll.Select(oo => ($"{parPrefix.theResult}{oo}{parSuffix.theResult}").Replace("''", @"""")));

if (finale != null)
{
    var yeah = string.Join(Environment.NewLine, finale);
    Console.WriteLine(yeah);
}
