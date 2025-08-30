execute unless data storage graves:main creation.item.pre_death_item_matches[-1] run return fail
data modify storage graves:main creation.item.match_value set from storage graves:main creation.item.value
execute store success storage graves:main creation.changed byte 1.0 run data modify storage graves:main creation.item.match_value set from storage graves:main creation.item.pre_death_item_matches[-1].value
execute if data storage graves:main creation{changed:0b} run return run data modify storage graves:main creation.item.pre_death_index set from storage graves:main creation.item.pre_death_item_matches[-1].index
data remove storage graves:main creation.item.pre_death_item_matches[-1]
function graves:creation/items/check_next_pre_death_item_match