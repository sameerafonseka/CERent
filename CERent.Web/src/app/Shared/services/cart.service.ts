import { Injectable } from '@angular/core';
import { Observable, of, Subject } from 'rxjs';
import { CartItem } from 'src/app/modules/shopping/models/CartItem';

@Injectable({
  providedIn: 'root'
})
export class CartService {

cartItems: CartItem[] = [];

private  itemAddedSubject: Subject<CartItem> = new Subject();
public ItemAdded: Observable<CartItem>;

constructor() { 
  this.ItemAdded = this.itemAddedSubject;
}

public addToCart(ci: CartItem){
  this.cartItems.push(ci);

  this.itemAddedSubject.next(ci);
}

}


