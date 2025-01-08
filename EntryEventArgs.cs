
namespace OTPEntry
{
  public class EntryEventArgs(string Code) : EventArgs
  {
    public string Code { get; } = Code;
  }
}