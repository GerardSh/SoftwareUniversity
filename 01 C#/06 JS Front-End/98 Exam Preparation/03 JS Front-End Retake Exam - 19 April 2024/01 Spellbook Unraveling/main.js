function solve(input) {
    let spell = input.shift();

    while (input.length > 0) {
        const elements = input.shift();
        if (elements === 'End') {
            break;
        }

        const [command, ...arg] = elements.split('!');

        switch (command) {
            case 'RemoveEven': {
                spell = Array.from(spell).filter((ch, index) => index % 2 == 0).join('');
                console.log(spell);
            }
                break;
            case 'TakePart': {
                let [startIndex, endIndex] = [Number(arg[0]), Number(arg[1])];

                if (startIndex < 0 || endIndex > spell.length || startIndex > endIndex) {
                    continue;
                }

                spell = spell.slice(startIndex, endIndex);
                console.log(spell);
            }
                break;
            case 'Reverse': {
                const substring = arg[0];

                let startIndex = spell.indexOf(substring);

                if (startIndex > -1) {
                    spell = spell.replace(substring, '');
                    spell += substring.split('').reverse().join('');
                    console.log(spell);
                    continue;
                }
                console.log('Error');
            }
                break;
        }
    }

    console.log(`The concealed spell is: ${spell}`);
}
