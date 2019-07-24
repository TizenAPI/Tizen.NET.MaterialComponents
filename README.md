# Tizen.NET.MaterialComponents  [![NuGet](https://img.shields.io/nuget/v/Tizen.NET.MaterialComponents.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Tizen.NET.MaterialComponents/)

Material Components for Tizen .NET help developers execute [Material Design](https://material.io). 

## Components

- **MActivityIndicator**
  A circular progress indicator that supports determinate and indeterminate circular progress indicators. ([guideline](https://material.io/design/components/progress-indicators.html#circular-progress-indicators))

- **MAppbar**
  Top : A top app bar displays information and actions relating to the current screen.  ([guideline](https://material.io/design/components/app-bars-top.html))
  Bottom : A bottom app bar displays navigation and key actions at the bottom of current screens.  ([guideline](https://material.io/design/components/app-bars-bottom.html))

- **MConformant**
  A material conformant allows the user to use a floating action button.

- **MBottomNavigation**
  A Navigation bar display three to five destinations at the bottom of a screen. ([guideline](https://material.io/design/components/bottom-navigation.html))

- **MButton**
  A material buttons, including contained button, text button, outlined button and toggle button. ([guideline](https://material.io/design/components/buttons.html)) 

- **MCard**
  A cards contain content about a single subject. ([guideline](https://material.io/design/components/cards.html))

- **MCheckBox**
  A material checkbox allow the user to select one or more items from a set. ([guideline](https://material.io/design/components/selection-controls.html#checkboxes))

- **MAlertDialog**
  A alert dialogs interrupt users with urgent information, details, or actions.([guideline](https://material.io/design/components/dialogs.html#alert-dialog))

- **MSimpleDialog**
  A simple dialogs display items that are immediately actionable when selected.([guideline](https://material.io/design/components/dialogs.html#simple-dialog))

- **MConfirmationDialog**
  A confirmation dialogs give users the ability to provide final confirmation of a choice before committing to it.([guideline](https://material.io/design/components/dialogs.html#confirmation-dialog))

- **MFullScreenDialog**
  A full-screen dialogs group a series of tasks.([guideline](https://material.io/design/components/dialogs.html#full-screen-dialog))

- **MMenus**
  A material menus display a list of choices on temporary surfaces. ([guideline](https://material.io/design/components/menus.html))

- **MModalSheets**
  Modal bottom sheets present a set of choices while blocking interaction with the rest of the screen. ([guideline](https://material.io/design/components/sheets-bottom.html#modal-bottom-sheet))
  Modal side sheets present content while blocking interaction with the rest of the screen. ([guideline](https://material.io/design/components/sheets-side.html#modal-side-sheet))

- **MFloatingActionButton**
  A material floating action button represents the primary action of a screen. ([guideline](https://material.io/design/components/buttons-floating-action-button.html))

- **MNavigationDrawer**
  A Navigation drawers provide access to destinations and app functionality, such as switching accounts. ([guideline](https://material.io/design/components/navigation-drawer.html))

- **MProgressIndicator**
  A linear progress indicator that supports determinate and indeterminate linear progress indicators. ([guideline](https://material.io/design/components/progress-indicators.html#linear-progress-indicators))

- **MRadioButton**
  A material radio button allow the user to select one option from a set. ([guideline](https://material.io/design/components/selection-controls.html#radio-buttons))

- **MSlider**
  A material slider for selecting from a range of values. ([guideline](https://material.io/design/components/sliders.html))

- **MSnackbar**
  A material snackbars provide brief messages about app processes. ([guideline](https://material.io/design/components/snackbars.html))

- **MSwitch**
  A material switch toggle the state of a single setting on or off. ([guideline](https://material.io/design/components/selection-controls.html#switches))

- **MTab**
  A material tab bar that supports fixed tabs and scrollable tabs for switching between groups of content. ([guideline](https://material.io/design/components/tabs.html))
  
- **MTextField**
  A material text fields that supports filled text fields and outlined text fields. ([guideline](https://material.io/design/components/text-fields.html))  

- **MTooltip**
  A material Tooltips display informative text when users focus on, tap or long press an element. ([guideline](https://material.io/design/components/tooltips.html))
 
## Getting Started
### Install package 
#### nuget.exe
```
nuget.exe install Tizen.NET.MaterialComponents -Version 0.9.7-preview
```
#### .csproj
```xml
<PackageReference Include="Tizen.NET.MaterialComponents" Version="0.9.7-preview" />
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

