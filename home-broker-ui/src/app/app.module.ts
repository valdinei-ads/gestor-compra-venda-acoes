import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ToastrModule } from 'ngx-toastr';

import { ClienteModule } from './modules/cliente/cliente.module';
import { CotacaoModule } from './modules/cotacao/cotacao.module';
import { OrdemModule } from './modules/ordem/ordem.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,

    RouterModule,
    ReactiveFormsModule,
    ToastrModule.forRoot(),

    ClienteModule,
    CotacaoModule,
    OrdemModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {


}
