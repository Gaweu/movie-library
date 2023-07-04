import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { MovieapiService } from '../movieapi.service';

@Component({
  selector: 'app-movielist',
  templateUrl: './movielist.component.html',
  styleUrls: ['./movielist.component.scss']
})
export class MovielistComponent implements OnInit {

  movieList$!:Observable<any[]>;
  recommendedList$!:Observable<any[]>;
  page: number = 1;
  counter: number = 0;
  hideAdd = true;

  constructor(private service:MovieapiService, private route:ActivatedRoute) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      if(params['searchTerm'])
      this.movieList$ = this.service.getMovieByName(params['searchTerm'], this.page);
      else
      this.movieList$ = this.service.getMovieList(this.page);
    })
  }

  nextPage() {
    this.page++;
    this.ngOnInit();
  }

  previousPage() {
    if(this.page > 1)
    {
      this.page--;
      this.ngOnInit();
    }
  }

  goToFirstPage() {
    this.page = 1;
    this.ngOnInit();
  }

  getRecommended() {
    this.recommendedList$ = this.service.getRecommendations();
  }

  showRecommended() {
    this.movieList$ = this.service.getRecommendations();
  }

  addRecommended(id: number) {
    this.service.insertRecommendation(id);
  }

  hideAddRecommended() {
    this.hideAdd = false;
  }

  displayAddRecommended() {
    this.hideAdd = true;
  }

}
