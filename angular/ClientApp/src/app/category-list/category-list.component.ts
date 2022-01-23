import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../category.service';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
export class CategoryListComponent implements OnInit {

  public categories: Category[];
  public baseURL: string;
  public itemService: CategoryService;
  public testValue: string = "Input click!";

  constructor(itemService: CategoryService) {
    this.itemService = itemService;
  }

  async ngOnInit() {
    this.itemService.getCategories().then((item) => (this.categories = item));
  }
  public edit(id: number) {}
  public delete(id: number) {
    this.itemService.deleteCategory(id).then(() => this.ngOnInit());
  }
  public addItem(event: any) {
    this.itemService
      .createCategory({
        name: event.target.itemName.value,
      })
      .then(() => this.ngOnInit());
  }

  
}

interface Category {
  id: number;
  name: string;
}

