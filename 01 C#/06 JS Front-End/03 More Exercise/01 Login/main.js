function solve(input = []) {
    let username = input[0];
    let correctPassword = username.split('').reverse().join('');
    let attempts = 0;
    let output = '';

    for (let i = 1; i < input.length; i++) {
        let passwordAttempt = input[i];
        attempts++;

        if (passwordAttempt === correctPassword) {
            output = `User ${username} logged in.`;
            break;
        } else {
            if (attempts >= 4) {
                output = `User ${username} blocked!`;
                break;
            } else {
                console.log("Incorrect password. Try again.");
            }
        }
    }

    console.log(output);
}