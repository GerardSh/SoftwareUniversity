function solve(typeOfDay, age) {
    let result = null;

    if (age < 0 || age > 122) {
        result = 'Error!'
    } else {
        switch (typeOfDay) {
            case 'Weekday':
                if (age > 18 && age <= 64) {
                    result = '18$';
                } else {
                    result = '12$'
                }
                break;

            case 'Weekend':
                if (age > 18 && age <= 64) {
                    result = '20$';
                } else {
                    result = '15$'
                }
                break;

            case 'Holiday':
                if (age <= 18) {
                    result = '5$';
                } else if (age <= 64) {
                    result = '12$';
                } else {
                    result = '10$';
                }
                break;
        }
    }

    console.log(result);
}