using System.Reflection;
using MelonLoader;

[assembly: AssemblyTitle(EmojiHotkey.Main.Name)]
[assembly: AssemblyDescription(EmojiHotkey.Main.Description)]
[assembly: AssemblyCompany(EmojiHotkey.Main.Company)]
[assembly: AssemblyProduct(EmojiHotkey.Main.Name)]
[assembly: AssemblyCopyright("Created by " + EmojiHotkey.Main.Author)]
[assembly: AssemblyTrademark(EmojiHotkey.Main.Company)]
[assembly: AssemblyVersion(EmojiHotkey.Main.Version)]
[assembly: AssemblyFileVersion(EmojiHotkey.Main.Version)]
[assembly: MelonInfo(typeof(EmojiHotkey.EmojiHotkey), EmojiHotkey.Main.Name, EmojiHotkey.Main.Version, EmojiHotkey.Main.Author, EmojiHotkey.Main.DownloadLink)]
[assembly: MelonColor()]

// Create and Setup a MelonGame Attribute to mark a Melon as Universal or Compatible with specific Games.
// If no MelonGame Attribute is found or any of the Values for any MelonGame Attribute on the Melon is null or empty it will be assumed the Melon is Universal.
// Values for MelonGame Attribute can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonGame(null, null)]