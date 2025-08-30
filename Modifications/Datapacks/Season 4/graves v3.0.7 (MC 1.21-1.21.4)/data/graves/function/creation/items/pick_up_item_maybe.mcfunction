data modify storage graves:main creation.item.value set from entity @s Item
function graves:creation/items/find_pre_death_item_matches with storage graves:main creation.item
function graves:creation/items/check_next_pre_death_item_match
function graves:creation/items/get_pre_death_item_slot with storage graves:main creation.item
function graves:creation/items/pick_up_item
data remove storage graves:main creation.item