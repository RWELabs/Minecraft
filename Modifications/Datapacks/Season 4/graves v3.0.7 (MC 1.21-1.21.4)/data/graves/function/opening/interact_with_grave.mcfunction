advancement revoke @s only graves:interact_with_grave
tag @s add graves.opener
execute as @e[type=minecraft:interaction,tag=graves.grave,sort=nearest,distance=0..] if function graves:opening/did_player_interact_with_grave unless function graves:opening/open_grave_for_target run data remove entity @s interaction
tag @s remove graves.opener