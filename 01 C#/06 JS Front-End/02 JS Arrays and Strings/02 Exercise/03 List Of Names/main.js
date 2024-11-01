function solve(names = []) {
    names.sort((nameA, nameB) => nameA.localeCompare(nameB));

    console.log(names.map((name, index) => `${index + 1}.${name}`).join('\r\n'));
}