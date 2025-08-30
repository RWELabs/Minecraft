execute if items entity @s weapon.mainhand *[minecraft:custom_data~{graves:{grave_key:1b}}] run return run function graves:opening/use_grave_key_in_weapon.mainhand
execute if items entity @s weapon.offhand *[minecraft:custom_data~{graves:{grave_key:1b}}] run return run function graves:opening/use_grave_key_in_weapon.offhand
data modify storage graves:main opening.owner_uuid_copy set from storage graves:main opening.owner_uuid
execute store success storage graves:main opening.changed byte 1.0 run data modify storage graves:main opening.owner_uuid_copy set from entity @s UUID
execute if data storage graves:main opening{changed:0b} run return 1