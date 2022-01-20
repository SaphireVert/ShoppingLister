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
  // public http: HttpClient;
  public itemService: CategoryService;
  public testValue: string = "Input click!";

  constructor(itemService: CategoryService) {
    this.itemService = itemService;
  }

  async ngOnInit() {
    this.itemService.getItems().then((item) => (this.categories = item));
  }
  public edit(id: number) {}
  public delete(id: number) {
    this.itemService.deleteItem(id).then(() => this.ngOnInit());
  }
  public addItem(event: any) {
    console.debug("adding...");
    this.itemService
      .createItem({
        name: event.target.itemName.value,
      })
      .then(() => this.ngOnInit());
    
    
  }
  onButtonClick(output:string){
    console.log(output)
  }

  
}

interface Category {
  id: number;
  name: string;
}

