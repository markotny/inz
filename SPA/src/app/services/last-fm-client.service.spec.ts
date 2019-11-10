import { TestBed } from '@angular/core/testing';

import { LastFmClientService } from './last-fm-client.service';

describe('LastFmClientService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: LastFmClientService = TestBed.get(LastFmClientService);
    expect(service).toBeTruthy();
  });
});
