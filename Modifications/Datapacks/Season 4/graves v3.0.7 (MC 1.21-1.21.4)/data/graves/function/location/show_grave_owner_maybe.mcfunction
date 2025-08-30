execute store success storage graves:main location.changed byte 1.0 run data modify storage graves:main location.owner_uuid set from storage graves:main location.grave_listing.owner_uuid
execute if data storage graves:main location{changed:0b} run return fail
function graves:location/show_grave_owner with storage graves:main location.grave_listing