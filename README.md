# opendpr

This is a reverse-engineered recreation of Brilliant Diamond and Shining Pearl.

## Generative AI Disclosure

No Generative AI has been used in the making of this project. Every line of code is either:
- Hand-written
- Made using (usually Python) scripts that were, themselves, hand-written (for the more repetitive tasks)

We strongly encourage developers of other similar projects to take a strong stance against the use of Generative AI and to foster an environment where human creativity can thrive. It was possible to make projects like this before Generative AI. There is always a human-made alternative to use.

## Setup

This project is intended to be opened with Unity 2019.4.27f1. It is the Unity version BDSP is built on and will keep issues to a minimum.

Avoid opening the project in Unity before it is fully set up, otherwise there might be issues with missing files.

To properly set up this project, you must first dump YOUR OWN copy of Brilliant Diamond (untested on Shining Pearl but should theoretically work).

Using that dump, use [Asset Ripper 1.1.8](https://github.com/AssetRipper/AssetRipper/releases/tag/1.1.8) (later versions don't have the proper behavior we need) to rip your entire RomFS AND ExeFS, except for the StreamingAssets folder in RomFS. Use the following settings in AssetRipper:
- Script Content: "Level 2"
- Script Export Format: "Hybrid"
- C# Language Version: "Automatic - Safe"
- Sprite Export Format: "Texture"
- Skip StreamingAssets Folder: ON

With the results, run the Python script in the "asset_ripper_resources" folder of [this repository](https://github.com/SaltContainer/Lumi_Small_Scripts). You'll have to put the folders AssetRipper made for you in an "input" folder next to the script before running it. The results will be put in an "output" folder the script creates.

For now, there are a few extra steps that will eventually be automated by the above script.

In the output, delete the following (and their associated .meta file):
- "MonoBehaviour/AkWwiseInitializationSettings.asset"
- "MonoBehaviour/Mac.asset"
- "MonoBehaviour/Switch.asset"
- "MonoBehaviour/Windows.asset"

In the output, move the following (and their associated .meta file):
- "Resources/fonts & materials" (and contents) to "TextMesh Pro/Resources/fonts & materials"
- "Resources/sprite assets" (and contents) to "TextMesh Pro/Resources/sprite assets"
- "Resources/style sheets" (and contents) to "TextMesh Pro/Resources/style sheets"
- "Resources/LineBreaking Following Characters.txt" to "TextMesh Pro/Resources/LineBreaking Following Characters.txt"
- "Resources/LineBreaking Leading Characters.txt" to "TextMesh Pro/Resources/LineBreaking Leading Characters.txt"
- "Scenes/level0.unity" to directly in Assets
- Everything else should be put directly in Resources

In the asset "StartupSettings.asset", replace every instance of "AssetAssistant, Version=0.0.0.0," with "Assembly-CSharp, Version=1.6.28.12450,".

Create, at the root of the project, the folder "AssetBundles/Editor", and insert prepared Windows bundles containing Windows shaders (the two needed bundles are fxparticle and shaders).

Copy everything in StreamingAssets in your romfs dump to StreamingAssets in the project.

Rename the folder "StreamingAssets/Audio/GeneratedSoundBanks/Switch" to "StreamingAssets/Audio/GeneratedSoundBanks/Windows".

Once you've done all of this, you should be ready to open the project!

## FAQ

### Is this a "decomp"?

Not quite. There are a few reasons why it's not "technically" a decompilation.
- The game was compiled through IL2CPP, which makes it very difficult to compare the resulting assembly and assure a "matching" decompilation.
- The game uses an SDK that is only given to Nintendo-approved developers, which we do not have access to.

### Why do I need Windows shaders?

Shaders are compiled to be used only on a specific platform. Therefore, we cannot use the Switch shaders on Windows, so we need custom shaders.
