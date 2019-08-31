# Desc: Checks for mobs with specific name and silences them
#
# Called by: #main:second

execute as @e[name="silence"] at @s run data merge entity @s {CustomName:"{\"text\":\"silenced\"}",Silent:1b,ActiveEffects:[{Id:24b,Duration:5,ShowParticles:0b}]}
execute as @e[name="Silence"] at @s run data merge entity @s {CustomName:"{\"text\":\"silenced\"}",Silent:1b,ActiveEffects:[{Id:24b,Duration:5,ShowParticles:0b}]}
