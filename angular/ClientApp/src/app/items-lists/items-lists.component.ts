import { Component, OnInit, Inject, Input, Output } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { ItemsService } from "../items.service";
import { ActivatedRoute, Router } from '@angular/router';



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


  constructor(itemService: ItemsService, router: Router, route: ActivatedRoute) {
    this.itemService = itemService;
    this.route = route;
  }

  async ngOnInit() {
    console.log("ID:",this.listId);
    this.listId = parseInt(this.route.snapshot.paramMap.get('listId'));
    this.itemService.getItems(this.listId).then((item) => (this.items = item));
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
        brand: event.target.itemBrand.value,
      })
      .then(() => this.ngOnInit());
    
    
  }
  onButtonClick(output:string){
    console.log(output)
  }

  
}

interface Item {
  id: number;
  name: string;
  brand: string;
  quantity: number;
  category: string;
}


