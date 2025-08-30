schedule function graves:location/schedule_2t 2
execute as @a[scores={graves=1..}] run function graves:location/list_graves/self
scoreboard players set @a graves 0
scoreboard players enable @a graves