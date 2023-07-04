import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'MovieApp';

  displayReview = false;
  onPressAddReview()
  {
    this.displayReview = !this.displayReview;
  }

  displayDetails = false;
  onPressShowDetails()
  {
    this.displayDetails = !this.displayDetails;
  }
}
