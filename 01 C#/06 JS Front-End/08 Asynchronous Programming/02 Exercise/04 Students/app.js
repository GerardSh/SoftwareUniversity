function attachEvents() {
  BASE_URL = 'http://localhost:3030/jsonstore/collections/students';
  const [
    firstNameInputEl,
    lastNameInputEl,
    facultyNumInputEl,
    gradeInputEl
  ] = document.querySelectorAll('input');

  const submitBtnEl = document.querySelector('#submit');
  const tableEl = document.querySelector('tbody');

  loadStudents();

  submitBtnEl.addEventListener('click', createStudentHandler);

  function createStudentHandler() {
    const { value: firstName } = firstNameInputEl;
    const { value: lastName } = lastNameInputEl;
    const { value: facultyNumber } = facultyNumInputEl;
    const { value: grade } = gradeInputEl;

    firstNameInputEl.value = '';
    lastNameInputEl.value = '';
    facultyNumInputEl.value = '';
    gradeInputEl.value = '';

    if (!facultyNumber
      || !firstName
      || !lastName
      || !grade) {
      return;
    }

    fetch(BASE_URL, {
      method: 'POST',
      headers: {
        'Content-type': 'application/json',
      },
      body: JSON.stringify(
        {
          firstName,
          lastName,
          facultyNumber,
          grade
        })
    })
      .then(response => response.json())
      .then(result => loadStudents())
      .catch(err => console.log(err.message))

  }

  function loadStudents() {
    tableEl.textContent = '';

    fetch(BASE_URL)
      .then(res => res.json())
      .then(res => {
        students = Object.values(res);

        students.forEach(student => {
          const trEl = document.createElement('tr');
          tableEl.append(trEl);

          Object.keys(student).forEach(key => {
            if (key === '_id') {
              return
            }

            const tdEl = document.createElement('td');
            tdEl.textContent = student[key];
            trEl.append(tdEl);
          })
        })
      })
      .catch(err => console.log(err));
  }
}

attachEvents();
