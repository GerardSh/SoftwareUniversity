function attachGradientEvents() {
    const gradientBoxEl = document.getElementById('gradient');
    const resultEl = document.getElementById('result');

    gradientBoxEl.addEventListener("mousemove", e => {
        const onePercent = e.currentTarget.clientWidth / 100;
        resultEl.textContent = Math.floor((Number(e.offsetX) / onePercent)) + '%';
    })
}
