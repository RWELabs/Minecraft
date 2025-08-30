advancement revoke @s only graves:die
scoreboard players reset @s graves.deaths
execute if entity @s[gamemode=spectator] run return 1
schedule function graves:creation/increment_tick_id 1
execute anchored eyes positioned ^ ^ ^ positioned ~ ~-0.3 ~ summon minecraft:marker run function graves:creation/save_inventory_pos
execute store result storage graves:main creation.grave.death_gametime int 1.0 run time query gametime
data modify storage graves:main creation.player set from entity @s
data modify storage graves:main creation.target_grave_item.owner_uuid set from storage graves:main creation.player.UUID
data modify storage graves:main creation.target_grave_item.tick_id set from storage graves:main tick_id
data modify storage graves:main creation.grave_listing set value {location_text:{color:"gold",text:"(Grave loading... Try again.)"},item_count:"?",xp_points:"?"}
data modify storage graves:main creation.grave_listing.death_gametime set from storage graves:main creation.grave.death_gametime
data modify storage graves:main creation.grave_listing.dimension set from storage graves:main creation.player.Dimension
data modify storage graves:main creation.grave_listing.pos set from storage graves:main creation.player.Pos
data modify storage graves:main creation.grave_listing.loading.tick_id set from storage graves:main tick_id
data modify storage graves:main creation.grave_listing.owner_uuid set from storage graves:main creation.player.UUID
data remove storage graves:main creation.player
data modify storage graves:main creation.macro_args.owner_uuid set from storage graves:main creation.target_grave_item.owner_uuid
data modify storage graves:main creation.macro_args.owner_uuid_0 set from storage graves:main creation.macro_args.owner_uuid[0]
data modify storage graves:main creation.macro_args.owner_uuid_1 set from storage graves:main creation.macro_args.owner_uuid[1]
data modify storage graves:main creation.macro_args.owner_uuid_2 set from storage graves:main creation.macro_args.owner_uuid[2]
data modify storage graves:main creation.macro_args.owner_uuid_3 set from storage graves:main creation.macro_args.owner_uuid[3]
function graves:creation/create_loading_grave_listing with storage graves:main creation.macro_args
data remove storage graves:main creation.macro_args
execute unless function graves:creation/handle_death_as_player summon minecraft:marker run function graves:creation/initialize_death_marker
data remove storage graves:main creation