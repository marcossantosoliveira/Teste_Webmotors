import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { ListaAnunciosComponent } from './lista-anuncios.component';

describe('UsuarioComponent', () => {
  let component: ListaAnunciosComponent;
  let fixture: ComponentFixture<ListaAnunciosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListaAnunciosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListaAnunciosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
