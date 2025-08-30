execute if entity @s[tag=graves.has_side_markers] run function graves:placement/clean_up_side_markers
tp @s ~ ~ ~
execute on passengers run tag @s remove graves.non_grave_repelling