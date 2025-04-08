var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __generator = (this && this.__generator) || function (thisArg, body) {
    var _ = { label: 0, sent: function() { if (t[0] & 1) throw t[1]; return t[1]; }, trys: [], ops: [] }, f, y, t, g = Object.create((typeof Iterator === "function" ? Iterator : Object).prototype);
    return g.next = verb(0), g["throw"] = verb(1), g["return"] = verb(2), typeof Symbol === "function" && (g[Symbol.iterator] = function() { return this; }), g;
    function verb(n) { return function (v) { return step([n, v]); }; }
    function step(op) {
        if (f) throw new TypeError("Generator is already executing.");
        while (g && (g = 0, op[0] && (_ = 0)), _) try {
            if (f = 1, y && (t = op[0] & 2 ? y["return"] : op[0] ? y["throw"] || ((t = y["return"]) && t.call(y), 0) : y.next) && !(t = t.call(y, op[1])).done) return t;
            if (y = 0, t) op = [op[0] & 2, t.value];
            switch (op[0]) {
                case 0: case 1: t = op; break;
                case 4: _.label++; return { value: op[1], done: false };
                case 5: _.label++; y = op[1]; op = [0]; continue;
                case 7: op = _.ops.pop(); _.trys.pop(); continue;
                default:
                    if (!(t = _.trys, t = t.length > 0 && t[t.length - 1]) && (op[0] === 6 || op[0] === 2)) { _ = 0; continue; }
                    if (op[0] === 3 && (!t || (op[1] > t[0] && op[1] < t[3]))) { _.label = op[1]; break; }
                    if (op[0] === 6 && _.label < t[1]) { _.label = t[1]; t = op; break; }
                    if (t && _.label < t[2]) { _.label = t[2]; _.ops.push(op); break; }
                    if (t[2]) _.ops.pop();
                    _.trys.pop(); continue;
            }
            op = body.call(thisArg, _);
        } catch (e) { op = [6, e]; y = 0; } finally { f = t = 0; }
        if (op[0] & 5) throw op[1]; return { value: op[0] ? op[1] : void 0, done: true };
    }
};
/// <reference lib="es2015" />
var Movie = /** @class */ (function () {
    function Movie(title, overview, vote_average, vote_count, poster_path, backdrop_path, voteCount) {
        this.title = title;
        this.overview = overview;
        this.vote_average = vote_average;
        this.vote_count = vote_count;
        this.poster_path = poster_path;
        this.backdrop_path = backdrop_path;
        this.voteCount = voteCount;
    }
    return Movie;
}());
var MovieApp = /** @class */ (function () {
    function MovieApp() {
        this.moviesData = [];
        this.currentMovieIndex = 4;
        this.moviesContainer = document.getElementById("movies");
        this.prevButton = document.querySelector(".prev");
        this.nextButton = document.querySelector(".next");
        this.prevButton.addEventListener("click", this.scrollPrev.bind(this));
        this.nextButton.addEventListener("click", this.scrollNext.bind(this));
        this.setupSearch();
        this.fetchMovies();
    }
    MovieApp.prototype.fetchMovies = function () {
        return __awaiter(this, arguments, void 0, function (query) {
            var response, data, error_1;
            if (query === void 0) { query = 'spider-man'; }
            return __generator(this, function (_a) {
                switch (_a.label) {
                    case 0:
                        _a.trys.push([0, 3, , 4]);
                        return [4 /*yield*/, fetch("https://api.themoviedb.org/3/search/movie?api_key=21d6601622ce880a80939f3c1823ce8e&query=".concat(query))];
                    case 1:
                        response = _a.sent();
                        return [4 /*yield*/, response.json()];
                    case 2:
                        data = _a.sent();
                        this.moviesData = data.results.map(function (movi) { return new Movie(movi.title, movi.overview, movi.vote_average, movi.vote_count, movi.poster_path, movi.backdrop_path, movi.vote_count); });
                        this.update(this.moviesData[4], 4);
                        this.displayMovies();
                        this.highlightMovie(4);
                        return [3 /*break*/, 4];
                    case 3:
                        error_1 = _a.sent();
                        console.error("Error fetching movies:", error_1);
                        return [3 /*break*/, 4];
                    case 4: return [2 /*return*/];
                }
            });
        });
    };
    MovieApp.prototype.displayMovies = function () {
        var _this = this;
        this.moviesContainer.innerHTML = "";
        this.moviesData.forEach(function (movie, index) {
            if (!movie.poster_path)
                return;
            var movieElement = document.createElement("div");
            movieElement.classList.add("movie");
            movieElement.innerHTML = "<img src=\"https://image.tmdb.org/t/p/w500".concat(movie.poster_path, "\" alt=\"").concat(movie.title, "\" data-index=\"").concat(index, "\">");
            _this.moviesContainer.appendChild(movieElement);
        });
    };
    MovieApp.prototype.setupSearch = function () {
        var _this = this;
        var searchBox = document.getElementById("search-box");
        var searchButton = document.getElementById("search-button");
        searchButton.addEventListener("click", function () {
            if (searchBox.style.display === "none") {
                searchBox.style.display = "block";
                searchBox.focus();
            }
            else {
                var query = searchBox.value.trim();
                if (query) {
                    _this.fetchMovies(query);
                }
            }
        });
        searchBox.addEventListener("keypress", function (e) {
            if (e.key === "Enter") {
                var query = searchBox.value.trim();
                if (query) {
                    _this.fetchMovies(query);
                }
            }
        });
    };
    MovieApp.prototype.update = function (movie, index) {
        var _this = this;
        document.body.style.backgroundImage = "url('https://image.tmdb.org/t/p/original".concat(movie.backdrop_path, "')");
        document.getElementById("movie-title").textContent = movie.title;
        document.querySelector(".imdb").textContent = "".concat(movie.vote_average, " (").concat(movie.vote_count, ")");
        var movieDescriptionElement = document.getElementById("movie-description");
        if (movie.overview.length > 100) {
            movieDescriptionElement.innerHTML = "\n                ".concat(movie.overview.substring(0, 150), "\n                <a href=\"#\" id=\"see-more\" style=\"color: goldenrod; text-decoration: none;\">... See more</a>\n            ");
            var seeMoreLink = document.getElementById("see-more");
            seeMoreLink.addEventListener("click", function (e) {
                e.preventDefault();
                movieDescriptionElement.innerHTML = "\n                    ".concat(movie.overview, " \n                    <a href=\"#\" id=\"see-less\" style=\"color: goldenrod; text-decoration: none;\">See less</a>\n                ");
                movieDescriptionElement.style.width = "800px";
                var seeLessLink = document.getElementById("see-less");
                seeLessLink.addEventListener("click", function (e) {
                    e.preventDefault();
                    movieDescriptionElement.style.width = "300px";
                    _this.update(movie, index);
                });
            });
        }
        else {
            movieDescriptionElement.textContent = movie.overview;
        }
    };
    MovieApp.prototype.highlightMovie = function (index) {
        var allMovies = Array.from(this.moviesContainer.querySelectorAll(".movie"));
        allMovies.forEach(function (movieElement) { return movieElement.classList.remove("active"); });
        var selectedMovie = allMovies[index];
        if (selectedMovie) {
            selectedMovie.classList.add("active");
            selectedMovie.scrollIntoView({ behavior: "smooth", inline: "center", block: "nearest" });
        }
        else {
            console.error("Selected movie not found!");
        }
    };
    MovieApp.prototype.scrollPrev = function () {
        if (this.currentMovieIndex <= 0)
            return;
        var prevMovie = this.moviesData[this.currentMovieIndex - 1];
        this.update(prevMovie, this.currentMovieIndex - 1);
        this.highlightMovie(this.currentMovieIndex - 1);
        this.currentMovieIndex--;
    };
    MovieApp.prototype.scrollNext = function () {
        if (this.currentMovieIndex >= this.moviesData.length - 1)
            return;
        var nextMovie = this.moviesData[this.currentMovieIndex + 1];
        this.update(nextMovie, this.currentMovieIndex + 1);
        this.highlightMovie(this.currentMovieIndex + 1);
        this.currentMovieIndex++;
    };
    return MovieApp;
}());
document.addEventListener("DOMContentLoaded", function () {
    new MovieApp();
});
