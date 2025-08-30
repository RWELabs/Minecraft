scoreboard players remove @s graves.shaking_ticks_left 1
execute if score @s graves.shaking_ticks_left matches 4 run return run tp @s ~ ~ ~ ~4 ~
execute if score @s graves.shaking_ticks_left matches 3 run return run tp @s ~ ~ ~ ~-8 ~
execute if score @s graves.shaking_ticks_left matches 2 run return run tp @s ~ ~ ~ ~8 ~
execute if score @s graves.shaking_ticks_left matches 1 run return run tp @s ~ ~ ~ ~-8 ~
tp @s ~ ~ ~ ~4 ~
tag @s remove graves.grave.shaking