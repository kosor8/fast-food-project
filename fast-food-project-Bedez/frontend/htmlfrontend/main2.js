document.addEventListener('DOMContentLoaded', function () {
    // Slider Kodlarý
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

    // SCROLL ANÝMASYON KODU
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
    let sesCaldi = false; // Bir bayrak deðiþkeni tanýmlýyoruz

    document.addEventListener("click", function oncePlay() {
        if (ses && !sesCaldi) { // Ses elementinin varlýðýný ve daha önce çalýnýp çalýnmadýðýný kontrol ediyoruz
            ses.play().then(() => {
                sesCaldi = true; // Ses baþarýyla çalýndýysa bayraðý true yapýyoruz
                document.removeEventListener("click", oncePlay); // Event listener'ý kaldýrýyoruz
            }).catch(error => {
                console.error("Ses çalýnýrken bir hata oluþtu:", error);
                document.removeEventListener("click", oncePlay); // Hata olsa bile event listener'ý kaldýrýyoruz ki tekrar tekrar denenmesin
            });
        } else if (!ses) {
            console.warn("Uyarý: 'intro-sound' id'li ses elementi bulunamadý.");
            document.removeEventListener("click", oncePlay); // Ses elementi yoksa bile event listener'ý kaldýrýyoruz
        } else {
            document.removeEventListener("click", oncePlay); // Eðer ses zaten çaldýysa event listener'ý kaldýrýyoruz
        }
    });
});