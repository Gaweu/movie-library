import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http'
import { MovieapiService } from '../movieapi.service';

@Component({
  selector: 'app-movie-review',
  templateUrl: './movie-review.component.html',
  styleUrls: ['./movie-review.component.scss']
})
export class MovieReviewComponent implements OnInit {

  id: any;

  constructor(private route: ActivatedRoute, private service:MovieapiService, private router:Router) { }
  

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.id = params.get('id');
          console.log(this.id);
    });
  }

  
  onReviewCreate(reviews: {username: string, review: string, rating: number})
  {
    console.log(reviews);
    this.service.insertReview(this.id, reviews);
  }

  onSubmit()
  {
    this.router.navigate([`Details/${this.id}`]);
  }

}
