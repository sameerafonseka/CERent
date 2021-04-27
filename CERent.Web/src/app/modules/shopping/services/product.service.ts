import { Injectable } from '@angular/core';
import { ProductDto } from '../models/ProductDto';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { JsonResponse } from 'src/app/core/models/JsonResponse';
import {map} from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private _httpClient: HttpClient) { }

  public getProducts() : Promise<ProductDto[]>{

    const url = 'http://localhost:6002/api/v1/Product';

    return this._httpClient
      .get<JsonResponse<ProductDto[]>>(url)
      .pipe(map(x => x.data))
      .toPromise()
  }

}
