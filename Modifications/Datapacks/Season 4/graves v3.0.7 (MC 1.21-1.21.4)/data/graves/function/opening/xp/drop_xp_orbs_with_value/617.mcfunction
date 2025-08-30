execute unless score $xp_points graves.dummy matches 617.. run return fail
data modify storage graves:main opening.xp_orb.Value set value 617s
data modify storage graves:main opening.xp_orb.Motion set value [0.0d,0.0d,0.0d]
execute store result storage graves:main opening.xp_orb.Motion[0] double 0.001 run random value -200..200
execute store result storage graves:main opening.xp_orb.Motion[1] double 0.001 run random value 0..400
execute store result storage graves:main opening.xp_orb.Motion[2] double 0.001 run random value -200..200
function graves:opening/xp/summon_xp_orb with storage graves:main opening
data modify entity @s {} merge from storage graves:main opening.xp_orb
data remove storage graves:main opening.xp_orb
scoreboard players remove $xp_points graves.dummy 617
function graves:opening/xp/drop_xp_orbs_with_value/617