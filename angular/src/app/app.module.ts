import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule} from '@angular/forms';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MovielistComponent } from './movielist/movielist.component';
import { MovieapiService } from './movieapi.service';
import { MovieReviewComponent } from './movie-review/movie-review.component';
import { RouterModule, Routes } from '@angular/router';
import { MovieDetailsComponent } from './movie-details/movie-details.component';
import { MovieReviewDisplayComponent } from './movie-review-display/movie-review-display.component';
import { MovieSearchComponent } from './movie-search/movie-search.component';

const appRoute: Routes = [
  {path: '', component: MovielistComponent, pathMatch: 'full'},
  {path: 'search/:searchTerm', component: MovielistComponent},
  {path: 'Home', component: MovielistComponent},
  {path: 'search/:searchTerm/Details/:id', component: MovieDetailsComponent},
  {path: 'search/:searchTerm/Review/:id', component: MovieReviewComponent},
  {path: 'Details/:id', component: MovieDetailsComponent},
  {path: 'Review/:id', component: MovieReviewComponent},
]

@NgModule({
  declarations: [									
    AppComponent,
      MovielistComponent,
      MovieReviewComponent,
      MovieDetailsComponent,
      MovieReviewDisplayComponent,
      MovieSearchComponent,
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot(appRoute)
  ],
  providers: [MovieapiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
