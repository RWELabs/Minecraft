$loot spawn ~ ~ ~ loot {"pools": $(pools)}
execute on target run data modify storage graves:main opening.player_uuid set from entity @s UUID
execute as @e[type=minecraft:item,distance=..0.01] if items entity @s contents *[minecraft:custom_data~{graves:{extra_item:1b}}] run function graves:opening/items/fix_extra_item