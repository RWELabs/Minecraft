data merge entity @s {PickupDelay:0s,Motion:[0.0f,0.0f,0.0f]}
data modify entity @s Owner set from storage graves:main opening.player_uuid
data modify storage graves:main opening.initial_custom_data set from entity @s Item.components."minecraft:custom_data".graves.initial_custom_data
item modify entity @s contents {function:"minecraft:set_components",components:{"!minecraft:custom_data":{}}}
data modify entity @s Item.components."minecraft:custom_data" set from storage graves:main opening.initial_custom_data
data remove storage graves:main opening.initial_custom_data