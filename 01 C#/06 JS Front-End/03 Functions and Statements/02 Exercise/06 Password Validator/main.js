function solve(password) {
    let errorMessages = [];

    if (password.length < 6 || password.length > 10) {
        errorMessages.push('Password must be between 6 and 10 characters');
    }

    if (password.match(/[^A-Za-z0-9]/)) {
        errorMessages.push('Password must consist only of letters and digits');
    }

    let matches = password.match(/[0-9]/g);

    if (!matches || matches.length < 2) {
        errorMessages.push('Password must have at least 2 digits');
    }

    if (errorMessages.length > 0) {
        errorMessages.forEach(x => console.log(x));
    } else {
        console.log('Password is valid');
    }
}

solve('logIn');
