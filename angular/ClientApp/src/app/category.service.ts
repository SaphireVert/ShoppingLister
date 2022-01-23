import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { prototype } from 'events';

@Injectable({
  providedIn: "root",
})
export class CategoryService {
  public baseUrl: string;
  public http: HttpClient;

  constructor(http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
    this.baseUrl = baseUrl;
    this.http = http;
  }

  createCategory(category: any): Promise<boolean> {
        return new Promise<boolean>((resolve) => {
          this.http
            .post("https://localhost:5001/category", category, {
              responseType: "text",
            })
            .subscribe((data) => {
              resolve(true);
            });
        });


  }
  deleteCategory(id: number): Promise<boolean> {
    return new Promise<boolean>((resolve) => {
      var json: object = this.http
        .delete("https://localhost:5001/category?id=" + id, {
          responseType: "text",
        })
        .subscribe((data) => {
          resolve(true);
        });
    });
  }
  getCategories(): Promise<Category[]> {
    return new Promise<Category[]>((resolve) => {
      this.http.get<Category[]>(this.baseUrl + "category/getAll").subscribe(
        (result: Category[]) => {
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
