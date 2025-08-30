execute store result storage graves:main creation.pre_death_item_index int 1.0 run data get storage graves:main creation.pre_death_items
data modify storage graves:main creation.pre_death_items append value {slot:"unknown"}
data modify storage graves:main creation.pre_death_items[-1].index set from storage graves:main creation.pre_death_item_index
data modify storage graves:main creation.pre_death_items[-1].value set from storage graves:main creation.pre_death_inventory[-1]
data remove storage graves:main creation.pre_death_inventory[-1]
$data modify storage graves:main creation.pre_death_items[-1].slot set from storage graves:const slots.$(Slot)
data remove storage graves:main creation.pre_death_items[-1].value.Slot
function graves:creation/items/save_next_pre_death_item_slot with storage graves:main creation.pre_death_inventory[-1]