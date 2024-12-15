function solve(input) {
    const n = input.shift();

    const farmers = input.splice(0, n).reduce((agg, curr) => {
        let [name, area, tasks] = curr.split(' ');
        tasks = tasks.split(',');

        agg[name] = { area, tasks };
        return agg;
    }, {})


    while (input[0] != 'End') {
        const [command, name, ...arg] = input.shift().split(' / ');
        const currentFarmer = farmers[name];

        if (!currentFarmer) {
            continue;
        }

        switch (command) {
            case 'Execute': {
                const [area, task] = arg;

                if (currentFarmer.area === area && currentFarmer.tasks.includes(task)) {
                    console.log(`${name} has executed the task: ${task}!`);
                    continue;
                }

                console.log(`${name} cannot execute the task: ${task}.`);
            }
                break;
            case 'Change Area': {
                let newArea = arg[0];
                currentFarmer.area = newArea;

                console.log(`${name} has changed their work area to: ${newArea}`);
            }
                break;
            case 'Learn Task': {
                const newTask = arg[0];

                if (currentFarmer.tasks.includes(newTask)) {
                    console.log(`${name} already knows how to perform ${newTask}.`);
                    continue;
                }

                currentFarmer.tasks.push(newTask);
                console.log(`${name} has learned a new task: ${newTask}.`);
            }
                break;
        }
    }

    for (const farmer in farmers) {
        console.log(`Farmer: ${farmer}, Area: ${farmers[farmer].area}, Tasks: ${farmers[farmer].tasks.sort((a, b) => a.localeCompare(b)).join(', ')}`);
    }
}

// Created on: 15/12/2024 09:25:39
