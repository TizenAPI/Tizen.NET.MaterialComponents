# Tizen.NET.MaterialComponents  [![NuGet](https://img.shields.io/nuget/v/Tizen.NET.MaterialComponents.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Tizen.NET.MaterialComponents/)

Material Components for Tizen .NET help developers execute [Material Design](https://material.io). 

## Components

- **MButton**
  A material buttons, including contained button, text button, outlined button and toggle button. ([guideline](https://material.io/design/components/buttons.html)) 

- **MCard**
  A cards contain content about a single subject. ([guideline](https://material.io/design/components/cards.html))

- **MProgressIndicator**
  A linear progress indicator that supports determinate and indeterminate linear progress indicators. ([guideline](https://material.io/design/components/progress-indicators.html#linear-progress-indicators))
  
- **MSlider**
  A material slider for selecting from a range of values. ([guideline](https://material.io/design/components/sliders.htmlhttps://material.io/design/components/sliders.html))
  
- **MTab**
  A material tab bar that supports fixed tabs and scrollable tabs for switching between groups of content. ([guideline](https://material.io/design/components/tabs.html))
 
## Getting Started
### Install package 
#### nuget.exe
```
nuget.exe install Tizen.NET.MaterialComponents -Version 0.9.0-preview
```
#### .csproj
```xml
<PackageReference Include="Tizen.NET.MaterialComponents" Version="0.9.0-preview" />
```
 
### How to use Tizen.NET Material Components
 In order to use Tizen.NET Material Components in your application, you MUST call `Tizen.NET.MaterialComponents.ThemeLoader.Init()` prior to using it.
  
 ```cs
 using Tizen.NET.MaterialComponents;
 
 protected override void OnCreate()
 {
     base.OnCreate();
     // Get your application resource directory
     ResourceDir = DirectoryInfo.Resource;
     
     // Initialze ThemeLoader
     ThemeLoader.Initialize(ResourceDir);
 }
 ```

