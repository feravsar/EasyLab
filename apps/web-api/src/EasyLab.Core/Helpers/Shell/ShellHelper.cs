using System;
using System.Web;
using System.Diagnostics;
using System.Threading.Tasks;
using EasyLab.Core.Dto.GatewayResponses;
using System.IO;

public static class ShellHelper
{
    public static Task<BashResponse> Bash(this string cmd)
    {
  
        var source = new TaskCompletionSource<BashResponse>();
        BashResponse response = new BashResponse();
        var escapedArgs = cmd.Replace("\"", "\\\"");


        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "bash",
                Arguments = $"-c \"{escapedArgs}\"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            },
            EnableRaisingEvents = true
        };


        process.Exited += (sender, args) =>
        {
            response.Error = process.StandardError.ReadToEnd();
            response.Output = process.StandardOutput.ReadToEnd();

            if (process.ExitCode == 0)
            {
                response.success = true;
                source.SetResult(response);
            }
            else
            {
                source.SetException(new Exception($"Command `{cmd}` failed with exit code `{process.ExitCode}`" + response.Error));
            }
            process.Dispose();
        };

        try
        {
            process.Start();
            process.WaitForExit(1000 * 10);
        }
        catch (Exception e)
        {
            source.SetException(e);
        }
        return source.Task;
    }
}