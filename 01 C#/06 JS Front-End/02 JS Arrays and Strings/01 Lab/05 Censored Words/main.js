function solve(text = '', worldToReplace = '') {
    console.log(text.replaceAll(worldToReplace, '*'.repeat(worldToReplace.length)));
}