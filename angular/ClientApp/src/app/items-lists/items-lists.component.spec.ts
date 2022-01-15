import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemsListsComponent } from './items-lists.component';

describe('ItemsListsComponent', () => {
  let component: ItemsListsComponent;
  let fixture: ComponentFixture<ItemsListsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ItemsListsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ItemsListsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
