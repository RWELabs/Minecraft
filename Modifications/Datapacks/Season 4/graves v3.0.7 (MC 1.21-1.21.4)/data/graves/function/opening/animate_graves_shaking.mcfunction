execute as @e[type=minecraft:item_display,tag=graves.grave.shaking] at @s run function graves:opening/animate_shaking
scoreboard players remove $max graves.shaking_ticks_left 1
execute if score $max graves.shaking_ticks_left matches 1.. run schedule function graves:opening/animate_graves_shaking 1