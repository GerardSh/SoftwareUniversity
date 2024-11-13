function solve(firstName, lastName, hairColor) {
    let person = {
        name: firstName,
        lastName,
        hairColor
    };

    let personToJSON = JSON.stringify(person);

    console.log(personToJSON);
}
