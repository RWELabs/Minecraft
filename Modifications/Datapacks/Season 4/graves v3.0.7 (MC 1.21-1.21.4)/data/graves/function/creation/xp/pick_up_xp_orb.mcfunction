execute store result score $xp_orb_value graves.dummy run data get entity @s Value
scoreboard players operation $xp_points graves.dummy += $xp_orb_value graves.dummy
kill @s