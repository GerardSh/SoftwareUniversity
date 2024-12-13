function solve(input) {
    const horses = input.shift().split('|');

    while (input[0] != 'Finish') {
        const [command, horse, horse2] = input.shift().split(' ');
        const horseIndex = horses.indexOf(horse);
        const horse2Index = horses.indexOf(horse2);

        switch (command) {
            case 'Retake': {
                if (horseIndex < horse2Index) {
                    const temp = horses[horseIndex];
                    horses[horseIndex] = horses[horse2Index];
                    horses[horse2Index] = temp;

                    console.log(`${horse} retakes ${horse2}.`);
                }
            }
                break;
            case 'Trouble': {
                if (horseIndex > 0) {
                    const temp = horses[horseIndex];
                    horses[horseIndex] = horses[horseIndex - 1];
                    horses[horseIndex - 1] = temp;

                    console.log(`Trouble for ${horse} - drops one position.`);
                }
            }
                break;
            case 'Rage': {
                const difference = horses.length - 1 - horseIndex;

                if (difference == 1) {
                    const temp = horses.splice(horseIndex, 1)[0];
                    horses.push(temp);
                } else if (difference > 1) {
                    const temp = horses.splice(horseIndex, 1)[0];
                    horses.splice(horseIndex + 2, 0, temp)
                }

                console.log(`${horse} rages 2 positions ahead.`);
            }
                break;
            case 'Miracle': {
                horses.push(horses.shift());

                console.log(`What a miracle - ${horses[horses.length - 1]} becomes first.`);
            }
                break;
        }
    }

    console.log(horses.join('->'));
    console.log(`The winner is: ${horses[horses.length - 1]}`);
}
