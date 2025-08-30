execute unless score $page_number graves.dummy matches 1.. run return run tellraw @s {"color":"red","text":"Invalid page number."}
execute unless data storage graves:main players[0].graves[0] run return run tellraw @s {"color":"red","text":"This world doesn't have any graves."}
execute store result storage graves:main location.page_number int 1.0 run scoreboard players get $page_number graves.dummy
execute store result storage graves:main location.previous_page_number int 1.0 run scoreboard players remove $page_number graves.dummy 1
execute store result storage graves:main location.next_page_number int 1.0 run scoreboard players add $page_number graves.dummy 2
execute store result score $last_listing_number graves.dummy run data get storage graves:main location.previous_page_number 5
execute store result score $first_listing_number graves.dummy store result storage graves:main location.listing_number_0 int 1.0 run scoreboard players add $last_listing_number graves.dummy 1
execute store result storage graves:main location.listing_number_1 int 1.0 run scoreboard players add $last_listing_number graves.dummy 1
execute store result storage graves:main location.listing_number_2 int 1.0 run scoreboard players add $last_listing_number graves.dummy 1
execute store result storage graves:main location.listing_number_3 int 1.0 run scoreboard players add $last_listing_number graves.dummy 1
execute store result storage graves:main location.listing_number_4 int 1.0 run scoreboard players add $last_listing_number graves.dummy 1
data modify storage graves:main location.graves append from storage graves:main players[].graves[]
function graves:location/show_graves/all with storage graves:main location
data remove storage graves:main location