function solve(input) {
    const n = input.shift();

    const astronauts = input.splice(0, n).reduce((agg, curr) => {
        let [name, section, skills] = curr.split(' ');
        skills = skills.split(',');

        agg[name] = { section, skills };
        return agg;
    }, {})


    while (input[0] != 'End') {
        const [command, name, ...arg] = input.shift().split(' / ');
        const currentAstronaut = astronauts[name];

        if (!currentAstronaut) {
            continue;
        }

        switch (command) {
            case 'Perform': {
                const [section, skill] = arg;
                if (currentAstronaut.section === section && currentAstronaut.skills.includes(skill)) {
                    console.log(`${name} has successfully performed the skill: ${skill}!`);
                    continue;
                }

                console.log(`${name} cannot perform the skill: ${skill}.`);

            }
                break;
            case 'Transfer': {
                let newSection = arg[0];

                currentAstronaut.section = newSection;

                console.log(`${name} has been transferred to: ${newSection}`);
            }
                break;
            case 'Learn Skill': {
                const newSkill = arg[0];

                if (currentAstronaut.skills.includes(newSkill)) {
                    console.log(`${name} already knows the skill: ${newSkill}.`);
                    continue;
                }

                currentAstronaut.skills.push(newSkill);
                console.log(`${name} has learned a new skill: ${newSkill}.`);
            }
                break;
        }
    }

    for (const astronaut in astronauts) {
        console.log(`Astronaut: ${astronaut}, Section: ${astronauts[astronaut].section}, Skills: ${astronauts[astronaut].skills.sort((a, b) => a.localeCompare(b)).join(', ')}`);
    }
}

// Created on: 19/12/2024 09:13:00