import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { ClarityModule } from '@clr/angular';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { GlobalAleartComponent } from './Shared/components/global-aleart/global-aleart.component';
import { HeaderComponent } from './Shared/components/header/header.component';
import { ProductListingFilterComponent } from './modules/shopping/components/product-listing-filter/product-listing-filter.component';
import { ProductListingComponent } from './modules/shopping/components/product-listing/product-listing.component';

@NgModule({
  declarations: [
    AppComponent,
    GlobalAleartComponent,
    HeaderComponent,
    ProductListingComponent,
    ProductListingFilterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ClarityModule,
    BrowserAnimationsModule
    
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
