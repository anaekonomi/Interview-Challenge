import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-search',
  standalone: true,
  imports: [CommonModule, FormsModule, HttpClientModule],
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent {
  searchQuery: string = '';
  movies: any[] = [];
  fallbackImage = 'https://via.placeholder.com/300x445?text=No+Image';

  constructor(private http: HttpClient) {}

  searchMovies() {
    if (!this.searchQuery.trim()) return;

    const apiKey = '902ac39a'; // replace this
    const url = `http://www.omdbapi.com/?i=tt3896198&apikey=${apiKey}&s=${this.searchQuery}`;
    
    this.http.get<any>(url).subscribe(response => {
      if (response.Response === 'True') {
        this.movies = response.Search.slice(0, 3);
      } else {
        this.movies = [];
      }
    });
  }
}
