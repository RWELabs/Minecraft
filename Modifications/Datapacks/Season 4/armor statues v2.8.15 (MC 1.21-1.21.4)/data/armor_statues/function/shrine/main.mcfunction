#
# Description:	Display shrine particles and give book
# Called by:	armor_statues:tick
# Entity @s:	Shrine marker area effect cloud
#
# Give book to nearby players if they do not have it already
#
execute as @a[distance=..1.5] if items entity @s inventory.* minecraft:written_book[custom_data~{datapack:"ArmorStatuesV2"}] at @s run function armor_statues:give
