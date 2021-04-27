import { Injectable } from '@angular/core';
import { ProductViewModel } from '../models/ProductViewModel';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { JsonResponse } from 'src/app/core/models/JsonResponse';
import {map} from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private _httpClient: HttpClient) { }

  public getProducts() : Promise<ProductViewModel[]>{

    const url = 'http://localhost:6002/api/v1/Product';

    return this._httpClient
      .get<JsonResponse<ProductViewModel[]>>(url)
      .pipe(map(x => x.data))
      .toPromise()
  }

}
