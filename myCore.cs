// See https://aka.ms/new-console-template for more information

using jomiunsExtensions;

internal class myCore(string[] theArgs) : core_ddir.theCoreLogic(theArgs)
{
    public override IEnumerable<string>? GetAllThePathFileName(int theLimit, string? parFormat, bool fileNameOnly, string theDir, string? searchPattern, SearchOption searchOption)
    {
        var theDirInfo = new DirectoryInfo(theDir);
        var theFiles = theDirInfo.EnumerateFiles(searchPattern, searchOption).Select(oo =>
        {
            var itemString = fileNameOnly ? oo.Name : oo.FullName;
            if (parFormat.isNullOrEmpty())
                return itemString;

            itemString = parFormat
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

        var theDirs = theDirInfo.EnumerateDirectories(searchPattern, searchOption).Select(oo => fileNameOnly ? oo.Name : oo.FullName);
        var theAll = theFiles.Concat(theDirs);

        if (theAll != null && theLimit != null)
            theAll = theAll.Take(theLimit);
        return theAll;
    }
}
