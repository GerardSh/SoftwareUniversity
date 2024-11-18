function solve(input) {
    let courses = [];

    for (let line of input) {
        let elements = line.split(': ');

        if (elements.length == 2) {
            let [courseName, capacity] = elements;
            capacity = Number(capacity);

            let course = courses.find(x => x.name == courseName);

            if (!course) {
                courses.push({ name: courseName, capacity: capacity, students: [] });
            } else {
                course.capacity += capacity;
            }
        } else {
            elements = line.split(' ');

            let [name, credits] = elements[0].split('[');
            credits = credits.replace(']', '');
            const email = elements[3];
            const studentCourse = elements[5];

            const course = courses.find(x => x.name == studentCourse && x.capacity > 0);

            if (course) {
                course.students.push({ name, email, credits })
                course.capacity -= 1;
            }
        }
    }

    for (const course of courses.sort((a, b) => b.students.length - a.students.length)) {
        console.log(`${course.name}: ${course.capacity} places left`);

        for (let student of course.students.sort((a, b) => b.credits - a.credits)) {
            console.log(`--- ${student.credits}: ${student.name}, ${student.email}`);
        }
    }
}
