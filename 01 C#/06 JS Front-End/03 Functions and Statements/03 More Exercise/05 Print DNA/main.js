function solve(length) {
    const sequence = "ATCGTTAGGG";
    let sequenceIndex = 0;

    for (let i = 0; i < length; i++) {
        const char1 = sequence[sequenceIndex % sequence.length];
        const char2 = sequence[(sequenceIndex + 1) % sequence.length];

        let row;
        switch (i % 4) {
            case 0:
                row = `**${char1}${char2}**`;
                break;
            case 1:
                row = `*${char1}--${char2}*`;
                break;
            case 2:
                row = `${char1}----${char2}`;
                break;
            case 3:
                row = `*${char1}--${char2}*`;
                break;
        }

        console.log(row);

        sequenceIndex += 2;
    }
}
