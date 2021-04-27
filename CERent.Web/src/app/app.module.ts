import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';


import { AppComponent } from './app.component';
import { ClarityModule } from '@clr/angular';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { GlobalAleartComponent } from './Shared/components/global-aleart/global-aleart.component';
import { HeaderComponent } from './Shared/components/header/header.component';
import { ShoppingModule } from './modules/shopping/shopping.module';


@NgModule({
  declarations: [
    AppComponent,
    GlobalAleartComponent,
    HeaderComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ClarityModule,
    BrowserAnimationsModule,
    ShoppingModule
    
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
