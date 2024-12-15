function solve(input) {
    const n = input.shift();

    const pieces = input.splice(0, n).reduce((agg, curr) => {
        const [piece, composer, key] = curr.split('|');
        agg[piece] = { composer, key }

        return agg;
    }, {})

    while (input[0] != 'Stop') {
        const [command, piece, ...arg] = input.shift().split('|');
        const currentPiece = pieces[piece];

        switch (command) {
            case 'Add': {
                const [composer, key] = arg;

                if (!currentPiece) {
                    pieces[piece] = { composer, key };

                    console.log(`${piece} by ${composer} in ${key} added to the collection!`);
                    continue;
                }

                console.log(`${piece} is already in the collection!`);
            }
                break;
            case 'Remove': {
                if (currentPiece) {
                    delete pieces[piece];

                    console.log(`Successfully removed ${piece}!`);
                    continue;
                }

                console.log(`Invalid operation! ${piece} does not exist in the collection.`);
            }
                break;
            case 'ChangeKey': {
                const newKey = arg[0];

                if (currentPiece) {
                    currentPiece.key = newKey;

                    console.log(`Changed the key of ${piece} to ${newKey}!`);
                    continue;
                }

                console.log(`Invalid operation! ${piece} does not exist in the collection.`);
            }
                break;
        }
    }

    for (const piece in pieces) {
        console.log(`${piece} -> Composer: ${pieces[piece].composer}, Key: ${pieces[piece].key}`);
    }
}
