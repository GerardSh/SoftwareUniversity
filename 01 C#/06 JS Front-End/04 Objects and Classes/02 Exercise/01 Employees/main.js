function solve(input) {
    let employees = {};

    for (employee of input) {
        employees[employee] = employee.length;
    }

    for (employee in employees) {
        console.log(`Name: ${employee} -- Personal Number: ${employees[employee]}`);
    }
}




//2
function solve(input) {
    input
        .map(x => ({ name: x, 'personal number': x.length }))
        .forEach(x => console.log(`Name: ${x.name} -- Personal Number: ${x['personal number']}`));
}
