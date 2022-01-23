import { Component, OnInit, Inject, Input, Output } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { ItemsService } from "../items.service";
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from "../pruduct.service";



@Component({
  selector: "app-items-lists",
  templateUrl: "./items-lists.component.html",
  styleUrls: ["./items-lists.component.css"],
})
export class ItemsListsComponent implements OnInit {
  listId:number;
  router: Router;
  private route: ActivatedRoute;

  public items: Item[];
  public baseURL: string;
  public http: HttpClient;
  public itemService: ItemsService;
  public testValue: string = "Input click!";
  productService: ProductService;
  products: Product[];

  constructor(itemService: ItemsService, router: Router, route: ActivatedRoute, productService: ProductService) {
    this.itemService = itemService;
    this.route = route;
    this.productService = productService;
  }

  async ngOnInit() {
    this.listId = parseInt(this.route.snapshot.paramMap.get('listId'));
    this.itemService.getItems(this.listId).then((item) => (this.items = item));
    this.productService.getProducts().then(p => {
      this.products = p
      
    });
  }
  public edit(id: number) {}
  public delete(id: number) {
    this.itemService.deleteItem(id).then(() => this.ngOnInit());
  }
  public addItem(event: any) {
    console.debug("adding...");
    this.itemService
      .createItem({
        quantity: event.target.itemQuantity.value,
        productId: event.target.productSelectBox.value,
        listId: this.listId
      })
      .then(() => this.ngOnInit());
    
    
  }
  onButtonClick(output:string){
  }

  
}

interface Item {
  id: number;
  name: string;
  brand: string;
  quantity: number;
}


interface Product {
  id: number;
  name: string;
  brand: string;
  categoryId: number;
  categoryName: string;
}
