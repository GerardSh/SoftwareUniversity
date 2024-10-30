# Methods
## String
`trim()` - изтрива празните пространства от началото и края.
## Number
`Number()` - parse-ва string към number.

`parseFloat()` - parse-ва string към number.

`parseInt()` - parse-ва string към number, като маха ако има остатък.

Разликата между `Number` и другите две е че ако string-a започва с число, то ще вземе числото и няма да върне `NaN`. Примерно при `parseFloat('3test')`, ще върне числото 3.