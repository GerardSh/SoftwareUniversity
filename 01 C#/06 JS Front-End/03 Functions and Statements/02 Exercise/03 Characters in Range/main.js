function solve(charOne, charTwo) {
    const startIndex = charOne.charCodeAt(0) < charTwo.charCodeAt(0) ? charOne.charCodeAt(0) : charTwo.charCodeAt(0);
    const endIndex = charOne.charCodeAt(0) > charTwo.charCodeAt(0) ? charOne.charCodeAt(0) : charTwo.charCodeAt(0);

    let chars = [];

    for (let i = startIndex + 1; i < endIndex; i++) {
        chars.push(String.fromCharCode(i));
    }

    console.log(chars.join(' '));
}
