using System;

namespace Vsts.Cli
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            string currentDirectory = Environment.GetEnvironmentVariable("vsts-cli-directory") ?? System.IO.Directory.GetCurrentDirectory();
            GitConfiguration gitConfiguration = GitRepoHelpers.Create(currentDirectory);

            if (gitConfiguration.GitDirectory != null && gitConfiguration.NonVstsHost)
            {
                Console.WriteLine($"Found a non-VSTS git repo at {gitConfiguration.GitDirectory} pointing to {gitConfiguration.Origin}", ConsoleColor.Yellow);
                Environment.Exit(0);
            }

            if (string.IsNullOrWhiteSpace(gitConfiguration.Name) || string.IsNullOrWhiteSpace(gitConfiguration.Host))
            {
                Console.WriteLine($"Could not find an existing VSTS git repo in the current {gitConfiguration.CurrentDirectory} directory or parent directories", ConsoleColor.Yellow);
                Environment.Exit(0);
            }

            var vsts = new Vsts(gitConfiguration);
            var vstsProjectHelper = new VstsProjectHelper(vsts);

            vstsProjectHelper.CheckAccessToken();
            var vstsApiHelper = new VstsApiHelper(vsts.AccountUri, vsts.PersonalAccessToken);
            vstsProjectHelper.CheckRemoteProjectLink(vstsApiHelper);
            vstsProjectHelper.CheckLocalProjectLink(vstsApiHelper);

            var cli = new Cli(vsts, vstsApiHelper);
            var exitCode = cli.Execute(args);
            Environment.Exit(exitCode);
        }
    }
}
