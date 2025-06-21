let cachedQuotes = [];

async function fetchRandomQuote() {
    try {
        if (cachedQuotes.length === 0) {
            const response = await fetch('/json/quotes.json');
            if (!response.ok) {
                throw new Error('Failed to fetch quotes');
            }
            cachedQuotes = await response.json();
        }

        const randomIndex = Math.floor(Math.random() * cachedQuotes.length);
        return cachedQuotes[randomIndex];
    } catch (error) {
        console.error('Error fetching quotes:', error);
        return "Cooking is love made visible.";
    }
}

async function updateFooterQuote() {
    const quoteElement = document.getElementById("footer-quote");
    if (!quoteElement) return;

    quoteElement.style.opacity = 0;

    const newQuote = await fetchRandomQuote();

    setTimeout(() => {
        quoteElement.textContent = newQuote;
        quoteElement.style.opacity = 1;
    }, 300);
}

document.addEventListener("DOMContentLoaded", function () {
    updateFooterQuote();

    const newQuoteButton = document.getElementById("new-quote-btn");
    if (newQuoteButton) {
        newQuoteButton.addEventListener("click", updateFooterQuote);
    }
});
