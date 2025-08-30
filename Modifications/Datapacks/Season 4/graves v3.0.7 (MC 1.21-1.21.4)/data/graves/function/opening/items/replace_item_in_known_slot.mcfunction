$execute on vehicle run item replace entity @s contents from entity @a[tag=graves.opener,distance=..0.01,limit=1] $(slot)
execute on vehicle run data modify storage graves:main opening.replaced_item set from entity @s item
data modify storage graves:main opening.item.slot_prefix set string storage graves:main opening.item.slot 0 6
execute if data storage graves:main opening.item{slot_prefix:"armor."} if data storage graves:main opening.replaced_item.components."minecraft:enchantments".levels."minecraft:binding_curse" run return run function graves:opening/items/fail_to_replace_binding_curse
$execute on target run loot replace entity @s $(slot) loot { "pools": [ { "rolls": 1, "entries": [ { "type": "minecraft:item", "name": "$(id)", "functions": [ { "function": "minecraft:set_count", "count": $(count) }, { "function": "minecraft:set_components", "components": $(components) } ] } ] } ] }
data modify storage graves:main opening.extra_item set from storage graves:main opening.replaced_item
data remove storage graves:main opening.replaced_item
execute if data storage graves:main opening.extra_item run function graves:opening/items/append_extra_item_entry
return 1