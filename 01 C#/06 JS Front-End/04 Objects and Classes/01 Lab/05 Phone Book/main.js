function solve(entries) {
    let phonebook = {};

    for (contact of entries) {
        const [name, number] = contact.split(' ');
        phonebook[name] = number;
    }

    for (let key in phonebook) {
        console.log(`${key} -> ${phonebook[key]}`);
    }
}
