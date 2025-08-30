tp @s ~ ~ ~
execute align z positioned ~ ~ ~-0.25 if loaded ~ ~ ~ run summon minecraft:marker ~ ~ ~ {Tags:["graves.side","graves.side.north"]}
execute align z positioned ~ ~ ~1.25 if loaded ~ ~ ~ run summon minecraft:marker ~ ~ ~ {Tags:["graves.side","graves.side.south"]}
execute align x positioned ~-0.25 ~ ~ if loaded ~ ~ ~ run summon minecraft:marker ~ ~ ~ {Tags:["graves.side","graves.side.west"]}
execute align x positioned ~1.25 ~ ~ if loaded ~ ~ ~ run summon minecraft:marker ~ ~ ~ {Tags:["graves.side","graves.side.east"]}
tag @s add graves.has_side_markers
execute at @e[type=minecraft:marker,tag=graves.side,distance=..1.5,sort=nearest,limit=4] unless function graves:placement/is_repelling run return run function graves:placement/continue_in_attracting
execute if block ~ ~ ~ #graves:grave_impenetrable run return run function graves:placement/repel_from_impenetrable
execute if block ~ ~1 ~ #graves:grave_impenetrable unless entity @s[tag=graves.bypass_impenetrable] at @s run return run function graves:placement/stop
execute positioned ~ ~1 ~ if function graves:placement/is_repelling run return run function graves:placement/continue_repelling
execute positioned ~ ~1 ~ run function graves:placement/continue_in_attracting