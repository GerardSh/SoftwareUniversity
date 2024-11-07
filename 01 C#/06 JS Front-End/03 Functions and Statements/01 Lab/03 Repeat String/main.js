function repeat(text, repeatCount) {
    let result = text;

    for (let i = 1; i < repeatCount; i++) {
        result += text;
    }

   console.log(result);      
}




//2
function repeat(text, repeatCount) {
    console.log(text.repeat(repeatCount));
}




//3
function repeat(text, repeatCounter) {
    if (repeatCounter == 1) {
        return text
    }

    return text += repeat(text, --repeatCounter);
}
