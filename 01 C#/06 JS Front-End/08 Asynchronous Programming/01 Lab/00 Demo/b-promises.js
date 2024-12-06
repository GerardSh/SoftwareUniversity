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

// Promise all - if one rejects all are rejected
Promise.all([
    marriagePromise,
    Promise.resolve('Some promise resolved'),
    'Pesho',
    // Promise.reject('failed operation'),
    20,
])
    .then((result) => {
        console.log(result);
    })
    .catch(err => {
        console.log(err);
    })

// Promise allSettled - some may reject
Promise.allSettled([
    marriagePromise,
    Promise.resolve('Some promise resolved'),
    'Pesho',
    Promise.reject('failed operation'),
    20,
])
    .then((result) => {
        console.log(result);
    })
    .catch(err => {
        console.log(err);
    })

// Promise.race() - resolves the fastest



