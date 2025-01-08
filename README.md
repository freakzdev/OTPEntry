# OTPEntry

OTPEntry is a .NET MAUI library for creating One-Time Password (OTP) entry controls. This library supports alphanumeric and numeric OTP entries and provides a customizable user interface.

## Features

- Supports alphanumeric and numeric OTP entries
- Customizable entry length
- Haptic feedback on code completion
- Easy integration with .NET MAUI projects

## Installation

To install OTPEntry, add the following package reference to your project file:

```xml
<PackageReference Include="Microsoft.Maui.Controls" Version="$(MauiVersion)" />
```

## Version

Current version: 1.0.0

## Usage

Here is an example of how to use OTPEntry in your .NET MAUI project:

### C# Implementation

```csharp
using OTPEntry;

namespace YourNamespace
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var otpEntry = new OTPEntry.Entry
            {
                Length = 6,
                Type = OTPEntry.Type.Numeric
            };

            otpEntry.CodeCompleted += (sender, e) =>
            {
                DisplayAlert("OTP Code", $"Entered Code: {e.Code}", "OK");
            };

            Content = otpEntry;
        }
    }
}
```

### XAML Implementation

```xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:otp="clr-namespace:OTPEntry;assembly=OTPEntry"
             x:Class="YourNamespace.MainPage">

    <StackLayout Padding="20">
        <Label Text="Enter OTP Code"
               FontSize="Medium"
               HorizontalOptions="Center"
               VerticalOptions="CenterAndExpand" />

        <otp:Entry Length="6"
                   Type="Numeric"
                   CodeCompleted="OnCodeCompleted"
                   HorizontalOptions="Center"
                   VerticalOptions="CenterAndExpand" />
    </StackLayout>
</ContentPage>
```

```csharp
using System;
using Microsoft.Maui.Controls;
using OTPEntry;

namespace YourNamespace
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCodeCompleted(object sender, EntryEventArgs e)
        {
            var mainPage = Application.Current?.Windows[0]?.Page;
            if (mainPage != null)
            {
                mainPage.DisplayAlert("OTP Code", $"Entered Code: {e.Code}", "OK");
            }
        }
    }
}
```

## License

This project is licensed under the MIT License. See the LICENSE file for more details.

## Contact

For any questions or support, please contact rvb@freakz.dev. OTPEntry

OTPEntry is a .NET MAUI library for creating One-Time Password (OTP) entry controls. This library supports alphanumeric and numeric OTP entries and provides a customizable user interface.

## Features

- Supports alphanumeric and numeric OTP entries
- Customizable entry length
- Haptic feedback on code completion
- Easy integration with .NET MAUI projects

## Installation

To install OTPEntry, add the following package reference to your project file:

```xml
<PackageReference Include="Microsoft.Maui.Controls" Version="$(MauiVersion)" />
```

## Version

Current version: 1.0.0

## Usage

Here is an example of how to use OTPEntry in your .NET MAUI project:

- c# implementation:

```c#
using OTPEntry;

namespace YourNamespace
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var otpEntry = new OTPEntry.Entry
            {
                Length = 6,
                Type = OTPEntry.Type.Numeric
            };

            otpEntry.CodeCompleted += (sender, e) =>
            {
                DisplayAlert("OTP Code", $"Entered Code: {e.Code}", "OK");
            };

            Content = otpEntry;
        }
    }
}
```

- xmalL implementation

```xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:otp="clr-namespace:OTPEntry;assembly=OTPEntry"
             x:Class="YourNamespace.MainPage">

    <StackLayout Padding="20">
        <Label Text="Enter OTP Code"
               FontSize="Medium"
               HorizontalOptions="Center"
               VerticalOptions="CenterAndExpand" />

        <otp:Entry Length="6"
                   Type="Numeric"
                   CodeCompleted="OnCodeCompleted"
                   HorizontalOptions="Center"
                   VerticalOptions="CenterAndExpand" />
    </StackLayout>
</ContentPage>
```

```c#
using System;
using Microsoft.Maui.Controls;
using OTPEntry;

namespace YourNamespace
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCodeCompleted(object sender, EntryEventArgs e)
        {
            var mainPage = Application.Current?.Windows[0]?.Page;
            if (mainPage != null)
            {
                mainPage.DisplayAlert("OTP Code", $"Entered Code: {e.Code}", "OK");
            }
        }
    }
}
```

## License

This project is licensed under the MIT License. See the LICENSE file for more details.

## Contact

For any questions or support, please contact rvb@freakz.dev.
