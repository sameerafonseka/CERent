import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-product-listing',
  templateUrl: './product-listing.component.html',
  styleUrls: ['./product-listing.component.scss']
})
export class ProductListingComponent implements OnInit {

  public productList : string[] = [];

  constructor() { 
    this.productList.push("xxxx");
    this.productList.push("yyy");
    this.productList.push("yyy");
    this.productList.push("yyy");
    this.productList.push("yyy");
    this.productList.push("yyy");
    this.productList.push("yyy");
  }

  ngOnInit() {


  }

}
