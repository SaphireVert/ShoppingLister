import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NumberSymbol } from '@angular/common';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  public baseUrl: string;
  public http: HttpClient;

  constructor(http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
    this.baseUrl = baseUrl;
    this.http = http;
  }

  createProduct(item: any): Promise<boolean> {
        return new Promise<boolean>((resolve) => {
          this.http
            .post("https://localhost:5001/product", item, {
              responseType: "text",
            })
            .subscribe((data) => {
              console.log(data);
              resolve(true);
            });
        });


  }
  deleteProduct(id: number): Promise<boolean> {
    return new Promise<boolean>((resolve) => {
      var json: object = this.http
        .delete("https://localhost:5001/product?id=" + id, {
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
  getProducts(): Promise<Product[]> {
    return new Promise<Product[]>((resolve) => {
      this.http.get<Product[]>(this.baseUrl + "product/getAll").subscribe(
        (result: Product[]) => {
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

interface Product {
  id: number;
  name: string;
  brand: string;
  categoryId: number;
}

