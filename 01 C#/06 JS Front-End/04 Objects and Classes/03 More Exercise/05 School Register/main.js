function solve(input) {
    let studentsByGrades = input.reduce((students, currentStudent) => {
        const parts = currentStudent.split(', ');
        const [, name] = parts[0].split(': ');
        let [, grade] = parts[1].split(': ');
        const score = Number(parts[2].split(': ')[1]);

        let student = {
            name,
            grade,
            score
        }

        if (score >= 3) {
            grade++;

            if (!students[grade]) {
                students[grade] = [];
            }

            students[grade].push(student);
        }

        return students;
    }, {})

    for (let [grade, students] of Object.entries(studentsByGrades).sort((a, b) => Number(b) - Number(a))) {
        console.log(`${grade} Grade`);

        const gradeInfo = (Object.values(students).reduce((info, student) => {
            info.studentList.push(student.name);
            info.allGrades += student.score;
            return info;
        }, {
            studentList: [],
            allGrades: 0,

            getList() {
                return `List of students: ${this.studentList.join(', ')}`
            },

            getAverageScore() {
                return `Average annual score from last year: ${(this.allGrades / this.studentList.length).toFixed(2)}\n`;
            }
        }));

        console.log(gradeInfo.getList());
        console.log(gradeInfo.getAverageScore());
    }
}
