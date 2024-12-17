function solve(input) {
    const n = input.shift();

    const points = {
        ToDo: 0,
        'In Progress': 0,
        'Code Review': 0,
        Done: 0
    }

    const assignees = input.splice(0, n).reduce((agg, curr) => {
        const currentLine = curr.split(':');
        const [assignee, taskId, title, status, estimatedPoints] =
            [currentLine[0], currentLine[1], currentLine[2], currentLine[3], Number(currentLine[4])];

        if (!agg.hasOwnProperty(assignee)) {
            agg[assignee] = {};
        }

        agg[assignee][taskId] = {
            title,
            status,
            estimatedPoints
        }

        points[status] += estimatedPoints;

        return agg;
    }, {})

    while (input.length > 0) {
        const [command, assignee, ...arg] = input.shift().split(':');
        const currentAssignee = assignees[assignee];

        switch (command) {
            case 'Add New': {
                const [taskId, title, status, estimatedPoints] = [arg[0], arg[1], arg[2], Number(arg[3])];

                if (!assigneeExist(assignee)) continue;

                currentAssignee[taskId] = {
                    title,
                    status,
                    estimatedPoints
                }

                points[status] += estimatedPoints;
            }
                break;
            case 'Change Status': {
                const [taskId, newStatus] = arg;

                if (!assigneeExist(assignee)) continue;

                if (!assignees[assignee].hasOwnProperty(taskId)) {
                    console.log(`Task with ID ${taskId} does not exist for ${assignee}!`);
                    continue;
                }

                const oldStatus = currentAssignee[taskId].status;
                const oldStatusPoints = currentAssignee[taskId].estimatedPoints;

                points[oldStatus] -= oldStatusPoints;
                points[newStatus] += oldStatusPoints;

                currentAssignee[taskId].status = newStatus;
            }
                break;
            case 'Remove Task': {
                const index = Number(arg[0]);

                if (!assigneeExist(assignee)) continue;

                let counter = 0;
                let deleted = false;

                for (const key in currentAssignee) {
                    if (index == counter++) {
                        const oldStatus = assignees[assignee][key].status;
                        const oldStatusPoints = assignees[assignee][key].estimatedPoints;

                        points[oldStatus] -= oldStatusPoints;
                        delete assignees[assignee][key];

                        deleted = true;
                        break;
                    }
                }

                if (!deleted) {
                    console.log('Index is out of range!');
                }
            }
                break;
        }
    }

    console.log(`ToDo: ${points.ToDo}pts`);
    console.log(`In Progress: ${points['In Progress']}pts`);
    console.log(`Code Review: ${points['Code Review']}pts`);
    console.log(`Done Points: ${points.Done}pts`);

    if (points.ToDo + points['In Progress'] + points['Code Review'] <= points.Done) {
        console.log('Sprint was successful!');
    } else {
        console.log('Sprint was unsuccessful...');
    }

    function assigneeExist(assignee) {
        if (!assignees[assignee]) console.log(`Assignee ${assignee} does not exist on the board!`);
        return !!assignees[assignee]
    }
}
