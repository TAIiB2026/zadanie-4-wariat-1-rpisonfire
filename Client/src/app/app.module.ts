import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProduktyComponent } from './produkty/produkty.component';
import { FormularzComponent } from './formularz/formularz.component';
import { RepozytoriumPamiecioweService } from './repozytorium-pamieciowe.service';
import { RepozytoriumWebApiService } from './repozytorium-web-api.service';
import { RepozytoriumWebApiSubmitService } from './repozytorium-web-api-submit.service';
import { GET_DATA_TOKEN } from './tokens/get-data.token';
import { FORM_SUBMIT_TOKEN } from './tokens/form-submit.token';
import { LOCALE_ID } from '@angular/core';
import { registerLocaleData } from '@angular/common';
import localePl from '@angular/common/locales/pl';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

registerLocaleData(localePl);

@NgModule({
  declarations: [
    AppComponent,
    ProduktyComponent,
    FormularzComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [
    RepozytoriumPamiecioweService,
    RepozytoriumWebApiService,
    RepozytoriumWebApiSubmitService,
    {
      provide: GET_DATA_TOKEN, useExisting: RepozytoriumWebApiService,
    },
    {
      provide: FORM_SUBMIT_TOKEN, useExisting: RepozytoriumWebApiSubmitService
    },
    {
      provide: LOCALE_ID, useValue: 'pl-PL'
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
