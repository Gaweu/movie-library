/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { MovieapiService } from './movieapi.service';

describe('Service: Movieapi', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [MovieapiService]
    });
  });

  it('should ...', inject([MovieapiService], (service: MovieapiService) => {
    expect(service).toBeTruthy();
  }));
});
