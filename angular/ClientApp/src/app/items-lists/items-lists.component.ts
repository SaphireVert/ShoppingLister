import { Component, OnInit, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";

@Component({
  selector: "app-items-lists",
  templateUrl: "./items-lists.component.html",
  styleUrls: ["./items-lists.component.css"],
})
export class ItemsListsComponent implements OnInit {
  public items: Item[];
  public baseURL: string;
  public http: HttpClient;

  constructor(http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
    this.baseURL = baseUrl;
    this.http = http;
    http.delete("https://localhost:5001/item?id=18").subscribe(data => {
      console.log(data);
    });
;
    http.get<Item[]>(baseUrl + "item/getAll").subscribe(
      (result) => {
        this.items = result;
        console.debug(this.items);
        // console.debug(this.items[0].id);
      },
      (error) => console.error(error)
    );
  }
  ngOnInit() {}
  public edit(id: number) {
    console.debug("editing...");
    console.debug(id);
  }
  public delete(id: number) {
    console.debug("deleting...");
    console.debug(id);
    this.http.delete("https://localhost:5001/item?id=" + id).subscribe((data) => {
      console.log(data);
    });
  }
  public add() {
    console.debug("adding...");
  }
}
interface Item {
  id: number;
  name: string;
  quantity: string;
}


