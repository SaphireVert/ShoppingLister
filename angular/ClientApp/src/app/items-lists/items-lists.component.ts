import { Component, OnInit, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";

@Component({
  selector: 'app-items-lists',
  templateUrl: './items-lists.component.html',
  styleUrls: ['./items-lists.component.css']
})
export class ItemsListsComponent implements OnInit {

  public items: Item[];

  constructor(http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
    http.get<Item[]>(baseUrl + "item/getAll").subscribe(
      (result) => {
        this.items = result;
        console.debug(this.items);
        console.debug(this.items[0].id);
      },
      (error) => console.error(error)
    );
  }
  ngOnInit() {}
  public edit() {
    console.debug("editing...")
  }
  public delete() {
    console.debug("deleting...")
  }
  
}
interface Item {
  id: number;
  name: string;
  quantity: string;
}


