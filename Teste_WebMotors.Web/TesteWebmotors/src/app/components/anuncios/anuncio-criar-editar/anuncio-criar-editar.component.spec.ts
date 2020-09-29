import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { AnuncioCriarEditarComponent } from './anuncio-criar-editar.component';

describe('AnuncioCriarEditarComponent', () => {
    let component: AnuncioCriarEditarComponent;
    let fixture: ComponentFixture<AnuncioCriarEditarComponent>;
  
    beforeEach(async(() => {
      TestBed.configureTestingModule({
        declarations: [ AnuncioCriarEditarComponent ]
      })
      .compileComponents();
    }));
  
    beforeEach(() => {
      fixture = TestBed.createComponent(AnuncioCriarEditarComponent);
      component = fixture.componentInstance;
      fixture.detectChanges();
    });
  
    it('should create', () => {
      expect(component).toBeTruthy();
    });
  });
