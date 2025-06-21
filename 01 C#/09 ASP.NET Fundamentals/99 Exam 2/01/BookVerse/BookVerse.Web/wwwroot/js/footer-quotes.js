(function () {
    const QUOTES_URL = '/json/book-quotes.json';
    const quoteEl = document.getElementById('footer-quote');
    const btn = document.getElementById('new-quote-btn');

    if (!quoteEl) {
        console.warn('[quotes] #footer-quote not found in DOM');
        return;
    }

    let quotes = [];
    let lastIndex = -1;

    async function ensureQuotes() {
        if (quotes.length) return;
        const res = await fetch(QUOTES_URL, { cache: 'no-cache' });
        if (!res.ok) throw new Error(`Failed to fetch ${QUOTES_URL}: ${res.status}`);
        quotes = await res.json();
        console.log(`[quotes] loaded ${quotes.length} quotes`);
    }

    function pickQuote() {
        if (!quotes.length) return 'Keep reading. 📚';
        let i = Math.floor(Math.random() * quotes.length);
        if (quotes.length > 1 && i === lastIndex) {
            i = (i + 1) % quotes.length;
        }
        lastIndex = i;
        return quotes[i];
    }

    async function updateQuote() {
        try {
            await ensureQuotes();
            quoteEl.classList.add('is-fading');
            const text = pickQuote();
            setTimeout(() => {
                quoteEl.textContent = text;
                quoteEl.classList.remove('is-fading');
            }, 200);
        } catch (err) {
            console.error(err);
            quoteEl.textContent = 'Keep reading. 📚';
            quoteEl.classList.remove('is-fading');
        }
    }

    updateQuote();

    if (btn) btn.addEventListener('click', updateQuote);
})();
