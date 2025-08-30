$data modify storage graves:main location.graves set from storage graves:main players[{uuid: $(player_uuid)}].graves
execute store result score $max_listing_number graves.dummy run data get storage graves:main location.graves
execute if score $max_listing_number graves.dummy matches 0 run return run tellraw @s {"color":"red","text":"You don't have any graves."}
execute if score $first_listing_number graves.dummy > $max_listing_number graves.dummy run return run tellraw @s [{"color":"red","text":"Page number "},{"storage":"graves:main","nbt":"location.page_number"}," is too large."]
scoreboard players operation $last_listing_number graves.dummy < $max_listing_number graves.dummy
data modify storage graves:main location.previous_link_text set value '["              ",{"text":" ","bold":true}]'
$execute unless data storage graves:main location{previous_page_number: 0} run data modify storage graves:main location.previous_link_text set value '{"color":"gold","text":" < Previous ","hoverEvent":{"action":"show_text","contents":[{"color":"gray","text":"Click to run "},{"color":"white","text":"/trigger graves set $(previous_page_number)"},"."]},"clickEvent":{"action":"run_command","value":"/trigger graves set $(previous_page_number)"}}'
$execute unless score $last_listing_number graves.dummy = $max_listing_number graves.dummy run data modify storage graves:main location.next_link_text set value '["        ",{"color":"gold","text":" Next > ","hoverEvent":{"action":"show_text","contents":[{"color":"gray","text":"Click to run "},{"color":"white","text":"/trigger graves set $(next_page_number)"},"."]},"clickEvent":{"action":"run_command","value":"/trigger graves set $(next_page_number)"}}]'
tellraw @s ["",{"color":"dark_gray","strikethrough":true,"text":"                                                                                "},"\n",{"storage":"graves:main","nbt":"location.previous_link_text","interpret":true},"        ","Your Graves",[{"color":"gray","text":" ("},{"score":{"name":"$first_listing_number","objective":"graves.dummy"}},"-",{"score":{"name":"$last_listing_number","objective":"graves.dummy"}}," of ",{"score":{"name":"$max_listing_number","objective":"graves.dummy"}},")"],{"storage":"graves:main","nbt":"location.next_link_text","interpret":true},"\n",{"color":"dark_gray","strikethrough":true,"text":"                                                                                "}]
$data modify storage graves:main location.grave_listing set from storage graves:main location.graves[-$(listing_number_0)]
function graves:location/show_grave
data remove storage graves:main location.grave_listing
$data modify storage graves:main location.grave_listing set from storage graves:main location.graves[-$(listing_number_1)]
execute unless data storage graves:main location.grave_listing run return run tellraw @s {"color":"dark_gray","strikethrough":true,"text":"                                                                                "}
function graves:location/show_grave
data remove storage graves:main location.grave_listing
$data modify storage graves:main location.grave_listing set from storage graves:main location.graves[-$(listing_number_2)]
execute unless data storage graves:main location.grave_listing run return run tellraw @s {"color":"dark_gray","strikethrough":true,"text":"                                                                                "}
function graves:location/show_grave
data remove storage graves:main location.grave_listing
$data modify storage graves:main location.grave_listing set from storage graves:main location.graves[-$(listing_number_3)]
execute unless data storage graves:main location.grave_listing run return run tellraw @s {"color":"dark_gray","strikethrough":true,"text":"                                                                                "}
function graves:location/show_grave
data remove storage graves:main location.grave_listing
$data modify storage graves:main location.grave_listing set from storage graves:main location.graves[-$(listing_number_4)]
execute unless data storage graves:main location.grave_listing run return run tellraw @s {"color":"dark_gray","strikethrough":true,"text":"                                                                                "}
function graves:location/show_grave
tellraw @s {"color":"dark_gray","strikethrough":true,"text":"                                                                                "}