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

// Fetching Movie Data from API
var requestOptions = {
  method: 'GET',
  redirect: 'follow'
};
var movies = [];

fetch("https://localhost:7256/api/Movie/get-all-movies", requestOptions)
  .then(response => response.text())
  .then(result => {
    movies = result;
    // Call function to create movie cards
    movieCards(movies);
  })
  .catch(error => console.log('error', error));

// movie card//
function movieCards(data) {
  var records = JSON.parse(data);

  records.forEach(i => {
    let cardWrapper = document.querySelector(".movie-wrapper");
    let card = document.createElement("div");
    card.classList.add("movie-card", i.genre, "display");
    let img = document.createElement("div");
    img.classList.add("img");
    card.appendChild(img);
    let cardImg = document.createElement("img");
    cardImg.setAttribute("src", `https://localhost:7256/${i.coverPhoto}`);
    img.appendChild(cardImg);
    let dwBtn = document.createElement("div");
    dwBtn.classList.add("dw-btn");
    let playIcon = document.createElement("i");
    playIcon.classList.add("icofont-ui-play");
    dwBtn.appendChild(playIcon);
    img.appendChild(dwBtn);

    // card info//
    let cardInfo = document.createElement("div");
    card.appendChild(cardInfo);
    cardInfo.classList.add("movie-card-info");
    let nameRatting = document.createElement("div");
    nameRatting.classList.add("name-ratting");
    cardInfo.appendChild(nameRatting)
    let moviename = document.createElement("p");
    moviename.classList.add("movie-name");
    moviename.innerText = i.title;
    nameRatting.appendChild(moviename);
    let ratting = document.createElement("div");
    ratting.classList.add("ratting");
    let ratIcon = document.createElement("i");
    ratIcon.classList.add("icofont-star");
    ratting.appendChild(ratIcon)
    let ratNumber = document.createElement("p");
    ratNumber.innerText = i.rating;
    ratting.appendChild(ratNumber);
    nameRatting.appendChild(ratting);
    let customerReview = document.createElement("div");
    customerReview.classList.add("customer-review");
    cardInfo.appendChild(customerReview);
    let like = document.createElement("div")
    like.classList.add("like");
    customerReview.appendChild(like);
    let likeIcon = document.createElement("i");
    likeIcon.classList.add("icofont-like");
    like.appendChild(likeIcon);
    let likeNum = document.createElement("p");
    likeNum.innerText = i.likes;
    like.appendChild(likeNum);
    let see = document.createElement("div");
    see.classList.add("see");
    customerReview.appendChild(see);
    let seeIcon = document.createElement("i");
    seeIcon.classList.add("icofont-eye-alt");
    see.appendChild(seeIcon);
    let seeNum = document.createElement("p");
    seeNum.innerText = i.views;
    see.appendChild(seeNum);

    let download = document.createElement("div");
    download.classList.add("dw");
    customerReview.appendChild(download);
    let dwIcon = document.createElement("i");
    dwIcon.classList.add("icofont-download");
    download.appendChild(dwIcon);
    let dwNum = document.createElement("p");
    dwNum.innerText = i.downloads;
    download.appendChild(dwNum);
    cardWrapper.appendChild(card);
  }
  );

}

// Filtering Movie Cards based on Category
function filterFunction(value) {
  // Adding or removing 'btnActive' class based on the selected category
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
    // Showing or hiding movie cards based on the selected category
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


// navbar color//
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

// prelaer//
let loader = document.querySelector(".preloader");
function preloader() {
  loader.style.display = "none";
}
preloader();