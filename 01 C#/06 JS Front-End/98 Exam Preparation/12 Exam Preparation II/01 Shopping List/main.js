function solve(input) {
    const groceries = input.shift().split('!');

    while (input[0] != 'Go Shopping!') {
        const [command, item, newItem] = input.shift().split(' ');
        const itemIndex = groceries.indexOf(item);

        switch (command) {
            case 'Urgent': {
                if (!groceries.includes(item)) {
                    groceries.splice(0, 0, item);
                }
            }
                break;
            case 'Correct': {
                if (itemIndex == -1) continue;

                groceries[itemIndex] = newItem;
            }
                break;
            default: {
                if (itemIndex == -1) continue;

                groceries.splice(itemIndex, 1);

                if (command == 'Rearrange') {
                    groceries.push(item);
                }
            }
                break;
        }
    }

    console.log(groceries.join(', '));
}
