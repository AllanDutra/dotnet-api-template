namespace Template.Core.Models.ViewModels;

public class DefaultResponseViewModel(IEnumerable<string> messages)
{
    public IEnumerable<string> Messages { get; } = messages;
}
