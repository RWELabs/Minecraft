execute unless score $death_marker_count graves.dummy matches 1.. run return 1
execute as @e[type=minecraft:marker,tag=graves.death_marker] at @s run function graves:creation/check_death_marker
execute if score $death_marker_count graves.dummy matches 1.. run advancement revoke @s only graves:check_death_markers_later_in_tick