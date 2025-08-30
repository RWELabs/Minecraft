tp @s ~ ~ ~ ~ ~
data modify entity @s data.graves.creation set from storage graves:main creation
execute store success entity @s data.graves.forceload_success byte 1.0 run forceload add ~ ~
scoreboard players add $death_marker_count graves.dummy 1
function graves:creation/check_death_markers
tag @s add graves.death_marker
advancement revoke @a only graves:check_death_markers_later_in_tick