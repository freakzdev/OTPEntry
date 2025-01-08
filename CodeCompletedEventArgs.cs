
namespace OTPEntry
{
  public class CodeCompletedEventArgs(string enteredCode) : EventArgs
  {
    public string EnteredCode { get; } = enteredCode;
  }
}