
namespace OTPEntry
{
  public class EntryEventArgs(string enteredCode) : EventArgs
  {
    public string EnteredCode { get; } = enteredCode;
  }
}