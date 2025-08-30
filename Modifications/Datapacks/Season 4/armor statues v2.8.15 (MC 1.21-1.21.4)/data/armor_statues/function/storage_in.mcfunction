#
# Description:	Copies player book from mainhand or offhand into storage
# Called by:	as_statue:trigger\copy as_statue:trigger\paste
# Entity @s:	player
#
# Temp storage to copy
#
execute if items entity @s weapon.mainhand minecraft:written_book[custom_data~{datapack:"ArmorStatuesV2"}] run data modify storage customizable_armor_stands:book_storage SavedItem set from entity @s SelectedItem
execute if items entity @s weapon.offhand minecraft:written_book[custom_data~{datapack:"ArmorStatuesV2"}] if items entity @s weapon.mainhand minecraft:written_book[custom_data~{datapack:"ArmorStatuesV2"}] run data modify storage customizable_armor_stands:book_storage SavedItem set from entity @s Inventory[{Slot:-106b}]