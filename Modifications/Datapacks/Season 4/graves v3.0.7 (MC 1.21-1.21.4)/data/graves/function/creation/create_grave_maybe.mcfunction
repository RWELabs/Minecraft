data modify storage graves:main creation.pre_death_inventory set from storage graves:main creation.grave_item.pre_death_inventory
function graves:creation/items/save_next_pre_death_item_slot with storage graves:main creation.pre_death_inventory[-1]
data modify storage graves:main creation merge value {items:[],grave:{slots:[]}}
data modify storage graves:main creation.inventory_pos_compound.x set from storage graves:main creation.grave.inventory_pos[0]
data modify storage graves:main creation.inventory_pos_compound.y set from storage graves:main creation.grave.inventory_pos[1]
data modify storage graves:main creation.inventory_pos_compound.z set from storage graves:main creation.grave.inventory_pos[2]
function graves:creation/items/pick_up_items_at_inventory_pos with storage graves:main creation.inventory_pos_compound
execute if data storage graves:main creation{found_drops_late:1b} run function graves:creation/items/check_for_missing_pre_death_items
scoreboard players reset $non_inventory_item_count graves.dummy
execute if data storage graves:config {pick_up_xp:1b} run function graves:creation/xp/pick_up_xp
execute store result storage graves:main creation.grave.xp_points int 1.0 run scoreboard players get $xp_points graves.dummy
scoreboard players reset $xp_points graves.dummy
execute unless data storage graves:main creation.items[0] if data storage graves:main creation.grave{xp_points:0} run return run function graves:creation/remove_loading_grave_listing with storage graves:main creation.grave_item
execute summon minecraft:item_display run function graves:creation/initialize_grave