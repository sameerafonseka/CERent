import { Component, OnInit } from '@angular/core';
import { CartService } from 'src/app/Shared/services/cart.service';
import { CartItem } from '../../models/CartItem';
import { ProductDto } from '../../models/ProductDto';
import { ProductService } from '../../services/product.service';

@Component({
  selector: 'app-product-listing',
  templateUrl: './product-listing.component.html',
  styleUrls: ['./product-listing.component.scss']
})
export class ProductListingComponent implements OnInit {

  public productList : ProductDto[] = [];
    public noOfDays : number[] = [];

  constructor(private _productService: ProductService,
    private _cartService: CartService) { 
   }

   async ngOnInit() {

    for(let i=1; i<100; i++){
      this.noOfDays.push(i);
    }

     await this.populateProducts();
  }

  async populateProducts(){
    this.productList = await this._productService.getProducts();

    this.productList.forEach(element => {
    
    });
  }

  addToCart(product: ProductDto, noOfDays: string){

    var cartItem =  <CartItem>{
      product: product,
      noOfDays: 0
   };

    this._cartService.addToCart(cartItem);
  }

}
