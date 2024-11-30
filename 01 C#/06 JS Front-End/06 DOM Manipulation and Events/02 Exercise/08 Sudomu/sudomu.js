document.addEventListener("DOMContentLoaded", solve);

function solve() {
    const [checkBtn, clearBtn] = Array.from(document.querySelectorAll(".buttons input"));
    const rows = Array.from(document.querySelectorAll("tbody > tr"));
    const table = document.querySelector("table");
    const paragraphOutput = document.getElementById("check");

    checkBtn.addEventListener("click", check);
    clearBtn.addEventListener("click", clear);

    function check() {
        let isValid = true;

        for (const row of rows) {
            const rowChildren = Array.from(row.children);

            let numbers = [1, 2, 3];

            for (const child of rowChildren) {
                let inputValue = Number(child.querySelector("input").value);

                let index = numbers.indexOf(inputValue);

                if (index === -1) {
                    isValid = false;
                    break;
                }

                numbers.splice(index, 1);
            }

            if (!isValid) {
                break;
            }
        }

        if (isValid) {
            for (let i = 0; i < 3; i++) {
                let inputNumbers = [];

                for (const row of rows) {
                    const inputValue = Number(row.children[i].querySelector("input").value);
                    inputNumbers.push(inputValue);
                }

                let numbers = [1, 2, 3];

                for (const num of numbers) {
                    let index = inputNumbers.indexOf(num);

                    if (index === -1) {
                        isValid = false;
                        break;
                    }

                    inputNumbers.splice(index, 1);
                }

                if (!isValid) {
                    break;
                }
            }
        }

        table.style.borderWidth = "2px";
        table.style.borderStyle = "solid";

        if (isValid) {
            table.style.borderColor = "green";
            paragraphOutput.textContent = "Success!";
        } else {
            table.style.borderColor = "red";
            paragraphOutput.textContent = "Keep trying ...";
        }
    }

    function clear() {
        for (const row of rows) {
            const rowChildren = Array.from(row.children);

            for (const cell of rowChildren) {
                const input = cell.querySelector("input");
                input.value = "";
            }
        }

        table.style.border = "";
        paragraphOutput.textContent = "";
    }
}
