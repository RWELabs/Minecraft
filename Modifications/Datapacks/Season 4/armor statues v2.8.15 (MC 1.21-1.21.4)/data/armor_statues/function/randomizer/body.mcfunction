#
# Description:	Randomizes appendage rotation
# Called by:	armor_statues:trigger/random_pose
# Entity @s:	temp armor stand
#
execute store result score #x_angle as_angle run data get entity @s ArmorItems[3].components."minecraft:attribute_modifiers".modifiers[{ "id":"armor_statues:body_x" }].amount 1000
execute store result score #y_angle as_angle run data get entity @s ArmorItems[3].components."minecraft:attribute_modifiers".modifiers[{ "id":"armor_statues:body_y" }].amount 1000
execute store result score #z_angle as_angle run data get entity @s ArmorItems[3].components."minecraft:attribute_modifiers".modifiers[{ "id":"armor_statues:body_z" }].amount 1000
function armor_statues:randomizer/body_angle
execute store result storage customizable_armor_stands:pose_storage Pose.Body[0] float 0.001 run scoreboard players get #x_angle as_angle
execute store result storage customizable_armor_stands:pose_storage Pose.Body[1] float 0.001 run scoreboard players get #y_angle as_angle
execute store result storage customizable_armor_stands:pose_storage Pose.Body[2] float 0.001 run scoreboard players get #z_angle as_angle