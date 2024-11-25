function generateReport() {
    const inputCheckBoxesElements = Array.from(document.querySelectorAll('thead input'));
    const allEmployeesData = Array.from(document.querySelectorAll('tbody tr td')).map(x => x.textContent);
    const targetElement = document.getElementById('output');

    let employees = [];

    while (allEmployeesData.length > 0) {
        const tableCols = inputCheckBoxesElements.length;
        const currentEmployeeData = allEmployeesData.splice(0, tableCols);

        const employee = {};

        for (let i = 0; i < inputCheckBoxesElements.length; i++) {
            if (inputCheckBoxesElements[i].checked) {
                const columnName = inputCheckBoxesElements[i].name;
                employee[columnName] = currentEmployeeData[i];
            }
        }

        employees.push(employee);
    }

    targetElement.value = JSON.stringify(employees, null, 2);
}
