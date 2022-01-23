import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../category.service';
import { ProductService } from '../pruduct.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  public products: Products[];
  public categories: Category[];
  public baseURL: string;
  public productService: ProductService;
  public categoryService: CategoryService;
  public testValue: string = "Input click!";

  constructor(productService: ProductService, categoryService: CategoryService) {
    this.productService = productService;
    this.categoryService = categoryService
  }

  async ngOnInit() {
    this.productService.getProducts().then((products) => (this.products = products));
    this.categoryService.getCategories().then(categories => {this.categories = categories})
    
  }
  public edit(id: number) {}
  public delete(id: number) {
    this.productService.deleteProduct(id).then(() => this.ngOnInit());
  }
  public addProduct(event: any) {
    console.debug("adding...");
    console.debug(event.target.categorySelectBox.value);
    // console.debug(event.target.categorySelectBox.categoryId);
    // console.debug(event.target.categorySelectBox.selectedIndex);
    this.productService
      .createProduct({
        name: event.target.productName.value,
        brand: event.target.brandName.value,
        categoryId: event.target.categorySelectBox.value,
      })
      .then(() => this.ngOnInit());
  }
  onButtonClick(output:string){
    console.log(output)
  }


  
}

interface Products {
  id: number;
  name: string;
  brand: string;
  categoryId: number;
  categoryName: string;
}

interface Category {
  id: number;
  name: string;
}
