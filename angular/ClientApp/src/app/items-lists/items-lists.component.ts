import { Component, OnInit, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { ItemsService } from "../items.service";


@Component({
  selector: "app-items-lists",
  templateUrl: "./items-lists.component.html",
  styleUrls: ["./items-lists.component.css"],
})
export class ItemsListsComponent implements OnInit {
  public items: Item[];
  public baseURL: string;
  public http: HttpClient;
  public itemService: ItemsService;
  public testValue: string = "Input click!";

  constructor(itemService: ItemsService) {
    this.itemService = itemService;
  }

  async ngOnInit() {
    this.itemService.getItems().then((item) => (this.items = item));
  }
  public edit(id: number) {}
  public delete(id: number) {
    this.itemService.deleteItem(id);
    this.ngOnInit();
  }
  public addItem(event: any) {
    console.debug("adding...");
    this.itemService.createItem({
      name: event.target.itemName.value,
      brand: event.target.itemBrand.value,
    });
    this.ngOnInit()
    
  }
  onButtonClick(output:string){
    console.log(output)
  }
}

interface Item {
  id: number;
  name: string;
  brand: string;
}


