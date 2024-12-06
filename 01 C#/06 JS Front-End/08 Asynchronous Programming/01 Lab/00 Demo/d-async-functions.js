// Basic syntax - always returns promise
async function asyncFunc(text) {
    return 'Pesho';
}

asyncFunc()
    .then(result => console.log(`Promise - ${result}`));

// Use await
async function getResult() {
    const result = await asyncFunc();

    console.log(`Async function - ${result}`);
}

getResult();
