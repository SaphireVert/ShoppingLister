import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { prototype } from 'events';

@Injectable({
  providedIn: "root",
})
export class CRUDService {
  public element: any[];
  public baseUrl: string;
  public http: HttpClient;

  constructor(http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
    this.baseUrl = baseUrl;
    this.http = http;
  }

  createEntry(entry: any): Promise<boolean> {
        return new Promise<boolean>((resolve) => {
          this.http
            .post("https://localhost:5001/item", {
              responseType: "text",
            })
            .subscribe((data) => {
              console.log(data);
              resolve(true);
            });
        });
  }
  deleteEntry(id: number): Promise<boolean> {
    return new Promise<boolean>((resolve) => {
      var json: object = this.http
        .delete("https://localhost:5001/item?id=" + id, {
          responseType: "text",
        })
        .subscribe((data) => {
          console.log(data);
          console.log("data");
          resolve(true);
        });
    });
  }
  getEntries(): Promise<any[]> {
    return new Promise<any[]>((resolve) => {
      this.http.get<any[]>(this.baseUrl + "item/getAll").subscribe(
        (result: any[]) => {
          resolve(result);
        },
        (error) => {
          console.error(error);
        }
      );
    });
  }
}

