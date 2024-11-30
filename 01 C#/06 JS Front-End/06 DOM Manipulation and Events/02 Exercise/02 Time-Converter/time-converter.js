document.addEventListener('DOMContentLoaded', solve);

function solve() {
    const buttonEls = document.querySelectorAll('input[type="submit"]')
        .forEach(el => el.addEventListener('click', (e) => {
            e.preventDefault();

            let days = 0;
            let hours = 0;
            let minutes = 0;
            let seconds = 0;
            let input = Number(e.target.parentElement.children[1].value);

            // 1
            // if (e.target.id == 'daysBtn') {
            //     days = input;
            //     hours = days * 24;
            //     minutes = hours * 60;
            //     seconds = minutes * 60;
            // } else if (e.target.id == 'hoursBtn') {
            //     hours = input;
            //     days = hours / 24;
            //     minutes = hours * 60;
            //     seconds = minutes * 60;
            // } else if (e.target.id == 'minutesBtn') {
            //     minutes = input;
            //     hours = minutes / 60;
            //     days = hours / 24;
            //     seconds = minutes * 60;
            // } else if (e.target.id == 'secondsBtn') {
            //     seconds = input;
            //     minutes = seconds / 60;
            //     hours = minutes / 60;
            //     days = hours / 24;
            // }

            // 2
            if (e.target.id == 'daysBtn') {
                days = input;
            } else if (e.target.id == 'hoursBtn') {
                days = input / 24;
            } else if (e.target.id == 'minutesBtn') {
                days = input / 60 / 24;
            } else if (e.target.id == 'secondsBtn') {
                days = input / 60 / 60 / 24;
            }

            hours = days * 24;
            minutes = hours * 60;
            seconds = minutes * 60;

            const daysInputEl = document.querySelector('input[id="days-input"');
            const hoursInputEl = document.querySelector('input[id="hours-input"');
            const minutesInputEl = document.querySelector('input[id="minutes-input"');
            const secondsInputEl = document.querySelector('input[id="seconds-input"');

            daysInputEl.value = days.toFixed(2);
            hoursInputEl.value = hours.toFixed(2);
            minutesInputEl.value = minutes.toFixed(2);
            secondsInputEl.value = seconds.toFixed(2);
        }));
}
