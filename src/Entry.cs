using System.Diagnostics;
using System.Windows.Input;
using CommunityToolkit.Maui.Behaviors;

namespace FreakzDEV.OTPEntry
{
  public class Entry : StackLayout
  {
    // Length Bindable Property
    public static readonly BindableProperty LengthProperty = BindableProperty.Create(
        nameof(Length),
        typeof(int),
        typeof(Entry),
        6,
        propertyChanged: OnPropertyChanged
    );

    public int Length
    {
      get => (int)GetValue(LengthProperty);
      set => SetValue(LengthProperty, value);
    }

    // Type Bindable Property
    public static readonly BindableProperty TypeProperty = BindableProperty.Create(
        nameof(Type),
        typeof(OTPEntryType),
        typeof(Entry),
        OTPEntryType.Numeric,
        propertyChanged: OnPropertyChanged
    );

    public OTPEntryType Type
    {
      get => (OTPEntryType)GetValue(TypeProperty);
      set => SetValue(TypeProperty, value);
    }

    // IsPassword Bindable Property
    public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create(
        nameof(IsPassword),
        typeof(bool),
        typeof(Entry),
        false,
        propertyChanged: OnPropertyChanged
    );

    public bool IsPassword
    {
      get => (bool)GetValue(IsPasswordProperty);
      set => SetValue(IsPasswordProperty, value);
    }

    private static void OnPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
      var control = (Entry)bindable;
      control.Build();
    }

    // Entered otp property
    public string OTP { get; private set; } = string.Empty;

    // Unfocus method
    public new void Unfocus()
    {
      foreach (var child in Children)
      {
        if (child is Microsoft.Maui.Controls.Entry entry)
        {
          entry.Unfocus();
        }
      }
    }

    // Focus method
    public new void Focus()
    {
      if (Children.Count > 0 && Children[0] is Microsoft.Maui.Controls.Entry firstEntry)
      {
        firstEntry.Focus();
      }
    }

    // Clear method
    public new void Clear()
    {
      foreach (var child in Children)
      {
        if (child is Microsoft.Maui.Controls.Entry entry)
        {
          entry.Text = string.Empty;
        }
      }
      OTP = string.Empty;
    }

    // OTP Completed Event
    public event EventHandler<OTPEntryEventArgs> OTPCompleted = delegate { };

    // Bindable Command Property
    public static readonly BindableProperty CommandProperty = BindableProperty.Create(
        nameof(Command),
        typeof(ICommand),
        typeof(Entry)
    );

    public ICommand Command
    {
      get => (ICommand)GetValue(CommandProperty);
      set => SetValue(CommandProperty, value);
    }

    // Class constructor
    public Entry()
    {
      Orientation = StackOrientation.Horizontal;
      HorizontalOptions = LayoutOptions.Center;
      VerticalOptions = LayoutOptions.Center;
      Build();
    }

    // Component builder
    private void Build()
    {
      Children.Clear();

      var entries = new Microsoft.Maui.Controls.Entry[Length];
      for (int i = 0; i < Length; i++)
      {
        var entry = CreateEntry(i, entries);

        entry.Behaviors.Add(new SelectAllTextBehavior());

        entries[i] = entry;
        Children.Add(entry);
      }
    }

    // Helper method to create Entry controls
    private Microsoft.Maui.Controls.Entry CreateEntry(int index, Microsoft.Maui.Controls.Entry[] entries)
    {
      var entry = new Microsoft.Maui.Controls.Entry
      {
        VerticalOptions = LayoutOptions.Fill,
        VerticalTextAlignment = TextAlignment.Center,
        HorizontalOptions = LayoutOptions.Fill,
        HorizontalTextAlignment = TextAlignment.Center,
        IsTextPredictionEnabled = false,
        IsSpellCheckEnabled = false,
        MaxLength = 1,
        BackgroundColor = Colors.White,
        Margin = new Thickness(1, 0, 1, 0),
        TextTransform = TextTransform.None,
        Keyboard = Type == OTPEntryType.Numeric ? Keyboard.Numeric : Keyboard.Default,
        IsPassword = IsPassword,
        FontSize = IsPassword ? 24 : 20
      };

      int nextIndex = index + 1;
      int lastIndex = index - 1;

      entry.TextChanged += (sender, e) =>
      {
        if (e.NewTextValue.Length == 1)
        {
          OTPSerializer(entries, nextIndex);
        }
        else if (string.IsNullOrEmpty(e.NewTextValue) && lastIndex >= 0)
        {
          entries[lastIndex].Focus();
        }
      };

      return entry;
    }

    // OTP Serializer
    private void OTPSerializer(Microsoft.Maui.Controls.Entry[] entries, int nextIndex)
    {

      if (nextIndex == Length)
      {
        entries[nextIndex - 1].Unfocus();

        OTP = string.Concat(entries.Select(e => e.Text));
        var args = new OTPEntryEventArgs(OTP);

        // Trigger the OTPCompleted event when the otp property is fully entered
        OTPCompleted?.Invoke(this, args);

        // Execute the bindable command if defined
        if (Command?.CanExecute(args) == true)
        {
          Command.Execute(args);
        }
        HapticFeedback.Perform(HapticFeedbackType.LongPress);
      }
      else
      {
        // Focus the next entry
        if (nextIndex < Length)
        {
          entries[nextIndex].Focus();
          HapticFeedback.Perform(HapticFeedbackType.Click);
        }
      }
    }
  }
}
