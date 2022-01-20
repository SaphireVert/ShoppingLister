import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { prototype } from 'events';

@Injectable({
  providedIn: "root",
})
export class CategoryService {
  // public items: Category[];
  public baseUrl: string;
  public http: HttpClient;

  constructor(http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
    this.baseUrl = baseUrl;
    this.http = http;
  }

  // getValueFromObservable(): Promise<Category[]> {
  //   return new Promise((resolves) => {
  //     this.http
  //       .get<Category[]>(this.baseUrl + "item/getAll")
  //       .subscribe((data: any) => {
  //         console.log(data);
  //         resolve(data);
  //       });
  //   });
  // }
  createItem(item: any): Promise<boolean> {
        return new Promise<boolean>((resolve) => {
          this.http
            .post("https://localhost:5001/category", item, {
              responseType: "text",
            })
            .subscribe((data) => {
              console.log(data);
              resolve(true);
            });
        });


  }
  deleteItem(id: number): Promise<boolean> {
    return new Promise<boolean>((resolve) => {
      var json: object = this.http
        .delete("https://localhost:5001/category?id=" + id, {
          responseType: "text",
        })
        .subscribe((data) => {
          console.log(data);
          console.log("data");
          resolve(true);
          // test.ngOnInit()
        });
    });
  }
  getItems(): Promise<Category[]> {
    return new Promise<Category[]>((resolve) => {
      this.http.get<Category[]>(this.baseUrl + "category/getAll").subscribe(
        (result: Category[]) => {
          // toto = result;
          console.log(result);
          
          resolve(result);
        },
        (error) => {
          console.error(error);
        }
      );
    });
  }
}

interface Category {
  id: number;
  name: string;
}
