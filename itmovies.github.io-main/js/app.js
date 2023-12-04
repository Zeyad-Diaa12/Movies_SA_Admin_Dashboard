
// Initialize Swiper for the home section with autoplay and pagination
var swiper = new Swiper(".home", {
  // spaceBetween: 30,
  centeredSlides: true,
  autoplay: {
    delay: 2500,
    disableOnInteraction: false,
  },
  pagination: {
    el: ".swiper-pagination",
    clickable: true,
  },

});


const userData = localStorage.getItem('userData');

if (userData) {
  // Get the login and signup links by their IDs
  const loginLink = document.getElementById('login-link');
  const signupLink = document.getElementById('signup-link');
  const logOut = document.getElementById('logout-link');
  logOut.style.display = 'block';

  // Check if the links exist before attempting to remove them
  if (loginLink) {
    loginLink.remove();
  }

  if (signupLink) {
    signupLink.remove();
  }
}

function logoutUser() {
  // Clear user data from localStorage
  localStorage.removeItem('userData');
  
  window.location.href = 'log in.html';
}

// Initialize Swiper for the latest container with coverflow effect and looping
var swiper = new Swiper(".letest-container", {
  effect: "coverflow",
  // spaceBetween:10,
  grabCursor: true,
  centeredSlides: true,
  slidesPerView: "auto",
  coverflowEffect: {
    rotate: 0,
    stretch: 0,
    depth: 0,
    modifier: 1,
    slideShadows: true,
  },
  loop: true,
});

// Initialize Swiper for the coming soon section with coverflow effect and looping
var swiper = new Swiper(".comming-soon", {
  effect: "coverflow",
  // spaceBetween:10,
  grabCursor: true,
  centeredSlides: true,
  slidesPerView: "auto",
  coverflowEffect: {
    rotate: 0,
    stretch: 0,
    depth: 0,
    modifier: 1,
    slideShadows: true,
  },
  loop: true,
});

// tv shows
var swiper = new Swiper(".tv-container", {
  effect: "coverflow",
  // spaceBetween:10,
  grabCursor: true,
  centeredSlides: true,
  slidesPerView: "auto",
  coverflowEffect: {
    rotate: 0,
    stretch: 0,
    depth: 0,
    modifier: 1,
    slideShadows: true,
  },
  loop: true,
});

// Handling the click event for the "Watch" button to display and control a video player
let videoContainer = document.querySelector(".trailer-box")
let close = document.querySelector(".close");
let watch = document.querySelector(".watch-btn");
let play = document.querySelector(".play");
let video = document.getElementById("videoHome");
watch.addEventListener("click", () => {
  videoContainer.style.display = "flex";
  play.addEventListener("click", () => {
    if (video.paused) {
      video.play()
      play.classList.remove("icofont-ui-play");
      play.classList.add("icofont-ui-pause");
    } else {
      play.classList.add("icofont-ui-play");
      play.classList.remove("icofont-ui-pause");
      video.pause();
    }
  })
  close.addEventListener("click", () => {
    videoContainer.style.display = "none";
    video.pause();
  })
})

// Hide the preloader once the page is loaded
let loader = document.querySelector(".preloader");
function preloader() {
  loader.style.display = "none";
}
preloader();

// -----------------nav bar----------------///
const ul = document.querySelector("ul");
console.log(ul);
const li = document.querySelectorAll("li");
const toggle = document.querySelector(".toggle");
toggle.addEventListener("click", () => {
  toggle.classList.toggle("active-toggle");
  ul.classList.toggle("ul-active")
  li.forEach((item) => {
    item.classList.toggle("li-active");
  })
})

// Function to filter movie cards based on category
function filterFunction(value) {
  let filterBtn = document.querySelectorAll(".btn-filter");
  let card = document.querySelectorAll(".movie-card");
  filterBtn.forEach((btn) => {
    if (btn.innerText.toUpperCase() == value.toUpperCase()) {
      btn.classList.add("btnActive");
    } else {
      btn.classList.remove("btnActive");
    }
  })
  card.forEach((cardItem, index) => {
    if (value == "all") {
      card[index].classList.remove("display")
    } else {
      if (card[index].classList.contains(value)) {
        card[index].classList.remove("display")
      } else {
        card[index].classList.add("display")
      }
    }
  })
}

// Handling the search functionality for movie cards
let searchBtn = document.querySelector(".searchbtn");
searchBtn.addEventListener("click", () => {
  let searchbox = document.querySelector(".movieSearcher");
  let searchValue = searchbox.value;
  let searchUppercase = searchValue.toUpperCase();
  let movieNames = document.querySelectorAll(".movie-name");
  movieNames.forEach((movieNAme, index) => {
    let movieUpppercase = movieNAme.textContent.toUpperCase();
    let movieCards = document.querySelectorAll(".movie-card");
    if (movieUpppercase.includes(searchUppercase)) {
      movieCards[index].classList.remove("display");
    } else {
      movieCards[index].classList.add("display");
    }
  })
  document.querySelector(".movieSearcher").value = "";
})

// Clearing the display class when typing in the search box
let searchbox = document.querySelector(".movieSearcher");
searchbox.addEventListener("keyup", () => {
  let movieCards = document.querySelectorAll(".movie-card");
  movieCards.forEach((cards) => {
    cards.classList.remove("display");

  })
})
window.onload = () => {
  filterFunction("all");
}



// Setting up the scroll-to-top functionality


let scroll = document.querySelector(".scroll");
window.addEventListener("scroll", () => {
  if (document.documentElement.scrollTop > 50 || document.body.scrollTop > 50) {
    scroll.style.display = "block";
  } else {
    scroll.style.display = "none";
  }
  scroll.addEventListener("click", () => {
    window.scrollTo({
      top: "0",
      behavior: "smooth",
    })
  })
})


// Changing the navbar color on scroll
window.addEventListener("scroll", () => {
  if (document.documentElement.scrollTop > 30 || document.body.scrollTop > 30) {
    console.log("ll")
    document.querySelector("header").style.background = 'linear-gradient(rgba(0,0,0,0.8),rgba(0,0,0,0.8))';
    document.querySelector("header").style.backdropFilter = "blur(10px)";
  } else {
    document.querySelector("header").style.background = "";
    document.querySelector("header").style.backdropFilter = "blur(0px)";


  }
})

