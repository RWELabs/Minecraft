execute if data storage graves:main opening{xp_points:0} run return 1
execute store result storage graves:main opening.xp_sound_pitch double 0.001 run random value 550..1250
execute on target run function graves:opening/xp/give_xp with storage graves:main opening