# OTPEntry

<div style="text-align: center; margin: 20px 0;">
    <img src="files/Sample.gif" alt="Animación del Proyecto" width="180" height="auto" style="border: 2px solid #4d4d4d80;">
</div>

OTPEntry is a .NET MAUI library for creating One-Time Password (OTP) entry controls. This library supports alphanumeric and numeric OTP entries and provides a customizable user interface.

## Features

- Supports alphanumeric and numeric OTP entries
- Customizable entry length
- Haptic feedback on code completion
- Easy integration with .NET MAUI projects

## Installation

To install Feedback, run the following command in the NuGet Package Manager Console:

```sh
Install-Package OTPEntry
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
                Debug.WriteLine($"Entered Code: {e.Code}");
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
               VerticalOptions="Center" />

        <otp:Entry Length="6"
                   Type="Numeric"
                   CodeCompleted="OnCodeCompleted"
                   HorizontalOptions="Center"
                   VerticalOptions="Center" />
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

        private void OnCodeCompleted(object sender, OTPEntryEventArgs e)
        {
            var mainPage = Application.Current?.Windows[0]?.Page;
            if (mainPage != null)
            {
                Debug.WriteLine($"Entered Code: {e.Code}");
            }
        }
    }
}
```

## License

This project is licensed under the MIT License. See the LICENSE file for more details.

## Contact

For any questions or feedback, please contact us at [support@freakz.dev](mailto:support@freakz.dev).
