function solve(input) {
    const n = input.shift();

    const assignees = input.splice(0, n).reduce((agg, curr) => {
        curr = curr.split(':');
        const [assignee, taskId, title, status, estimatedPoints] = [curr[0], curr[1], curr[2], curr[3], Number(curr[4])];

        if (!agg.hasOwnProperty(assignee)) {
            agg[assignee] = [];
        }

        agg[assignee].push({
            taskId,
            title,
            status,
            estimatedPoints
        });

        return agg;
    }, {});

    while (input.length > 0) {
        const [command, assignee, ...arg] = input.shift().split(':');

        switch (command) {
            case 'Add New': {
                const [taskId, title, status, estimatedPoints] = [arg[0], arg[1], arg[2], Number(arg[3])];

                if (!checkAssignee(assignee)) continue;

                assignees[assignee].push({
                    taskId,
                    title,
                    status,
                    estimatedPoints
                })
            }
                break;
        }
        switch (command) {
            case 'Change Status': {
                const [taskId, newStatus] = arg;

                if (!checkAssignee(assignee)) continue;

                const currentTask = assignees[assignee].filter(x => x.taskId === taskId);

                if (currentTask.length === 0) {
                    console.log(`Task with ID ${taskId} does not exist for ${assignee}!`);
                    continue;
                }

                currentTask[0].status = newStatus;
            }
                break;
        }
        switch (command) {
            case 'Remove Task': {
                let index = Number(arg[0]);

                if (!checkAssignee(assignee)) continue;

                if (assignees[assignee].length <= index || index < 0) {
                    console.log("Index is out of range!");
                    continue;
                }

                assignees[assignee].splice(index, 1);
            }
                break;
        }
    }

    let toDo = 0;
    let inProgress = 0;
    let code = 0;
    let done = 0;

    Object.values(assignees).forEach(curr => {
        curr.forEach(obj => {
            if (obj.status === 'ToDo') toDo += obj.estimatedPoints;
            if (obj.status === 'In Progress') inProgress += obj.estimatedPoints;
            if (obj.status === 'Code Review') code += obj.estimatedPoints;
            if (obj.status === 'Done') done += obj.estimatedPoints;
        })
    });

    console.log(`ToDo: ${toDo}pts`);
    console.log(`In Progress: ${inProgress}pts`);
    console.log(`Code Review: ${code}pts`);
    console.log(`Done Points: ${done}pts`);

    if (done >= inProgress + code + toDo) {
        console.log('Sprint was successful!');
    } else {
        console.log('Sprint was unsuccessful...');
    }

    function checkAssignee(assignee) {
        if (!assignees[assignee]) {
            console.log(`Assignee ${assignee} does not exist on the board!`);
            return false;
        }

        return true;
    }
}
