import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { MovieapiService } from '../movieapi.service';

@Component({
  selector: 'app-movie-review-display',
  templateUrl: './movie-review-display.component.html',
  styleUrls: ['./movie-review-display.component.scss']
})
export class MovieReviewDisplayComponent implements OnInit {

  reviewList$!:Observable<any[]>;
  id: any;

  constructor(private route: ActivatedRoute, private service:MovieapiService) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.id = params.get('id');
          console.log(this.id);
    });

    this.reviewList$ = this.service.getReviews(this.id);
  }

}
