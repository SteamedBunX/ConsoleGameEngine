ConsoleGameEngine is a C# library that uses Colorful.Console nuget package, to help anyone with create a simple and interactive graphical interface inside a Console application.

![Main Menu](https://github.com/SteamedBunX/ConsoleGameEngine/blob/master/MainMenu.PNG)

I will be preparing for a NuGet Package in the future If I feel comfortable enough to call this V1.0
Current Avaliable Features:
1. `FreeString` 
  You can print this with w/e the color you want, at any position you want onto the screen.
2. `FreeStringBundle`
  A Class Simular to the FreeString, But can have multiple lines.
3. `Menu`
  A functional menu that is easy to use. You can attack delegates to the `MenuItems`'s `select` `intofocus`, and `outoffocus`.
4. `Image`
  You can load Specially Formated `.ci` into image files, and then print them onto the screen.
5. `Canvas`
  You can print multiple `Images` onto `Canvas`, and then print it to the screen. `Image`'s position will be relative to `Canvas`, only the pixel within `Canvas` will be printed, and you can have transparent pixels when Loading `Image` onto `Canvas`. Now that `Canvas` will override the entire space that is allocated to it.
6. `Number`
  A number which you can select which digit to go up and down.
  
I will not be updating this for a while as I have a few more importent things to work in. However once I'm done with my current stuff and find some time I will continue to update this until I feel it's good to release. 
Also I do hope the new Windows terminal will not make this useless.
Currently planned next step:
Rework the Demo for better and cleanner code. Also adding much better user interface for each of the function demos.
Adding `EnterCycle` for the menu and number, so that the user will no longer need to catch user input themself.
Once cycle is completed they will return corresponding values to represent the user's selection at the end.
