# Save and Load Game Data
Save and Load Game data with encryption for Unity3D.

[Download](https://github.com/prashant-singh/SaveGameData/releases)

## Getting Started

```csharp
using Prashant.SaveGameData;
```
then

```csharp
GameData.Save(data,"yourpassword");
```
here data is an object of your "Data Class".

```csharp
data = GameData.Load(data,"yourpassword");
```
here data as a parameter is passed as a default data if there is no file found.

That's it.

## License

<a rel="license" href="http://creativecommons.org/licenses/by/4.0/"><img alt="Creative Commons License" style="border-width:0" src="https://i.creativecommons.org/l/by/4.0/88x31.png" /></a>
</br>
*This means you can use this script as you want.*

*Visit me at http://www.prashantsingh.xyz*

