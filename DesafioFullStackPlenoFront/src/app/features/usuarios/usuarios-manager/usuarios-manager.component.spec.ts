import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UsuariosManagerComponent } from './usuarios-manager.component';

describe('UsuariosManagerComponent', () => {
  let component: UsuariosManagerComponent;
  let fixture: ComponentFixture<UsuariosManagerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UsuariosManagerComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UsuariosManagerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
