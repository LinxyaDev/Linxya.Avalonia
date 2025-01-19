# Easy to create a desktop application (for Linux/Windows/macos)

Inspired from [NXUI](https://github.com/wieslawsoltes/NXUI): 
"*Creating minimal [Avalonia](https://avaloniaui.net/) next generation (NXUI, next-gen UI) application using C# 10 and .NET 8*"

How to easy create a desktop app?
Here is an example:
```csharp
int count = 0;

App.Start(CreateMainWindow, [], ThemeVariant.Dark);
// App.Build(CreerFenetre).Start();

Window CreateMainWindow()
{
  TextBox textBox1 = new TextBox();
  TextBox textBox2 = new TextBox();

  Label label = new Label();
  label.Content = "Hello, world!";

  Button button = new Button();
  button.Content = "Welcome to Avalonia, please click me!";
  button.Click += ButtonClick;

  StackPanel stackPanel = new StackPanel();
  stackPanel.Children.AddRange([button, textBox1, textBox2, label]);

  Window window =  new Window();
  window.Content = stackPanel;
  window.Title = "Test";
  window.Width = 400;
  window.Height = 300;
  return window;
}

void ButtonClick(object? sender, EventArgs e)
{
    if (sender is Button button) {
      button.Content = "You cliked " + ++count + " times";
    }
}
```

