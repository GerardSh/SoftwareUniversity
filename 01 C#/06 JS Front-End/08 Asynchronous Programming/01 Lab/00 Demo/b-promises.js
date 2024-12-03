// Create promise
const marriagePromise = new Promise((resolve, reject) =>
    setTimeout(() => {
        if (Math.random() < 0.5) {
            resolve('Just Married!');
        } else {
            reject('The marriage got canceled!');
        }
    }, 2000))

// Pending state
console.log(marriagePromise);

// Consume promise
marriagePromise
    .then((result) => { // Fulfilled state
        console.log(result);
    })
    .catch((reason) => { // Failed state
        console.log(reason);
    })
    .finally(() => {
        console.log('Pay the wedding');
    });
