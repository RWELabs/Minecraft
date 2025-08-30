execute on passengers on attacker run title @s actionbar [{"color":"green","text":"Tip: Use "},{"keybind":"key.use"}," to load a grave's contents directly into your inventory."]
execute if entity @s[tag=graves.grave.shaking] on passengers if function graves:opening/open_grave run return 1
function graves:face_cardinal_direction
tag @s add graves.grave.shaking
scoreboard players set @s graves.shaking_ticks_left 5
scoreboard players set $max graves.shaking_ticks_left 5
playsound minecraft:block.stone.hit block @a
execute on passengers run data remove entity @s attack
schedule function graves:opening/animate_graves_shaking 1