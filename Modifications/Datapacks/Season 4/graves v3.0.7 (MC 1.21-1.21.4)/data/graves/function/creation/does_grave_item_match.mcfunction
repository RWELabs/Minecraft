data modify storage graves:main creation.grave_item set from entity @s Item.components."minecraft:custom_data".graves
execute store success storage graves:main creation.changed byte 1.0 run data modify storage graves:main creation.grave_item merge from storage graves:main creation.target_grave_item
execute if data storage graves:main creation{changed:0b} run return 1
data remove storage graves:main creation.grave_item