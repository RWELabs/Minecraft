execute positioned ~ ~1 ~ if function graves:placement/is_repelling positioned ~ ~-1 ~ run return run function graves:placement/stop
execute if block ~ ~ ~ #graves:grave_stopping_on_top run return run function graves:placement/stop
execute if block ~ ~1 ~ #graves:grave_stopping_on_bottom run return run function graves:placement/stop
execute positioned ~ ~1 ~ unless predicate graves:placement/should_grave_float run return run function graves:placement/stop
execute positioned ~ ~1 ~ run function graves:placement/float