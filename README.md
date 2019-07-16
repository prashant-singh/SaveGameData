# Save and Load Game Data
> Save and Load Game data with encryption for Unity3D.

![Save and Load Logo](https://github.com/prashant-singh/SaveGameData/blob/master/save%20icon.png)



[![download](https://img.shields.io/badge/download-package-blue.svg)](https://github.com/prashant-singh/SaveGameData/releases)
[![GitHub](https://img.shields.io/github/license/mashape/apistatus.svg?style=popout)](https://github.com/prashant-singh/SaveGameData/blob/master/LICENSE)
[![GitHub release](https://img.shields.io/github/release/prashant-singh/my-scene-manager/all.svg)](https://github.com/prashant-singh/SaveGameData/releases)

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
pass the default data to create a new file if the file doesn't exist.

That's it.

