execute positioned ~-3.5 ~ ~-3.5 as @e[type=minecraft:marker,tag=graves.side.north,dx=6,dy=-2,dz=6,limit=1] positioned ~3.5 ~ ~3.5 align z positioned ~ ~ ~-0.25 run function graves:placement/move_side_marker_here
execute positioned ~-3.5 ~ ~-3.5 as @e[type=minecraft:marker,tag=graves.side.south,dx=6,dy=-2,dz=6,limit=1] positioned ~3.5 ~ ~3.5 align z positioned ~ ~ ~1.25 run function graves:placement/move_side_marker_here
execute positioned ~-3.5 ~ ~-3.5 as @e[type=minecraft:marker,tag=graves.side.west,dx=6,dy=-2,dz=6,limit=1] positioned ~3.5 ~ ~3.5 align x positioned ~-0.25 ~ ~ run function graves:placement/move_side_marker_here
execute positioned ~-3.5 ~ ~-3.5 as @e[type=minecraft:marker,tag=graves.side.east,dx=6,dy=-2,dz=6,limit=1] positioned ~3.5 ~ ~3.5 align x positioned ~1.25 ~ ~ run function graves:placement/move_side_marker_here
execute at @e[type=minecraft:marker,tag=graves.side,distance=..1.5,sort=nearest,limit=4] unless function graves:placement/is_repelling run return run function graves:placement/continue_in_attracting
execute if block ~ ~ ~ #graves:grave_impenetrable run return run function graves:placement/repel_from_impenetrable
execute if block ~ ~1 ~ #graves:grave_impenetrable unless entity @s[tag=graves.bypass_impenetrable] at @s run return run function graves:placement/stop
execute positioned ~ ~1 ~ if function graves:placement/is_repelling run return run function graves:placement/continue_repelling
execute positioned ~ ~1 ~ run function graves:placement/continue_in_attracting