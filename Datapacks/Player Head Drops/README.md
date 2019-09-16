# Player Head Drops for Minecraft 1.14.x
 This datapack introduces loot table changes that allow for the introduction of player head drops upon death in Minecraft 1.14.x.
 This datapack was written for use in The Baked Potatarium Minecraft server but can be loaded into any Minecraft world as a datapack.

## Installation Instructions
1. Download the latest release (ZIP format)
2. Put the ZIP folder in your Minecraft Save's "datapack" folder.
3. Load your Minecraft save or if already in-game, type /reload.
The datapack should automatically activate. You can verify this by typing "/datapack list" and PlayerHeads.zip should appear.

### Adjusting drop rates
- You can adjust the rate at which the heads drop by editing the player.json file in the "/data/minecraft/loot_tables/entities" folder and adding the "random_chance_with_looting" condition. This is not added by default as the drop chance is 100%.

"Looting Multiplier" is for the looting adjustment to the base success rate. Formula is chance + (looting_level * looting_multiplier).

```
"condition": "random_chance_with_looting",
			"chance": 0.25,
			"looting_multiplier": 0.05
```

## Releases
[Download the latest release (v1.1.0)](https://github.com/RyanWalpoleEnterprises/QOL-Improvements-for-TBP/tree/master/releases)
[Download the latest release (v1.0.0)](https://github.com/RyanWalpoleEnterprises/QOL-Improvements-for-TBP/tree/master/releases)
