data merge entity @s {Tags:["graves.grave","graves.grave.initializing"],transformation:{translation:[0.0f,0.3125f,0.0f],scale:[0.625f,0.625f,0.625f],right_rotation:[0.0f,0.0f,0.0f,1.0f],left_rotation:[0.0f,0.0f,0.0f,1.0f]},item:{id:"minecraft:stone_brick_wall",components:{"minecraft:item_name":'"Grave Model"',"minecraft:rarity":"epic","minecraft:lore":['{"italic":false,"color":"gold","text":"If you see this item, the Graves data pack didn\'t work!"}','{"italic":false,"color":"gold","text":"Please let us know in our data pack help channel:"}','{"italic":false,"color":"yellow","text":"https://vanillatweaks.net/discord"}']}},item_display:"head",teleport_duration:1}
execute if data storage graves:main creation.items[0] run data modify entity @s item.components."minecraft:bundle_contents" set from storage graves:main creation.items
item modify entity @s contents [{"function":"minecraft:set_components","components":{"!minecraft:custom_name":{}}},{"function":"minecraft:copy_custom_data","source":{"type":"storage","source":"graves:main"},"ops":[{"op":"replace","source":"creation.grave","target":"graves"},{"op":"replace","source":"creation.grave_item.owner_uuid","target":"graves.owner_uuid"},{"op":"replace","source":"creation.grave_item.pre_death_inventory","target":"graves.pre_death_inventory"},{"op":"replace","source":"creation.found_drops_late","target":"graves.found_drops_late"}]}]
tp @s ~ ~ ~ ~90 0
function graves:face_cardinal_direction
summon minecraft:interaction ~ ~ ~ {Tags:["graves.grave","graves.non_grave_repelling","graves.grave.unmounted"],width:0.75f,height:0.75f,response:1b}
ride @e[type=minecraft:interaction,tag=graves.grave.unmounted,distance=..0.01,limit=1] mount @s
execute on passengers run tag @s remove graves.grave.unmounted
function graves:placement/start
execute at @s positioned ~ ~0.75 ~ run summon minecraft:text_display ~ ~ ~ {Tags:["graves.grave","graves.grave.initializing"],billboard:"center",view_range:0.0625f,text:'{"storage":"graves:main","nbt":"creation.owner_name","interpret":true}',alignment:"center"}
execute at @s positioned ~ ~0.75 ~ as @e[type=minecraft:text_display,tag=graves.grave.initializing,distance=..0.01,limit=1] run function graves:creation/initialize_grave_name_tag
item modify entity @s contents {function:"minecraft:copy_custom_data",source:{type:"storage",source:"graves:main"},ops:[{op:"replace",source:"creation.grave.name_tag_uuid",target:"graves.name_tag_uuid"}]}
data modify storage graves:main creation.grave_entity set from entity @s
data modify storage graves:main creation.grave_listing.uuid set from storage graves:main creation.grave_entity.UUID
data modify storage graves:main creation.grave_listing.pos set from storage graves:main creation.grave_entity.Pos
execute store result storage graves:main creation.grave_listing.item_count int 1.0 run data get storage graves:main creation.items
data modify storage graves:main creation.grave_listing.xp_points set from storage graves:main creation.grave.xp_points
data remove storage graves:main creation.grave_listing.loading
data modify storage graves:main creation.macro_args set from storage graves:main creation.target_grave_item
data modify storage graves:main creation.macro_args.dimension set from storage graves:main creation.grave_listing.dimension
data modify storage graves:main creation.macro_args.x set from storage graves:main creation.grave_listing.pos[0]
data modify storage graves:main creation.macro_args.y set from storage graves:main creation.grave_listing.pos[1]
data modify storage graves:main creation.macro_args.z set from storage graves:main creation.grave_listing.pos[2]
execute store result storage graves:main creation.macro_args.x_int int 1.0 run data get storage graves:main creation.grave_listing.pos[0]
execute store result storage graves:main creation.macro_args.y_int int 1.0 run data get storage graves:main creation.grave_listing.pos[1]
execute store result storage graves:main creation.macro_args.z_int int 1.0 run data get storage graves:main creation.grave_listing.pos[2]
function graves:creation/update_grave_listing with storage graves:main creation.macro_args
execute if data storage graves:config {allow_locating:1b} summon minecraft:interaction run function graves:creation/show_new_grave_location
tag @s remove graves.grave.initializing