const links = document.querySelectorAll('[data-href]');

for (const link of links)
{
    link.addEventListener('click', () =>
    {
        const href = link.getAttribute('data-href');
        window.open(href);
    });
}

