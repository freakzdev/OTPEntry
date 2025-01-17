namespace FreakzDEV.OTPEntry
{
  // Class representing event arguments for OTP entry
  public class OTPEntryEventArgs(string Code) : EventArgs
  {
    // Property containing the entered code
    public string Code { get; } = Code ?? string.Empty;
  }
}