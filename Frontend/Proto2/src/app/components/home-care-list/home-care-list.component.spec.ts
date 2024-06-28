import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeCareListComponent } from './home-care-list.component';

describe('HomeCareListComponent', () => {
  let component: HomeCareListComponent;
  let fixture: ComponentFixture<HomeCareListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HomeCareListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HomeCareListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
