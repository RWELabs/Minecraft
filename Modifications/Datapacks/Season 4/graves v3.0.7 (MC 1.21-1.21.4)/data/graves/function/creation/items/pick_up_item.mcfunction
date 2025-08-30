execute if data storage graves:config {compatibility_mode:1b} unless data storage graves:main creation.item.slot run function graves:creation/items/prepare_to_pick_up_non_pre_death_item
execute unless data storage graves:main creation.item.slot run return fail
data modify storage graves:main creation.items append from storage graves:main creation.item.value
data modify storage graves:main creation.grave.slots append from storage graves:main creation.item.slot
kill @s