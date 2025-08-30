data modify storage graves:main creation set from entity @s data.graves.creation
execute if function graves:creation/handle_death_as_death_marker run function graves:creation/unmark_death
data remove storage graves:main creation