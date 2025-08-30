# input: {
#   components: {}      # components of saved item data,
#   count: 0            # number
#   hand: "mainhand"    # offhand or mainhand
# }

$item modify entity @s weapon.$(hand) {"function": "set_components", "components": $(components)}
$item modify entity @s weapon.$(hand) {"function": "set_count", "count": $(count)}
