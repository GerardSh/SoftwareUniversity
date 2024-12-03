function callback() {
    debugger;
    console.log('Second');
}

function main() {
    debugger;
    console.log('First');

    setTimeout(callback, 0);

    console.log('Third');
}

main();

// Output:
// First
// Third
// Second
