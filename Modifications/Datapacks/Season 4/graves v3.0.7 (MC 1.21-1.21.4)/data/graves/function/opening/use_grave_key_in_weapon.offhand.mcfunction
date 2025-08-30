playsound minecraft:block.vault.insert_item block @a ~ ~ ~ 0.5
execute if entity @s[gamemode=!creative] run item modify entity @s weapon.offhand graves:consume_item
return 1