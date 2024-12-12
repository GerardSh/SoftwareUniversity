function solve(input) {
    let message = input.shift();

    while (input.length > 0) {
        const elements = input.shift();
        if (elements === 'Buy') {
            break;
        }

        const [command, ...arg] = elements.split('?');

        switch (command) {
            case 'TakeEven': {
                message = Array.from(message).filter((_, index) => index % 2 == 0).join('');
                console.log(message);
            }
                break;
            case 'ChangeAll': {
                let [substring, replacement] = arg;

                while (message.includes(substring)) {
                    message = message.replace(substring, replacement);
                }

                console.log(message);
            }
                break;
            case 'Reverse': {
                const substring = arg[0];

                let startIndex = message.indexOf(substring);

                if (startIndex > -1) {
                    message = message.replace(substring, '');
                    message += substring.split('').reverse().join('');
                    console.log(message);
                    continue;
                }
                console.log('error');
            }
                break;
        }
    }

    console.log(`The cryptocurrency is: ${message}`);
}
