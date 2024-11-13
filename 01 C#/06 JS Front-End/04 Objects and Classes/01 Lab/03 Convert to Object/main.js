function solve(objectJSON) {
    let receivedObject = JSON.parse(objectJSON);

    for (let key in receivedObject) {
        console.log(`${key}: ${receivedObject[key]}`);
    }
}
