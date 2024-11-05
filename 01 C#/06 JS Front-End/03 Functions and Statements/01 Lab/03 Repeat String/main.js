function solve(text, repeatCount) {
    console.log(repeat(text, repeatCount));

    function repeat(text, repeatCount) {
        let result = text;

        for (let i = 1; i < repeatCount; i++) {
            result += text;
        }

        return result;
    }
}




//2
function solve(text, repeatCount) {
    console.log(repeat(text, repeatCount));

    function repeat(text, repeatCount) {
        return text.repeat(repeatCount);
    }
}




//3
function solve(text, repeatCounter) {
    console.log(repeat(text, repeatCounter));

    function repeat(text, repeatCounter) {
        if (repeatCounter == 1) {
            return text
        }

        return text += repeat(text, --repeatCounter);
    }
}