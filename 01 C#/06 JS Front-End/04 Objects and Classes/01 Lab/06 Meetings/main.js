function solve(inputArr) {
    let schedule = {};

    for (element of inputArr) {
        const [weekday, name] = element.split(' ');

        if (schedule.hasOwnProperty(weekday)) {
            console.log(`Conflict on ${weekday}!`);
            continue;
        }

        schedule[weekday] = name;
        console.log(`Scheduled for ${weekday}`);
    }

    for (key in schedule) {
        console.log(`${key} -> ${schedule[key]}`);
    }
}
