data modify entity @s interaction set value {player:[I;0,0,0,0],timestamp:0L}
data modify entity @s interaction.player set from storage graves:main creation.target_grave_item.owner_uuid
kill @s
execute on target run function graves:creation/fail_to_find_grave_item
return 1