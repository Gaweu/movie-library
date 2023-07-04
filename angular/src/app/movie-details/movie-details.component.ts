import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { MovieapiService } from '../movieapi.service';

@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.scss']
})
export class MovieDetailsComponent implements OnInit {

  reviewList$!:Observable<any[]>;
  data: any;
  id: any;

  constructor(private route: ActivatedRoute, private service:MovieapiService) { }
  

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.id = params.get('id');
          console.log(this.id);
    });

    this.service.getSingleMovie(this.id).subscribe(response => this.data = response);
    this.reviewList$ = this.service.getReviews(this.id);
  }



}
