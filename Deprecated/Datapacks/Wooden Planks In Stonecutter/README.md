# Wooden Planks In Stonecutter
 Adds crafting recipes for wooden planks in the stonecutter in Minecraft. This includes being able to craft trapdoors, buttons, pressure plates, slabs and stairs in the stonecutter with some yield benefits.

 ## Crafting Recipes
 In this pack, 1 wooden plank in the stonecutter can produce:

 - 2 Slabs
 - 2 Trapdoors
 - 2 Pressure Plates
 - 4 Buttons
 - 1 Stair
 - 4 Sticks

 ### Removing Recipes
 To remove an item from crafting eligibility entirely, delete the file that corresponds with the item.
 For example, to remove Acacia Trapdoors from being crafted with the stonecutter, delete the "acacia_trapdoor.json" file in data/crafting/recipes.

 ### Crafting Efficiency
 Slabs: As efficient in the crafting table as in the stonecutter.
 Trapdoors: More efficient (higher yield) in the stonecutter.
 Pressure Plates: More efficient (higher yield) in the stonecutter.
 Buttons: More efficient (higher yield) in the stonecutter.
 Stairs: More efficient (higher yield) in the stonecutter.
 Sticks: More efficient (higher yield) in the stonecutter.

 ## Adjusting Yield for Recipes
 To adjust the yield, edit the JSON file that is named after the object that will be crated.

 E.g. to make a birch plank craft 160 trapdoors, edit the file named "birch_trapdoor.json" in data/crafting/recipes
 The value to edit is "count". An example of this is below:

### Default
```
"result": "minecraft:birch_button",
    "group": "Wood",
    "count": 160
```
### Edited
```
"result": "minecraft:birch_button",
    "group": "Wood",
    "count": 160
```
## Download
To download, please see the folder "releases" in the repository. This ZIP folder can be placed directly in your datapack folder.
The datapack folder can be found at

#### Releases
[https://github.com/RyanWalpoleEnterprises/Wooden-Planks-In-Stonecutter/tree/master/releases](https://github.com/RyanWalpoleEnterprises/Wooden-Planks-In-Stonecutter/tree/master/releases)

%appdata%/roaming/.minecraft/saves/World-Save-Name/datapacks

*If you're already in the game, type /reload

## Credits
Made by [Crutionix](http://www.crutionix.com/) as a part of [RWE Softworks](http://www.ryanwalpole.com/softworks)
