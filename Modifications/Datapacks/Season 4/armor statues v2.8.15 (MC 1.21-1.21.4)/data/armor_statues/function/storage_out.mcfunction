#
# Description:	Copies stored book from storage into mainhand or offhand
# Called by:	as_statue:trigger\copy
# Entity @s:	player
#
# Copies data to a temp pig
#

# setup input
data modify storage customizable_armor_stands:book_macro input set value {count: 1, hand: "mainhand", components: {}}
data modify storage customizable_armor_stands:book_macro input.components set from storage customizable_armor_stands:book_storage SavedItem.components
data modify storage customizable_armor_stands:book_macro input.count set from storage customizable_armor_stands:book_storage SavedItem.count

# set hand to offhand if offhand
execute if items entity @s weapon.offhand minecraft:written_book[custom_data~{datapack:"ArmorStatuesV2"}] unless items entity @s weapon.mainhand minecraft:written_book[custom_data~{datapack:"ArmorStatuesV2"}] run data modify storage customizable_armor_stands:book_macro input.hand set value "offhand"

# bail function if neither hand has a book
execute unless items entity @s weapon.offhand minecraft:written_book[custom_data~{datapack:"ArmorStatuesV2"}] unless items entity @s weapon.mainhand minecraft:written_book[custom_data~{datapack:"ArmorStatuesV2"}] run return 0

# fire!
function armor_statues:storage_out_macro with storage customizable_armor_stands:book_macro input