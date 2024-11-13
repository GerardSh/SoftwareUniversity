function solve(phoneBookData) {
    let phoneBook = {};

    for (contact of phoneBookData) {
        const [name, number] = contact.split(' ');
        phoneBook[name] = number;
    }

    for (let key in phoneBook) {
        console.log(`${key} -> ${phoneBook[key]}`);
    }
}
