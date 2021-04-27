import { Component, OnInit } from '@angular/core';
import { ProductViewModel } from '../../models/ProductViewModel';
import { ProductService } from '../../services/product.service';

@Component({
  selector: 'app-product-listing',
  templateUrl: './product-listing.component.html',
  styleUrls: ['./product-listing.component.scss']
})
export class ProductListingComponent implements OnInit {

  public productList : ProductViewModel[] = [];

  constructor(private _productService: ProductService) { 
   }

   async ngOnInit() {
     await this.populateProducts();
  }

  async populateProducts(){
    this.productList = await this._productService.getProducts();
  }

}
