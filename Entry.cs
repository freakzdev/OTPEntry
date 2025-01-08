namespace OTPEntry
{
  public class Entry : StackLayout
  {
    public static readonly BindableProperty LengthProperty =
        BindableProperty.Create(
            nameof(Length),
            typeof(int),
            typeof(Entry),
            6,
            propertyChanged: OnLengthChanged);

    public static readonly BindableProperty TypeProperty =
        BindableProperty.Create(
            nameof(EntryTypeEnum),
            typeof(EntryTypeEnum),
            typeof(Entry),
            EntryTypeEnum.Numeric,
            propertyChanged: OnTypeChanged);

    public int Length
    {
      get => (int)GetValue(LengthProperty);
      set => SetValue(LengthProperty, value);
    }

    public EntryTypeEnum Type
    {
      get => (EntryTypeEnum)GetValue(TypeProperty);
      set => SetValue(TypeProperty, value);
    }

    public string Code { get; private set; }

    public event EventHandler<EntryEventArgs> CodeCompleted = delegate { };
    public Entry()
    {
      Code = string.Empty;
      Orientation = StackOrientation.Horizontal;
      HorizontalOptions = LayoutOptions.Center;
      VerticalOptions = LayoutOptions.Center;
      CreateEntries();
    }

    private static void OnLengthChanged(BindableObject bindable, object oldValue, object newValue)
    {
      var control = (Entry)bindable;
      control.CreateEntries();
    }


    private static void OnTypeChanged(BindableObject bindable, object oldValue, object newValue)
    {
      var control = (Entry)bindable;
      control.CreateEntries();
    }

    private void CreateEntries()
    {
      Children.Clear();
      var entries = new Microsoft.Maui.Controls.Entry[Length];
      for (int i = 0; i < Length; i++)
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
          Keyboard = Type == EntryTypeEnum.Numeric ? Keyboard.Numeric : Keyboard.Plain
        };
        entries[i] = entry;
        Children.Add(entry);

        int nextIndex = i + 1;
        int lastIndex = i - 1;
        entry.TextChanged += (sender, e) =>
        {
          if (e.NewTextValue.Length == 1)
          {
            UpdateCode(entries, nextIndex);
          }
          else if (e.NewTextValue.Length < e.OldTextValue.Length)
          {
            if (lastIndex >= 0)
            {
              entries[lastIndex].Focus();
            }
          }
        };
      }
    }
    private void UpdateCode(Microsoft.Maui.Controls.Entry[] entries, int nextIndex)
    {
      Code = string.Concat(entries.Select(e => e.Text));
      if (Code.Length == Length)
      {
        HapticFeedback.Perform(HapticFeedbackType.Click);
        foreach (var entry in entries)
        {
          entry.Unfocus();
        }
        CodeCompleted?.Invoke(this, new EntryEventArgs(Code));
      }
      else
      {
        entries[nextIndex].Focus();
      }
    }
  }
}
