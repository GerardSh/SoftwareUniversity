function solve(browser, commands) {
    let openedTabs = browser['Open Tabs'];
    let recentlyClosed = browser['Recently Closed'];
    let browserLogs = browser['Browser Logs'];

    for (let command of commands) {
        let [operation, website] = command.split(' ');

        if (operation == 'Open') {
            openedTabs.push(website);
            browserLogs.push(command)
        } else if (operation == 'Close') {
            if (openedTabs.includes(website)) {
                openedTabs.splice(openedTabs.indexOf(website), 1);
                recentlyClosed.push(website);
                browserLogs.push(command);
            }
        } else if (operation == 'Clear') {
            openedTabs.length = 0;
            recentlyClosed.length = 0;
            browserLogs.length = 0;
        }
    }

    console.log(browser['Browser Name']);
    console.log(`Open Tabs: ${openedTabs.join(', ')}`);
    console.log(`Recently Closed: ${browser['Recently Closed'].join(', ')}`);
    console.log(`Browser Logs: ${browser['Browser Logs'].join(', ')}`);
}
