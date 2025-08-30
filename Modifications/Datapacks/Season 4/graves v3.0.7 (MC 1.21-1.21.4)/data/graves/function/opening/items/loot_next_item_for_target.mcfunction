execute unless data storage graves:main opening.items[-1] run return fail
data modify storage graves:main opening.item set from storage graves:main opening.items[-1]
data remove storage graves:main opening.items[-1]
data modify storage graves:main opening.item.components merge value {}
data modify storage graves:main opening.item.slot set from storage graves:main opening.slots[-1]
data remove storage graves:main opening.slots[-1]
execute unless function graves:opening/items/replace_item run function graves:opening/items/save_as_extra_item
function graves:opening/items/loot_next_item_for_target