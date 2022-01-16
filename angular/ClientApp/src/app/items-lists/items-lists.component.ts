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
    http.get<Item[]>(baseUrl + "item/getAll").subscribe(
      (result) => {
        this.items = result;
      },
      (error) => console.error(error)
    );
  }

  ngOnInit() {}
  public edit(id: number) {}
  public delete(id: number) {
    var json: object = this.http
      .delete("https://localhost:5001/item?id=" + id, { responseType: "text" })
      .subscribe((data) => {
        console.log(data);
        window.location.reload();
      });
  }
  // addItem(event: any) {
  //   console.log("submitting...");
  //   console.log(event.target);
  //   console.log(event.target.itemName.value);
  //   console.log(event.target.itemBrand.value);

  //   return event.target.itemName.value;
  // }
  public addItem(event: any) {
    console.debug("adding...");
    console.debug();
    this.http
      .post(
        "https://localhost:5001/item",
        {
          name: event.target.itemName.value,
          brand: event.target.itemBrand.value,
        },
        { responseType: "text" }
      )
      .subscribe((data) => {
        console.log(data);
        window.location.reload();
      });
  }
}
interface Item {
  id: number;
  name: string;
  brand: string;
}


