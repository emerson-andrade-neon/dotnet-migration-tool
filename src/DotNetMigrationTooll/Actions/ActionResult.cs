﻿using System.Diagnostics;

namespace DotNetMigrationTooll.Actions;

public record ActionResult(int ErrorCode, string Message)
{
    public bool IsSuccess => ErrorCode == 0;
    public static async Task<ActionResult> CreateByProcessResult(Process process, int otherSuccessCode = 0)
    {
        var output = await process.StandardOutput.ReadToEndAsync();
        var error = await process.StandardError.ReadToEndAsync();
        await process.WaitForExitAsync();

        var separator = !string.IsNullOrEmpty(output) && !string.IsNullOrEmpty(error) ? Environment.NewLine : null;
        var message = $"{output}{separator}{error}";

        var code = process.ExitCode == 0 || process.ExitCode == otherSuccessCode ? 0 : process.ExitCode;

        return new(code, message);
    }
}


