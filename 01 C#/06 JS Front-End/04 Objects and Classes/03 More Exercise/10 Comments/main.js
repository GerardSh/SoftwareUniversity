function solve(input) {
    let users = [];
    let articles = [];

    for (const line of input) {
        const elements = line.split(' ');
        if (elements.length == 2) {
            if (elements[0] == 'user') {
                users.push(elements[1]);
            } else {
                const article = { name: elements[1], comments: [] }
                articles.push(article);
            }
        } else {
            const [username, articleInfo] = line.split(' posts on ');
            const [articleName, commentInfo] = articleInfo.split(': ');
            const [title, content] = commentInfo.split(', ');

            const article = articles.find(x => x.name == articleName);

            if (users.includes(username) && article) {
                article.comments.push({ content: `--- From user ${username}: ${title} - ${content}`, username });
            }
        }
    }

    articles.sort((a, b) => b.comments.length - a.comments.length)
    articles.map(x => x.comments.sort((a, b) => a.username.localeCompare(b.username)))

    for (const article of articles) {
        console.log(`Comments on ${article.name}`);

        for (comment of article.comments) {
            console.log(comment.content);
        }
    }
}
