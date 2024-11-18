function solve(input) {
    const leaders = {};
    const leadersArmyCount = {};

    for (inputLine of input) {
        if (inputLine.includes('arrives')) {
            let leader = inputLine.split(' ');
            leader.pop();
            leader = leader.join(' ');

            if (!leaders[leader]) {
                leaders[leader] = [];
            }
        } else if (inputLine.includes(':') && inputLine.includes(',')) {
            const [leader, additionalInformation] = inputLine.split(': ');
            const [name, armyCount] = additionalInformation.split(', ');
            let count = Number(armyCount);

            if (leaders[leader]) {
                leaders[leader].push({ name, count })
            }
        } else if (inputLine.includes('+')) {
            const [name, armyCount] = inputLine.split(' + ');
            const count = Number(armyCount);

            for (leader in leaders) {
                const army = leaders[leader].find(x => x.name == name);

                if (army) {
                    army.count += count;
                }
            }
        } else {
            let leader = inputLine.split(' ');
            leader.pop();
            leader = leader.join(' ');

            delete leaders[leader];
            delete leadersArmyCount[leader];
        }
    }

    for (const leader in leaders) {
        let leaderArmyCount = 0;

        for (const army of leaders[leader]) {
            leaderArmyCount += army.count;
        }

        leadersArmyCount[leader] = leaderArmyCount;
    }

    for (const leader of Object.entries(leaders).sort((a, b) => leadersArmyCount[b[0]] - leadersArmyCount[a[0]])) {
        const leaderName = leader[0];
        const armies = leader[1];

        console.log(`${leaderName}: ${leadersArmyCount[leaderName]}`);

        for (army of armies.sort((a, b) => b.count - a.count)) {
            console.log(`>>> ${army.name} - ${army.count}`);
        }
    }
}
