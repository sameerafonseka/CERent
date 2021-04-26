/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { GlobalAleartService } from './global-aleart.service';

describe('Service: GlobalAleart', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [GlobalAleartService]
    });
  });

  it('should ...', inject([GlobalAleartService], (service: GlobalAleartService) => {
    expect(service).toBeTruthy();
  }));
});
