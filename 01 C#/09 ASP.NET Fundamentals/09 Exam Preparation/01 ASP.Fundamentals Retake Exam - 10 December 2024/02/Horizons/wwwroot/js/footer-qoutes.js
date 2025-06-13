async function fetchRandomQuote() {
    try {
        const response = await fetch('/json/quotes.json');
        if (!response.ok) {
            throw new Error('Failed to fetch quotes');
        }
        const quotes = await response.json();
        return quotes[Math.floor(Math.random() * quotes.length)];
    } catch (error) {
        console.error('Error fetching quotes:', error);
        return 'Error fetching quote. Please try again later.';
    }
}

async function updateFooterQuote() {
    const quoteElement = document.getElementById("footer-quote");
    const randomQuote = await fetchRandomQuote();
    if (quoteElement) {
        quoteElement.textContent = randomQuote;
    }
}

document.addEventListener("DOMContentLoaded", function () {
    updateFooterQuote();

    const newQuoteButton = document.getElementById("new-quote-btn");
    if (newQuoteButton) {
        newQuoteButton.addEventListener("click", updateFooterQuote);
    }
});
