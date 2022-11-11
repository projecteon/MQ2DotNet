# MQ2DotNet

## Setup
Add MQ2DotNet to your Macroquest build.

```
git submodule add -b master-mqnext -f https://github.com/projecteon/MQ2DotNet.git plugins/mq2dotnet
```

Add `MQ2DotNetLoader` to the plugins directory in the Macroquest solution.

![MQ2DotNetLoader](/images/mq2dotnetloader.png)


Add `MQ2DotNet` to the resources directory in the Macroquest solution.

![MQ2DotNetLoader](/images/resources.png)


Add `program` plugins to the `MQ2DotNet` directory.

![MQ2DotNetLoader](/images/macros.png)

### Debugging
For debugging MQ2DotNet, enable mixed mode in project settings for `Macroquest`and `MQ2Main`.
 This will enable the debugger to attach to `eqgame.exe` for the MQ2DotNet project.

Open the `MQ2DotNet.sln` and attach to debug managed code.

![Project Settings](/images/projectsettings.png)

:warning: If you want to debug `Macroquest`c++ source, you have two options. (you wont be able to debug managed and unmanged at the same time)

* Disable the MQ2DotNetLoader. Seems visual studio struggles loading symbols while `dotnet` is loaded.
* Change default `Attach too` option when attaching to `eqgame.exe` from `automatic` to `native`

![Project Settings](/images/native_debugging.png)



##  Programs

### Create a new
```
dotnet new install .\
dotnet new mq2dotnet_program --dry-run --name TestTemplate --output TestTemplate
```

```csharp
using System.Threading.Tasks;
using MQ2DotNet.MQ2API;

namespace MyNamespace
{
    public class MyProgram
    {
        public static async Task Main(string[] args)
        {
            MQ2.WriteChat("Hello " + TLO.Me.Name);
        }
    }
}
```

I'm not going to give a C# tutorial here, but hopefully, with the possible exception of the "async Task" bit, this isn't too scary (more on this later). It's pretty similar to a standard C# hello world application (https://docs.microsoft.com/en-us/do...side-a-program/hello-world-your-first-program). The Main method is the only thing that matters, the rest is boilerplate (and I'll leave it out of future examples for brevity). To compile it, you'll need to create a new C# class library application, and add a reference to MQ2DotNet.dll.

To run it, put your compiled dll, along with the two attached ones, in your Release directory. You'll first need to bootstrap the .NET runtime, this is easy enough:

```csharp
/plugin mq2dotnetloader
```

This is just a plain old plugin, it loads the .NET runtime, and from the it also loads MQ2DotNet which is where the good stuff happens. To run your newly created program, assuming your dll is called MyProgram:

```csharp
/netrun MyProgram
```


That's it! If all goes according to plan, you should see "Hello <name>" printed in your chat window. In place of the MQ2.WriteChat function, you could have instead used:

```csharp
MQ2.DoCommand("/echo Hello " + TLO.Me.Name);
```


The TLO object provides access to the exact same things that macro variables do. For example:

```csharp
MQ2.WriteChat("There's " + TLO.SpawnCount["npc radius 500"].ToString() + " NPCs near me");
// or with string interpolation:
MQ2.WriteChat($"There's {TLO.SpawnCount["npc radius 500"]} NPCs near me");
```


Everything is strongly typed, and you can store things in a variable instead of accessing the whole thing each time:

```csharp
SpawnType spawn = TLO.NearestSpawn["npc radius 500"];
MQ2.WriteChat($"There's a level {spawn.Level} {spawn.Name} near me");
```


This last snippet could throw a null reference exception if there are no NPCs near you, but fear not, because that will be caught! If not by you in your own try catch block, MQ2DotNet will clean up your mess and write an error to your chat window instead of crashing to the desktop &#128578;

The args variable contains whatever parameters you passed when you did the /netrun, and you don't even have to use "this GetArg shit":

```csharp
	public static async Task Main(string[] args)
	{
		foreach (string arg in args)
			MQ2.WriteChat($"Hello {arg}");
	}
```


But what if we want to delay? For example do something, wait for a result, then do something else? Enter the await keyword, allowed because our method is declared as async:

```csharp
	public static async Task Main(string[] args)
	{
		MQ2.WriteChat("This executes straight away");
		await Task.Delay(5000); // 5000 millisecond delay
		MQ2.WriteChat("This executes 5 seconds later, still from the main thread!");
	}
```


This will, in effect, split the method into two parts. Once the compiler's done with it the end result looks something like:

```csharp
	public static void Main(string[] args)
	{
		MQ2.WriteChat("This executes straight away");
		Magical_CompilerGenerated_Method_That_Tells_OnPulse_To_Call_RestOfMethod_In_5_Seconds();
	}

	public static void RestOfMethod()
	{
		MQ2.WriteChat("This executes 5 seconds later, still from the main thread!");
	}
```



This of course is entirely transparent to you and you don't need to worry about it. All your variables are still available after the await, so you could do something like:


```csharp
	public static async Task Main(string[] args)
	{
		var startingExp = TLO.Me.PctExp;
		await Task.Delay(300000);
		MQ2.WriteChat($"I've gained {TLO.Me.PctExp - startingExp} in the last 5 minutes");
	}
```


You can await a certain amount of time, as in the examples above, or just for the next frame:

```csharp
	public static async Task Main(string[] args)
	{
		MQ2.WriteChat("This executes straight away");
		await Task.Yield(); // Delay until the next frame
		MQ2.WriteChat("This executes next frame, still from the main thread!");

	}
```


You can also await another function of your own making, provided it is declared async as well:

```csharp
	public static async Task Main(string[] args)
	{
		foreach (var spellName in args)
			await CastSpell(spellName);
	}

	public static async Task CastSpell(string spell)
	{
		MQ2.WriteChat($"Casting {spell}");
		MQ2.DoCommand($"/casting \"{spell}\" -maxtries|3");

		while (TLO.Cast.Status == "C" || TLO.Me.SpellInCooldown) // Wait for MQ2Cast + GCD to both finish
			await Task.Yield();

		MQ2.WriteChat($"Cast result: {TLO.Cast.Result}");
	}
```


This would cast each spell in sequence, e.g.

```csharp
/netrun myprogram "Claw of Qunard" "Ethereal Skyfire" "Shocking Vortex"
```


If you want to stop if halfway through, you can:

```csharp
/netend *
```


This will stop all programs you have started using /netrun. Did I mention you can run as many as you want at the same time? You can also stop just one with:

```csharp
/netend myprogram
```


At this point you might be thinking this is very similar to writing a macro, and that's the intention. If you've come from working in another programming language and found the macro language lacking (basic stuff like proper arrays, lists, for each iterators), give this a try!

A word of warning, if you don't await either in your command, it will never pass control back to EQ to continue running. So something like this is a bad idea:

```csharp
	public static async Task Main(string[] args)
	{
		MQ2.DoCommand("/casting \"Claw of Qunard\" -maxtries|3");
		while (TLO.Cast.Status == "C" || TLO.Me.SpellInCooldown)
		{
			// This will hang, control never gets passed back to EQ
		}
	}
```


Visual studio intellisense will show you a warning if you do this, pay attention to it! This includes any async functions of your own creation, eventually something needs to call a function that actually relinquishes control, e.g. Task.Yield or Task.Delay.

Plugins

If you want to write a regular old plugin, not just a "program", you can do that too, just have a class that inherits Plugin:

```csharp
namespace MyPlugin
{
    public class MyPlugin : Plugin
    {
        public override void InitializePlugin()
        {
            Commands.AddCommand("/stuff", DoStuff);
            Commands.AddAsyncCommand("/slowstuff", DoSlowStuff);
        }
        public override void ShutdownPlugin()
        {
            Commands.RemoveCommand("/slowstuff");
            Commands.RemoveCommand("/stuff");
        }
        private void DoStuff(string[] args)
        {
            // The same as a regular plugin command
        }
        private async Task DoSlowStuff(string[] args)
        {
            // The same as a program you'd run with /netrun
        }
    }
}
```


This goes in a class library that references MQ2DotNet.dll, same as above. There's no need to have a Main() method in there, just a class that inherits from Plugin. Copy the resulting dll to your Release folder, and load/unload with:

```csharp
/netplugin myplugin
/netplugin myplugin noauto
/netplugin myplugin unload
/netplugin myplugin unload noauto
```


Just like you would for a normal plugin. The list of plugins to be loaded automatically is stored in MQ2DotNet.ini.

All the regular plugin callbacks are there, go start typing stuff with visual studio intellisense, it'll sort you out. No support for creation of your own TLOs or MQ2Types from .NET, while possible it's not on my list at the moment.

More information at [RedGuides-MQ2DotNet](https://www.redguides.com/community/resources/mq2dotnet.1209/)