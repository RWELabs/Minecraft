data modify entity @s interaction set value {player:[I;0,0,0,0],timestamp:0L}
data modify entity @s interaction.player set from storage graves:main creation.grave_item.owner_uuid
kill @s
execute on target run tellraw @s [{"text":"Your last grave is at ","color":"gold"},{"storage":"graves:main","nbt":"creation.grave_listing.location_text","interpret":true},". Enter ",{"color":"yellow","text":"/trigger graves","hoverEvent":{"action":"show_text","contents":"Click to run command."},"clickEvent":{"action":"run_command","value":"/trigger graves"}}," to list all your graves."]