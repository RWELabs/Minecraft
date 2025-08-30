data modify storage graves:main creation.grave_item_entity set from entity @s
data modify storage graves:main creation.grave_item set from storage graves:main creation.grave_item_entity.Item.components."minecraft:custom_data".graves
execute store result storage graves:main creation.found_drops_late byte 1.0 run data get storage graves:main creation.grave_item_entity.Age
data modify storage graves:main creation.owner_name set from storage graves:main creation.grave_item_entity.Item.components."minecraft:lore"[0]
kill @s
return 1