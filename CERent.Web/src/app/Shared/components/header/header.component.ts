import { Component, OnInit } from '@angular/core';
import { CartService } from '../../services/cart.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  public noOfItems: number = 0;

  constructor(private _cartService: CartService) { }

  ngOnInit() {
    this._cartService.ItemAdded.subscribe(x => {
      this.noOfItems = this._cartService.cartItems.length;
    });
  }

}
