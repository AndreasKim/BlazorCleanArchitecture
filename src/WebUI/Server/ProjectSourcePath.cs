namespace BlazorCA.Server;

using System.Runtime.CompilerServices;

internal static class ProjectSourcePath
{
    private const string relativeFilePath = nameof(ProjectSourcePath) + ".cs";

    private static string? projectPath;
    public static string Value => projectPath ??= calculatePath();

    private static string GetSourceFilePathName([CallerFilePath] string? callerFilePath = null) 
        => callerFilePath ?? "";

    private static string calculatePath()
    {
        string pathName = GetSourceFilePathName();

        return pathName[..^relativeFilePath.Length];
    }
}
