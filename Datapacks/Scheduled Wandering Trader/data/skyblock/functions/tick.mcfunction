
scoreboard players set $tempPhase skyblock 8

execute store result score $moonPhase skyblock run scoreboard players operation $day skyblock %= $tempPhase skyblock

execute if score $moonPhase skyblock = $tempPhase skyblock run say test

execute store result score $day skyblock run time query day

scoreboard players operation $tempPhase skyblock = $traderSpawnPhase skyblock

execute store result score $tick skyblock run time query daytime

execute if score $tick skyblock = $traderSpawnTime skyblock run execute if score $moonPhase skyblock = $traderSpawnPhase skyblock run summon wandering_trader 27 65 -2 {CustomName:'"Wandering Trader"'}
execute if score $tick skyblock = $traderSpawnTime skyblock run execute if score $moonPhase skyblock = $traderSpawnPhase skyblock run tellraw @a ["",{"text":"A "},{"text":"Wandering Fucktard","color":"blue"},{"text":" has appeared on the "},{"text":"Hub Island","color":"green"},{"text":"!"}]

execute if score $tick skyblock = $traderDespawnTime skyblock run execute if score $moonPhase skyblock = $traderSpawnPhase skyblock run tp @e[type=wandering_trader,name="Wandering Trader"] 0 -255 0 0 0
execute if score $tick skyblock = $traderDespawnTime skyblock run execute if score $moonPhase skyblock = $traderSpawnPhase skyblock run kill @e[type=wandering_trader,name="Wandering Trader"]
execute if score $tick skyblock = $traderDespawnTime skyblock run execute if score $moonPhase skyblock = $traderSpawnPhase skyblock run tellraw @a ["",{"text":"The "},{"text":"Wandering Fucktard","color":"blue"},{"text":" has left the "},{"text":"Hub Island","color":"green"},{"text":"!"}]