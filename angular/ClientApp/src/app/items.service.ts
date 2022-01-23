import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { prototype } from 'events';

@Injectable({
  providedIn: "root",
})
export class ItemsService {
  public items: Item[];
  public baseUrl: string;
  public http: HttpClient;

  constructor(http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
    this.baseUrl = baseUrl;
    this.http = http;
  }

  createItem(item: any): Promise<boolean> {
        return new Promise<boolean>((resolve) => {
          this.http
            .post("https://localhost:5001/item", item, {
              responseType: "text",
            })
            .subscribe((data) => {
              resolve(true);
            });
        });


  }
  deleteItem(id: number): Promise<boolean> {
    return new Promise<boolean>((resolve) => {
      var json: object = this.http
        .delete("https://localhost:5001/item?id=" + id, {
          responseType: "text",
        })
        .subscribe((data) => {
          resolve(true);
        });
    });
  }
  getItems(id:number): Promise<Item[]> {
    return new Promise<Item[]>((resolve) => {
      this.http.get<Item[]>(this.baseUrl + "item/fromList?id=" + id).subscribe(
        (result: Item[]) => {
          resolve(result);
        },
        (error) => {
          console.error(error);
        }
      );
    });
  }
}

interface Item {
  id: number;
  name: string;
  brand: string;
  quantity: number;
}
