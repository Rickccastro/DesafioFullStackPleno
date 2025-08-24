import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TarefasManagerComponent } from './tarefas-manager.component';

describe('TarefasManagerComponent', () => {
  let component: TarefasManagerComponent;
  let fixture: ComponentFixture<TarefasManagerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TarefasManagerComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TarefasManagerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
