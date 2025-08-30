scoreboard objectives add graves.config dummy
scoreboard objectives add graves.dummy dummy
scoreboard objectives add graves.deaths minecraft.custom:minecraft.deaths
scoreboard objectives add graves.shaking_ticks_left dummy
scoreboard objectives add graves.age_seconds dummy
scoreboard objectives add graves trigger "List Graves"
scoreboard players reset * graves
data modify storage graves:const slots set value {-106:"weapon.offhand",0:"container.0",1:"container.1",2:"container.2",3:"container.3",4:"container.4",5:"container.5",6:"container.6",7:"container.7",8:"container.8",9:"container.9",10:"container.10",11:"container.11",12:"container.12",13:"container.13",14:"container.14",15:"container.15",16:"container.16",17:"container.17",18:"container.18",19:"container.19",20:"container.20",21:"container.21",22:"container.22",23:"container.23",24:"container.24",25:"container.25",26:"container.26",27:"container.27",28:"container.28",29:"container.29",30:"container.30",31:"container.31",32:"container.32",33:"container.33",34:"container.34",35:"container.35",100:"armor.feet",101:"armor.legs",102:"armor.chest",103:"armor.head"}
data modify storage graves:const dimension_names set value {"minecraft:overworld":"the Overworld","minecraft:the_nether":"the Nether","minecraft:the_end":"the End"}
scoreboard players set $TICKS_PER_HOUR graves.dummy 72000
execute unless data storage graves:config allow_robbing run data modify storage graves:config allow_robbing set value false
execute unless data storage graves:config pick_up_xp run data modify storage graves:config pick_up_xp set value true
execute unless data storage graves:config allow_locating run function graves:reset_allow_locating
execute unless data storage graves:config compatibility_mode run data modify storage graves:config compatibility_mode set value false
scoreboard players add $despawn_seconds graves.config 0
scoreboard players reset * graves.deaths
execute store result score $tick_id graves.dummy store result storage graves:main tick_id int 1.0 run data get storage graves:main tick_id
execute unless data storage graves:main players run data modify storage graves:main players set value []
schedule function graves:schedule_1s 10
function graves:update_allow_locating