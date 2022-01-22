import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ListService {

  public lists: List[];
  public baseUrl: string;
  public http: HttpClient;
  
  constructor(http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
    this.baseUrl = baseUrl;
    this.http = http;
  }

  // getValueFromObservable(): Promise<Item[]> {
  //   return new Promise((resolves) => {
  //     this.http
  //       .get<Item[]>(this.baseUrl + "item/getAll")
  //       .subscribe((data: any) => {
  //         console.log(data);
  //         resolve(data);
  //       });
  //   });
  // }
  createList(list: any): Promise<boolean> {
        return new Promise<boolean>((resolve) => {
          this.http
            .post("https://localhost:5001/list", list, {
              responseType: "text",
            })
            .subscribe((data) => {
              console.log(data);
              resolve(true);
            });
        });


  }
  deleteList(id: number): Promise<boolean> {
    return new Promise<boolean>((resolve) => {
      var json: object = this.http
        .delete("https://localhost:5001/list?id=" + id, {
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
  getList(): Promise<List[]> {
    return new Promise<List[]>((resolve) => {
      this.http.get<List[]>(this.baseUrl + "list/getAll").subscribe(
        (result: List[]) => {
          // toto = result;
          resolve(result);
        },
        (error) => {
          console.error(error);
        }
      );
    });
  }
}

interface List {
  id: number;
  name: string;
}
