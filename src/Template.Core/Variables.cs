namespace Template.Core;

public class Variables
{
    public static class General
    {
        public static readonly string? Env = Environment.GetEnvironmentVariable(
            "ASPNETCORE_ENVIRONMENT"
        );
    }
}
