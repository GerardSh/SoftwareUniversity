function solve(input) {
    input
        .map(x => x.split(' / '))
        .map(([heroName, level, items]) => ({
            Hero: heroName,
            level: level,
            items
        }))
        .sort((a, b) => a.level - b.level)
        .forEach(x => console.log(`Hero: ${x.Hero}\r\nlevel => ${x.level}\r\nitems => ${x.items}`));
}
