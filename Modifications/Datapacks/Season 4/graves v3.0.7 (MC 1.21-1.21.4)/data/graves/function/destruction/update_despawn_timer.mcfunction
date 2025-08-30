scoreboard players add @s graves.age_seconds 1
execute if score @s graves.age_seconds <= $despawn_seconds graves.config run return 1
data modify storage graves:main destruction.grave_entity set from entity @s
data modify storage graves:main destruction merge from storage graves:main destruction.grave_entity.item.components."minecraft:custom_data".graves
data modify storage graves:main destruction.grave_uuid set from storage graves:main destruction.grave_entity.UUID
execute on passengers at @s run function graves:destruction/destroy_grave with storage graves:main destruction