tag @s add graves.bypass_impenetrable
execute positioned ~ ~1 ~ unless function graves:placement/is_repelling run return run function graves:placement/continue_in_attracting
execute at @e[type=minecraft:marker,tag=graves.side,distance=..1.5,sort=nearest,predicate=!graves:placement/is_impenetrable,limit=1] run return run function graves:placement/continue_repelling
execute positioned ~ ~1 ~ run function graves:placement/continue_repelling