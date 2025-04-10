/// <reference lib="es2015" />
class Movie {
    constructor(
        public title: string,
        public overview: string,
        public vote_average: number,
        public vote_count: number,
        public poster_path: string,
        public backdrop_path: string,
        public voteCount : string
    ) {}
}

class MovieApp {
    private moviesContainer: HTMLElement;
    private prevButton: HTMLElement;
    private nextButton: HTMLElement;
    private moviesData: Array<any> = [];
    private currentMovieIndex: number = 0;

    constructor() {
        this.moviesContainer = document.getElementById("movies")!;
        this.prevButton = document.querySelector(".prev")!;
        this.nextButton = document.querySelector(".next")!;

        this.prevButton.addEventListener("click", this.scrollPrev.bind(this));
        this.nextButton.addEventListener("click", this.scrollNext.bind(this));

        this.setupSearch();
        this.fetchMovies();
    }

    private async fetchMovies(query: string = 'spider-man') {
        try {
            const response = await fetch(`https://api.themoviedb.org/3/search/movie?api_key=21d6601622ce880a80939f3c1823ce8e&query=${query}`);
            const data = await response.json();
            
            this.moviesData = data.results.map((movi: any) => new Movie(
                movi.title,
                movi.overview,
                movi.vote_average,
                movi.vote_count,
                movi.poster_path,
                movi.backdrop_path,
                movi.vote_count
            ));
            this.update(this.moviesData[0],0);
            this.displayMovies();
            this.highlightMovie(0);
        } catch (error) {
            console.error("Error fetching movies:", error);
        }
    }

    private displayMovies() {
        this.moviesContainer.innerHTML = "";
        this.moviesData.forEach((movie, index) => {
            if (!movie.poster_path) return;
            const movieElement = document.createElement("div");
            movieElement.classList.add("movie");
            movieElement.innerHTML = `<img src="https://image.tmdb.org/t/p/w500${movie.poster_path}" alt="${movie.title}" data-index="${index}">`;
            this.moviesContainer.appendChild(movieElement);
        });
    }

    private setupSearch() {
        const searchBox = document.getElementById("search-box") as HTMLInputElement;
        const searchButton = document.getElementById("search-button")!;

        searchButton.addEventListener("click", () => {
            if (searchBox.style.display === "none") {
                searchBox.style.display = "block";
                searchBox.focus();
            } else {
                const query = searchBox.value.trim();
                if (query) {
                    this.currentMovieIndex = 0;
                    this.fetchMovies(query);
                }
            }
        });
        searchBox.addEventListener("keypress", (e) => {
            if (e.key === "Enter") {
                const query = searchBox.value.trim();
                if (query) {
                    this.currentMovieIndex = 0;
                    this.fetchMovies(query);
                }
            }
        });
    }


    private update(movie: Movie, index: number) {
        document.body.style.backgroundImage = `url('https://image.tmdb.org/t/p/original${movie.backdrop_path}')`;
        document.getElementById("movie-title")!.textContent = movie.title;

        document.querySelector(".imdb")!.textContent = `${movie.vote_average} (${movie.vote_count})`;

        const movieDescriptionElement = document.getElementById("movie-description")!;
        if (movie.overview.length > 100) {
            movieDescriptionElement.innerHTML = `
                ${movie.overview.substring(0, 150)}
                <a href="#" id="see-more" style="color: goldenrod; text-decoration: none;">... See more</a>
            `;
            const seeMoreLink = document.getElementById("see-more")!;
            seeMoreLink.addEventListener("click", (e) => {
                e.preventDefault();
                movieDescriptionElement.innerHTML = `
                    ${movie.overview} 
                    <a href="#" id="see-less" style="color: goldenrod; text-decoration: none;">See less</a>
                `;
                movieDescriptionElement.style.width = "800px";

                const seeLessLink = document.getElementById("see-less")!;
                seeLessLink.addEventListener("click", (e) => {
                    e.preventDefault();
                    movieDescriptionElement.style.width = "300px";
                    this.update(movie, index);
                });
            });
        } else {
            movieDescriptionElement.textContent = movie.overview;
        }
    }
    private highlightMovie(index: number) {
        const allMovies = Array.from(this.moviesContainer.querySelectorAll(".movie"));
        allMovies.forEach((movieElement) => movieElement.classList.remove("active"));
        const selectedMovie = allMovies[index] as HTMLElement;
        if (selectedMovie) {
            selectedMovie.classList.add("active");
            selectedMovie.scrollIntoView({ behavior: "smooth", inline: "center" , block: "nearest" });
        } 
        else {
            console.error("Selected movie not found!");
        }
    }

    private scrollPrev() {
        if (this.currentMovieIndex <= 0) {
            this.currentMovieIndex = this.moviesData.length;
        }
        const prevMovie = this.moviesData[this.currentMovieIndex - 1];
        this.update(prevMovie, this.currentMovieIndex - 1);
        this.highlightMovie(this.currentMovieIndex - 1);
        this.currentMovieIndex --;
    }

    private scrollNext() {
        if (this.currentMovieIndex >= this.moviesData.length - 1) {
            this.currentMovieIndex = -1;
        }
        const nextMovie = this.moviesData[this.currentMovieIndex + 1];
        this.update(nextMovie, this.currentMovieIndex + 1);
        this.highlightMovie(this.currentMovieIndex + 1);
        this.currentMovieIndex ++;
    }
}

document.addEventListener("DOMContentLoaded", () => {
    new MovieApp();
});