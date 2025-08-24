import { TestBed } from '@angular/core/testing';
import { ResolveFn } from '@angular/router';

import { tarefasResolver } from './tarefas.resolver';

describe('tarefasResolver', () => {
  const executeResolver: ResolveFn<boolean> = (...resolverParameters) => 
      TestBed.runInInjectionContext(() => tarefasResolver(...resolverParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeResolver).toBeTruthy();
  });
});
