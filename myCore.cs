// See https://aka.ms/new-console-template for more information
using netCoreHelper;

internal class myCore(string[] theArgs) : core_ddir.theCoreLogic(theArgs)
{
    public override IEnumerable<string>? GetAllThePathFileName(int? theLimit, kommand<string?> parFormat, kommand<bool> fileNameOnly, DirectoryInfo theDir, string? searchPattern, SearchOption searchOption)
    {
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
        var theAll = theFiles.Concat(theDirs);

        if (theAll != null && theLimit != null)
            theAll = theAll.Take(theLimit.Value);
        return theAll;
    }
}
