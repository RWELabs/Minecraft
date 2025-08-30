execute as @e[type=minecraft:ghast,tag=!agg_tagged] at @s run data merge entity @s {ExplosionPower:0}
tag @e[type=minecraft:ghast,tag=!agg_tagged] add agg_tagged
schedule function anti_ghast_grief:second 1s
