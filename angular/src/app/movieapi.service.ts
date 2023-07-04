import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MovieapiService {

readonly movieAPIUrl = "https://localhost:7299/api";

constructor(private http:HttpClient) { }

getMovieList(page: number):Observable<any[]>
{
  return this.http.get<any>(this.movieAPIUrl + `/Movies?page=${page}`);
}

getSingleMovie(id: string):Observable<any>
{
  return this.http.get<any>(this.movieAPIUrl + `/Movies/${id}`);
}

getMovieByName(name: string, page: number):Observable<any[]>
{
  return this.http.get<any>(this.movieAPIUrl + `/Movies/GetMoviesByName/${name}?page=${page}`);
}

insertReview(id: string, body: any)
{
  this.http.post(this.movieAPIUrl + `/Reviews?id=${id}`, body,).subscribe();
}

getReviews(id: string):Observable<any[]>
{
  return this.http.get<any>(this.movieAPIUrl + `/Reviews/${id}`);
}

getRecommendations():Observable<any[]>
{
  return this.http.get<any>(this.movieAPIUrl + `/MoviesRecommended`)
}

insertRecommendation(id: number)
{
  this.http.post(this.movieAPIUrl + `/MoviesRecommended?id=${id}`, null).subscribe();
}


}
