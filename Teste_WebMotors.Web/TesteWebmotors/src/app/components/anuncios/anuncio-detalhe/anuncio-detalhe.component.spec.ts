import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { AnuncioDetalheComponent } from './anuncio-detalhe.component';

describe('AnuncioDetalheComponent', () => {
    let component: AnuncioDetalheComponent;
    let fixture: ComponentFixture<AnuncioDetalheComponent>;
  
    beforeEach(async(() => {
      TestBed.configureTestingModule({
        declarations: [ AnuncioDetalheComponent ]
      })
      .compileComponents();
    }));
  
    beforeEach(() => {
      fixture = TestBed.createComponent(AnuncioDetalheComponent);
      component = fixture.componentInstance;
      fixture.detectChanges();
    });
  
    it('should create', () => {
      expect(component).toBeTruthy();
    });
  });
