schedule clear graves:schedule_1s
schedule clear graves:location/schedule_2t
schedule clear graves:creation/check_death_markers
schedule clear graves:creation/increment_tick_id
schedule clear graves:opening/animate_graves_shaking
scoreboard objectives remove graves.dummy
scoreboard objectives remove graves.deaths
scoreboard objectives remove graves.shaking_ticks_left
scoreboard objectives remove graves.age_seconds
scoreboard objectives remove graves
data remove storage graves:const slots
data remove storage graves:const dimension_names
data remove storage graves:config allow_robbing
data remove storage graves:config pick_up_xp
data remove storage graves:config allow_locating
data remove storage graves:config compatibility_mode
data remove storage graves:main tick_id
data remove storage graves:main players