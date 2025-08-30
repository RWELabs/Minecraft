playsound minecraft:block.stone.break block @a
particle minecraft:poof ~ ~0.3125 ~ 0 0 0 0.05 10
execute summon minecraft:snowball run function graves:opening/kill_name_tag
execute on vehicle run kill @s
kill @s
$data remove storage graves:main players[{uuid: $(owner_uuid)}].graves[{uuid: $(grave_uuid)}]
data remove storage graves:main players[{graves:[]}]
data remove storage graves:main destruction