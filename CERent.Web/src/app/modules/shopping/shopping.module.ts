import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductDetailsComponent } from './components/product-details/product-details.component';
import { ProductListingComponent } from './components/product-listing/product-listing.component';
import { ProductListingFilterComponent } from './components/product-listing-filter/product-listing-filter.component';
import { HttpClientModule } from '@angular/common/http';
import { ClarityModule } from '@clr/angular';


@NgModule({
  imports: [
    CommonModule,
    HttpClientModule,
    ClarityModule
  ],
  declarations: [ProductDetailsComponent, ProductListingComponent, ProductListingFilterComponent],
  exports:[ProductDetailsComponent, ProductListingComponent, ProductListingFilterComponent]
})
export class ShoppingModule { }
