document.addEventListener('DOMContentLoaded', function () {
    // Slider Kodlar�
    const wrapper = document.querySelector(".burger-wrapper");
    const items = document.querySelectorAll(".burger-item");
    const prevBtn = document.querySelector(".geri");
    const nextBtn = document.querySelector(".ileri");
    let currentIndex = 0;
    const totalItems = items.length;

    function updateSlider() {
        wrapper.style.transform = `translateX(-${currentIndex * 100}%)`;
    }

    prevBtn.addEventListener("click", function () {
        currentIndex = (currentIndex - 1 + totalItems) % totalItems;
        updateSlider();
    });

    nextBtn.addEventListener("click", function () {
        currentIndex = (currentIndex + 1) % totalItems;
        updateSlider();
    });

    setInterval(function () {
        currentIndex = (currentIndex + 1) % totalItems;
        updateSlider();
    }, 5000);

    // SCROLL AN�MASYON KODU
    const observerOptions = {
        root: null,
        rootMargin: "0px",
        threshold: 0.4,
    };

    const observer = new IntersectionObserver((entries, observer) => {
        entries.forEach((entry) => {
            if (entry.isIntersecting) {
                entry.target.classList.add("gorundu");
                observer.unobserve(entry.target);
            }
        });
    }, observerOptions);

    const animasyonElementleri = document.querySelectorAll(".animasyon-sol, .animasyon-sag");
    animasyonElementleri.forEach((el) => observer.observe(el));

    // Ses Oynatma
    const ses = document.getElementById("intro-sound");
    let sesCaldi = false; // Bir bayrak de�i�keni tan�ml�yoruz

    document.addEventListener("click", function oncePlay() {
        if (ses && !sesCaldi) { // Ses elementinin varl���n� ve daha �nce �al�n�p �al�nmad���n� kontrol ediyoruz
            ses.play().then(() => {
                sesCaldi = true; // Ses ba�ar�yla �al�nd�ysa bayra�� true yap�yoruz
                document.removeEventListener("click", oncePlay); // Event listener'� kald�r�yoruz
            }).catch(error => {
                console.error("Ses �al�n�rken bir hata olu�tu:", error);
                document.removeEventListener("click", oncePlay); // Hata olsa bile event listener'� kald�r�yoruz ki tekrar tekrar denenmesin
            });
        } else if (!ses) {
            console.warn("Uyar�: 'intro-sound' id'li ses elementi bulunamad�.");
            document.removeEventListener("click", oncePlay); // Ses elementi yoksa bile event listener'� kald�r�yoruz
        } else {
            document.removeEventListener("click", oncePlay); // E�er ses zaten �ald�ysa event listener'� kald�r�yoruz
        }
    });
});